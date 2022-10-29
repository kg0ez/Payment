using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using PAymentForServices.BusinessLogic.Services;

var builder = WebApplication.CreateBuilder(args);

RegisterServices(builder.Services);

var app = builder.Build();

Configure(app);

app.Run();

void RegisterServices(IServiceCollection services)
{
    // Add services to the container.
    services.AddControllersWithViews();

    services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

    services.AddAuthentication(option =>
    {
        option.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        option.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
    })
        .AddCookie()
        .AddGoogle(GoogleDefaults.AuthenticationScheme, options =>
        {
            options.ClientId = builder.Configuration["Authentication:Google:ClientId"];
            options.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
            options.ClaimActions.MapJsonKey("urn:google:picture", "picture", "url");
        });
}

void Configure(WebApplication app)
{
    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();

    app.UseAuthentication();

    app.UseAuthorization();

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=MainPage}/{id?}");
}