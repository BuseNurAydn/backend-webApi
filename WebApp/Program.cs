using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using WebApp.Models;

var builder = WebApplication.CreateBuilder(args);



// CORS hatasý verdiði için ayarlarý yapýyoruz 
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.WithOrigins("http://localhost:3000") // Frontend adresi
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});



// Add services to the container.
builder.Services.AddControllersWithViews();


// Add DbContext
builder.Services.AddDbContext<TaxDefinitionDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


//ENUM DEÐERLERÝNÝ JSON DA STRÝNG GÖNDERMEK ÝÇÝN LAZIM OLURSA 
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

builder.Services.AddControllers();
var app = builder.Build();

// CORS'u kullan
app.UseCors("AllowSpecificOrigin");


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();



 

