using Business.CourseService;
using Business.UserCourseService;
using Domain.Entities;
using EFCore.Context;
using EFCore.Repository.Repository;
using EFCore.Repository.UnitOfWork;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DBConnection")));
builder.Services.AddIdentity<User, Role>()
   .AddEntityFrameworkStores<AppDbContext>()
   .AddDefaultTokenProviders();


builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<IUserCourseService, UserCourseService>();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = $"/Authorize/Login";
    options.LogoutPath = $"/Authorize/Logout";
    options.AccessDeniedPath = $"/Authorize/AccessDenied";
});

builder.Services.Configure<FormOptions>(options =>
{
    options.ValueCountLimit = int.MaxValue;
    options.ValueLengthLimit = int.MaxValue;
});



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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");





using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var loggerFactory = services.GetRequiredService<ILoggerFactory>();
    try
    {
        var context = services.GetRequiredService<AppDbContext>();
        var userManager = services.GetRequiredService<UserManager<User>>();
        var roleManager = services.GetRequiredService<RoleManager<Role>>();
        await UserRoleSeed.SeedRoleAsync(userManager, roleManager);
        await UserRoleSeed.SeedUserAsync(userManager, roleManager);
    }
    catch (Exception ex)
    {
        var logger = loggerFactory.CreateLogger<Program>();
        logger.LogError(ex, ex.Message);
    }
}

app.Run();
