using Microsoft.Extensions.Options;
using System.Globalization;
using WebApplication1;
using WebApplication1.Resources;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
#region localization
builder.Services.AddControllersWithViews()
        .AddViewLocalization(o => o.ResourcesPath = "Resources")
        .AddDataAnnotationsLocalization(options => options.DataAnnotationLocalizerProvider
                                      = (t, f) => f.Create(typeof(SharedResource))
                                      );
builder.Services.AddTransient<ISharedViewLocalizer, SharedViewLocalizer>(); 
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

#region management culture extension
var supportedCultures = new[] { new CultureInfo("tr-TR"), new CultureInfo("en-US"), new CultureInfo("fr-FR") };  //1
var requestLocalizationOptions = new RequestLocalizationOptions  //2
{
    SupportedCultures = supportedCultures,
    SupportedUICultures = supportedCultures
};
app.UseRequestLocalization(requestLocalizationOptions);  //3 
#endregion

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
