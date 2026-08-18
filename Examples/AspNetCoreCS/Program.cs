using GleamTech;
using GleamTech.AspNet;
using GleamTech.AspNet.Core;
using GleamTech.FileUltimate;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


//----------------------
//Add GleamTech to the ASP.NET Core services container.
builder.Services.AddGleamTech();
//----------------------


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}


//----------------------
//Register GleamTech to the ASP.NET Core HTTP request pipeline.
app.UseGleamTech(() =>
{
    //The below custom config file loading is only for our demo publishing purpose:

    var gleamTechConfig = Hosting.ResolvePhysicalPath("~/App_Data/GleamTech.config");
    if (File.Exists(gleamTechConfig))
        GleamTechConfiguration.Current.Load(gleamTechConfig);

    var fileUltimateConfig = Hosting.ResolvePhysicalPath("~/App_Data/FileUltimate.config");
    if (File.Exists(fileUltimateConfig))
        FileUltimateConfiguration.Current.Load(fileUltimateConfig);
});
//----------------------


app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
