using MVCKurs.Configurations;
using MVCKurs.Services;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
// ASP.NET Core 2.1 WebHostBuilder
// ASPNETCore 3.1 / 5 verwenden den IHostBuilder 

#region ConfigureServices->IServiceCollection 

// Add services to the container.
builder.Services.AddControllersWithViews(options=> {
    //Optionen können gesetzt werden
});



builder.Services.AddSingleton<ICar, Car>();
builder.Services.AddSingleton(typeof(Car2));

builder.Services.AddScoped<IDateTimeService, DateTimeService>();

//Weitere Dienste hinzufügen -> Singleton/Scoped / Transient 

#region Konfiguration Sample
builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
{
    //Weite Konfigurationsdateien können wir hinzufügen 
    config.AddJsonFile("GameSettings.json" , optional: true, reloadOnChange: true);
});

builder.Services.Configure<GameSettings>(builder.Configuration.GetSection("GameSettings"));
#endregion


WebApplication app = builder.Build(); //Erstellen des ServiceProviders
#endregion



#region DI-Samples -> frühstmöglichen Zugriff auf IOC Container (2 Varianten) 
//Use Cases, wenn wir Testdaten vorab in das Problem intialisieren möchten 

ICar car = app.Services.GetRequiredService<ICar>(); //.NET 6 

//.NET 2.1
using (IServiceScope scope = app.Services.CreateScope())
{
    ICar car2 = scope.ServiceProvider.GetRequiredService<ICar>();
    ICar? car3 = scope.ServiceProvider.GetService<ICar>();
}
#endregion


#region Konfiguration -> Welcher Dienst läuft auf welcher Server-Instanz 
// Configure the HTTP request pipeline.

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
    app.UseDeveloperExceptionPage(); // Warum wird dieses Feature nicht mehr implementiert 

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


//Endpunkt -> Anfrage von Browser wird auf den richtigen Controller und seiner Action-Methode navigiert (Was wollen wir aufrufen) 

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); //Default - URL -> https://localhost:12345/Home/Index 
//https://localhost:12345/ ->  https://localhost:12345/Home/Index 
//https://localhost:12345/Movie -> https://localhost:12345/Movie/Index/123  

//https://localhost:12345/Movie/Startseite 

//https://
#endregion

app.Run();
