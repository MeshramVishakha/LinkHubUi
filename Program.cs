using BLL;
using BOL;
using DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.




builder.Services.AddControllersWithViews();
builder.Services.AddTransient<ILHCategoryBC, LHCategoryBC>();
builder.Services.AddTransient<ILHUrlBc, LHUrlBC>();
builder.Services.AddTransient<ILHUserBC, LHUserBC>();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.RegisterBLLServices(connectionString);
builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<LinkHubDbContext>()
    .AddDefaultTokenProviders();

var policy = new AuthorizationPolicyBuilder()
                                       .RequireAuthenticatedUser()
                                       .Build();

builder.Services.AddMvc(x => x.Filters.Add(new AuthorizeFilter(policy)));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseDeveloperExceptionPage();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Categories}/{action=Index}/{id?}");

app.Run();
