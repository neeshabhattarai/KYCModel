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


var builder = WebApplication.CreateBuilder(args);
var logger = new LoggerConfiguration().WriteTo.Console().WriteTo.File("Logger/Application.logs",rollingInterval:RollingInterval.Hour).MinimumLevel.Information().CreateLogger();
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));
builder.Services.AddSerilog(logger);


builder.Services.AddSwaggerGen(opt =>
{
   opt.SwaggerDoc("v1",new OpenApiInfo { Title="FirstApplication",Version="v1"});
    opt.AddSecurityDefinition("Auth", new OpenApiSecurityScheme
    {
In=ParameterLocation.Header,
Scheme=JwtBearerDefaults.AuthenticationScheme,
Name="Auth",
Type=SecuritySchemeType.OAuth2
    });
    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference=new OpenApiReference
                {
                    Id=JwtBearerDefaults.AuthenticationScheme,
                    Type=ReferenceType.SecurityScheme
                },
                Scheme="Auth",
                Type=SecuritySchemeType.OAuth2,
                In=ParameterLocation.Header,
                Name="Auth"
            },
            new List<string>()
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



if (app.Environment.IsDevelopment())
{
  
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
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
