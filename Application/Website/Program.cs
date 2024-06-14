using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using InterfacesLL;
using InterfacesDAL;
using LogicLayer;
using DataAccessLayer;
using LogicLayer.RecommendationStrategy;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDistributedMemoryCache();


builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login";
        options.LogoutPath = "/Logout";
        options.AccessDeniedPath = "/Index";
    });

builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IUserDAL, UserDAL>();
builder.Services.AddTransient<IEventService, EventService>();
builder.Services.AddTransient<IEventDAL, EventDAL>();
builder.Services.AddTransient<IAlcoholService, AlcoholService>();
builder.Services.AddTransient<IAlcoholDAL, AlcoholDAL>();
builder.Services.AddTransient<ICommentsService, CommentsService>();
builder.Services.AddTransient<ICommentsDAL, CommentsDAL>();
builder.Services.AddTransient<IReportService, ReportService>();
builder.Services.AddTransient<IReportDAL, ReportDAL>();
builder.Services.AddTransient<ISoftService, SoftService>();
builder.Services.AddTransient<ISoftDAL, SoftDAL>();
builder.Services.AddTransient<IRecommendationStrategy, AgeEventBeverageRecommendationStrategy>();
builder.Services.AddTransient<IRecommendationStrategy, BirthdayClosenessRecommendationStrategy>();
builder.Services.AddScoped<UserRecommender>();
builder.Services.AddScoped<StrategyManager>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/404");
    app.UseStatusCodePagesWithReExecute("/404");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseSession();

app.UseStatusCodePages(async context =>
{
    if (context.HttpContext.Response.StatusCode == 404)
    {
        context.HttpContext.Response.Redirect("/404");
    }
});

app.MapRazorPages();

app.MapFallback(context =>
{
    context.Response.Redirect("/404");
    return Task.CompletedTask;
});

app.Run();
