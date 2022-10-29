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
}

void Configure(WebApplication app)
{
    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();

    app.UseAuthorization();

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=MainPage}/{id?}");
}