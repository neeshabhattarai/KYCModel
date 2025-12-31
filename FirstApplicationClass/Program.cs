using FirstApplicationClass.Model;
using FirstApplicationClass.Repository;
using FirstApplicationClass.Service;
using Microsoft.EntityFrameworkCore;
using FirstApplicationClass.Repository.Interface;
using FirstApplicationClass.Mapper;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IPersonalDetails,PersonalDetailsRepository>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


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
