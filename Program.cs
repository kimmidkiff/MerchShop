using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using MerchShop.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<MerchShopContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MerchShopContext")));
builder.Services.AddIdentity<MerchShopUser, IdentityRole>().AddEntityFrameworkStores<MerchShopContext>().AddDefaultTokenProviders();

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
app.UseAuthentication();
app.UseAuthorization();


var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
using (var scope = scopeFactory.CreateScope())
{
    await ConfigureIdentity.CreateAdminUserAsync(scope.ServiceProvider);
}



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}/{slug?}");


app.MapControllerRoute(
    name: "paging_sorting",
    pattern: "{controller}/{action}/page-{PageNumber}/page-size-{PageSize}/{SortDirection}/sorted-on-{SortField}");


app.MapControllerRoute(
    name: "merch_details",
    pattern: "{controller=Merch}/{action=Details}/{id?}/{slug?}");



app.Run();
