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

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IPersonalDetails,SQLPersonalDetailsRepository>();
builder.Services.AddScoped<INationalIdentity,SQLNationalIDentityRepository>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddDbContext<AuthApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AuthConnection")));

builder.Services.AddIdentityCore<IdentityUser>().AddRoles<IdentityRole>().AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>("TokenProvider").AddEntityFrameworkStores<AuthApplicationDbContext>().AddDefaultTokenProviders();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt => opt.TokenValidationParameters = new TokenValidationParameters
{
    ValidateAudience=true,
    ValidateIssuer=true,
    ValidateIssuerSigningKey=true,
    ValidateLifetime=true,
    ValidIssuer = builder.Configuration["JWT:Issuer"],
    ValidAudience = builder.Configuration["JWT:Audience"],
    IssuerSigningKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
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
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();

app.UseAuthorization();


app.MapControllers();
using (var scope = app.Services.CreateScope
    ())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
    var roleManger = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    await SeedData.SeedDataDefault (userManager, roleManger);
}

app.Run();
