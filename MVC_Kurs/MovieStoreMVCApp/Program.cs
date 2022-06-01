using Microsoft.EntityFrameworkCore;
using MovieStoreMVCApp.Data;
using MovieStoreMVCApp.Middleware;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//EFCore verwendet Scoped 
builder.Services.AddDbContext<MovieDbContext>(options =>
{
    //options.UseInMemoryDatabase("MovieDB");

    options.UseSqlServer(builder.Configuration.GetConnectionString("MSSQLConStr"));
});


builder.Services.AddSession(options=>
{
    
});

var app = builder.Build();


//Frühester Zugriff auf den IOC Container
//.NET 6 

//MovieDbContext movieDbContext = app.Services.GetRequiredService<MovieDbContext>();

IServiceScope scope = app.Services.CreateScope();
MovieDbContext dbContext = scope.ServiceProvider.GetRequiredService<MovieDbContext>();

//DataSeeder bekommt MovieDBContext, z.b Initialisieren der 
DataSeeder.SeedMovieStoreDb(dbContext);


AppDomain.CurrentDomain.SetData("RootVerzeichnis", app.Environment.WebRootPath);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseSession();

app.UseStaticFiles();

app.UseRouting();

//Unsere Thumbnail Middleware

app.MapWhen(context => context.Request.Path.ToString().Contains("imagegen"), subapp =>
{
    subapp.UseThumbNailGen();
});


app.UseAuthorization();



app.MapControllerRoute(name: "statemanagement",
                pattern: "StateManagement/{*state}",
                defaults: new { controller = "StateManagement", action = "ViewDataSample" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
