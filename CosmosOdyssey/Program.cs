﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CosmosOdyssey.Data;
using CosmosOdyssey.Services;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<CosmosOdysseyContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CosmosOdysseyContext") ?? throw new InvalidOperationException("Connection string 'CosmosOdysseyContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<TravelPriceService>();
builder.Services.AddSingleton<ReservationService>();

var app = builder.Build();

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
