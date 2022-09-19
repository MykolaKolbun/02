using AVERAPI.Controllers;
using AVERWeb.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddControllers();
builder.Services.AddMvcCore();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(
        builder.Configuration.GetConnectionString("CommanderConnection")
    ));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<ICashierRepo, CashierRepo>();
builder.Services.AddScoped<ICertificateRepo, CertificateRepo>();
builder.Services.AddScoped<ICustomerRepo, CustomerRepo>();
builder.Services.AddScoped<IFiscalReceiptRepo, FiscalReceiptRepo>();
builder.Services.AddScoped<IMachineRepo, MachineRepo>();
builder.Services.AddScoped<IMachineTypeRepo, MachineTypeRepo>();
builder.Services.AddScoped<IPaymentTypeRepo, PaymentTypeRepo>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();
//app.UseMvc();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.Run();
