using FirstApplicationClass.Model;
using FirstApplicationClass.Repository;
using FirstApplicationClass.Service;
using Microsoft.EntityFrameworkCore;
using FirstApplicationClass.Repository.Interface;
using FirstApplicationClass.Mapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

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
builder.Services.AddIdentityCore<IdentityUser>()
.AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>("Test")
.AddEntityFrameworkStores<AuthApplicationDbContext>().AddDefaultTokenProviders();
builder.Services.Configure<PasswordOptions>(opt =>
{
    opt.RequiredUniqueChars = 1;
    opt.RequireDigit = false;
    opt.RequireUppercase = false;
    opt.RequireLowercase = false;
});
//builder.Services.AddAuthentication().AddJwtBearer(opt =>
//{
//    opt.TokenValidationParameters = new TokenValidationParameters
//    {
//        ValidateIssuerSigningKey = true,
//        ValidateIssuer = true,
//        ValidateAudience = true,
//        ValidateLifetime = true,
//        IssuerSigningKey = builder.Configuration["JWT:key"],
//        IssuerValidator = builder.Configuration["Jwt:Issuer"],



//    };


//}).AddBearerToken();
var app = builder.Build();



if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();


app.MapControllers();

app.Run();
