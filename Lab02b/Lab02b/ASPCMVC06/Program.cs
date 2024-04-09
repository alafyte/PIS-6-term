using ASPCMVC06.Constraints;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.Configure<RouteOptions>(options =>
{
    options.ConstraintMap.Add("V3", typeof(StringRouteContraint));
    options.ConstraintMap.Add("ID", typeof(IdConstraint));
});


var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "V2",
    pattern: "V2/{MResearch:regex(^MResearch$)?}/{action:regex(^M01|M02$)}",
    defaults: new { controller = "TMResearch", action = "M02" });

app.MapControllerRoute(
    name: "V3",
    pattern: "{V3:regex(^V3$):V3}/{MResearch:regex(^MResearch$)?}/{string?}/{action:regex(^M01|M02|M03$)}",
    defaults: new { controller = "TMResearch", action = "M03"});

app.MapControllerRoute(
    name: "MResearch",
    pattern: "{MResearch:regex(^MResearch$):ID?}/{action:regex(^M01|M02$)}/{id:regex(^1$)?}",
    defaults: new { controller = "TMResearch", action = "M01" });

app.MapControllerRoute(
    name: "MXX",
    pattern: "{*url}",
    defaults: new { controller = "TMResearch", action = "MXX" });

app.Run();
