using FirstApplicationClass.Model;
using FirstApplicationClass.Repository;
using FirstApplicationClass.Service;
using Microsoft.EntityFrameworkCore;
using FirstApplicationClass.Repository.Interface;
using FirstApplicationClass.Mapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.FileProviders.Physical;
using Microsoft.Extensions.FileProviders.Internal;
using Microsoft.Extensions.FileProviders;
using FirstApplicationClass.Middlerware;
using Serilog;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Mvc.ApiExplorer;


var builder = WebApplication.CreateBuilder(args);
var logger = new LoggerConfiguration().WriteTo.Console().WriteTo.File("Logger/Application.logs",rollingInterval:RollingInterval.Hour).MinimumLevel.Information().CreateLogger();
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));
builder.Services.AddSerilog(logger);
//Added Version to swagger
builder.Services.AddApiVersioning(opt =>
{
    opt.AssumeDefaultVersionWhenUnspecified = true;
    opt.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
    opt.ReportApiVersions = true;
});
builder.Services.AddVersionedApiExplorer(opt =>
{
    opt.GroupNameFormat = "'v'VVV";
    opt.SubstituteApiVersionInUrl = true;
});



builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Api Definition",
        Description = JwtBearerDefaults.AuthenticationScheme
    });
    opt.AddSecurityDefinition("Auth", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Name = "Auth",
        Scheme = JwtBearerDefaults.AuthenticationScheme,

    });
    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {new OpenApiSecurityScheme
        {
            Reference=new OpenApiReference
            {
                Type=ReferenceType.SecurityScheme,
                Id="Auth"
            },
            Type=SecuritySchemeType.Http,
            In=ParameterLocation.Header,
            Scheme=JwtBearerDefaults.AuthenticationScheme
            
        },
       new  List<string>()
        }
    });

   

});
builder.Services.AddScoped<IPersonalDetails,SQLPersonalDetailsRepository>();
builder.Services.AddScoped<INationalIdentity,SQLNationalIDentityRepository>();
builder.Services.AddScoped<IImage, SQLRegisterImage>();


builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddDbContext<AuthApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AuthConnection")));

builder.Services.AddIdentityCore<IdentityUser>().AddRoles<IdentityRole>().AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>("TokenGenerator").AddEntityFrameworkStores<AuthApplicationDbContext>().AddDefaultTokenProviders();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt => opt.TokenValidationParameters = new TokenValidationParameters
{
    ValidateAudience = true,
    ValidateIssuer = true,
    ValidateIssuerSigningKey=true,
    ValidIssuer = builder.Configuration["JWT:Issuer"],
    ValidAudience = builder.Configuration["JWT:Audience"],
    IssuerSigningKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:key"]))

});
builder.Services.Configure<PasswordOptions>(opt =>
{
    //opt.RequiredUniqueChars = 1;
    opt.RequireLowercase = false;
    opt.RequireUppercase = false;
    opt.RequireDigit = false;
    opt.RequiredUniqueChars = 0;
    opt.RequiredLength = 3;

});
builder.Services.AddSingleton<IToken, TokenGenerator>();

var app = builder.Build();

var descriptors=app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
if (app.Environment.IsDevelopment())
{
  
    app.UseSwagger();
    app.UseSwaggerUI(opt =>
    {
        foreach(var descriptor in descriptors.ApiVersionDescriptions)
        {
            opt.SwaggerEndpoint($"/swagger/{descriptor.GroupName}/swagger.json", descriptor.GroupName.ToUpperInvariant());
        }
    });
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseApiVersioning();
app.UseMiddleware<ExceptionHandlerGlobally>();
app.UseAuthorization();
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Images")),
    RequestPath="/Images"
});

app.MapControllers();
using (var scope = app.Services.CreateScope
    ())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
    var roleManger = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    await SeedData.SeedDataDefault (userManager, roleManger);
}
app.Run();
