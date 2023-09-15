using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SupplyService.Contracts.SupplyRequests.Repositories;
using SupplyService.Infrastructure.Data;
using SupplyService.Infrastructure.Repositories;
using SupplyService.Application;
using System.Formats.Asn1;
using SupplyService.Application.SupplyRequests;
using SupplyService.Contracts.LogService;
using SupplyService.Infrastructure.LogService;
using SupplyService.Contracts.Communication;
using SupplyService.Infrastructure.Communication;
using SupplyService.Contracts.Users.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
})
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ISupplyRequestRepository, SupplyRequestRepository>();
builder.Services.AddScoped<ILoggerService, LoggerDatabaseService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<ISmsService, SmsService>();
builder.Services.AddScoped<IUserRepository, UserReposirtory>();
var assembly = typeof(CreateSupplyRequestCommandHandler).Assembly;
//var assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(a => a.FullName.Contains("SupplyService")).ToArray();
builder.Services.AddMediatR(conf => conf.RegisterServicesFromAssembly(assembly));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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
app.MapRazorPages();

app.Run();
