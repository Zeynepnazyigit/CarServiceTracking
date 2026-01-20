var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient("api", client =>
{
    var baseUrl = builder.Configuration["ApiSettings:BaseUrl"]
                  ?? throw new InvalidOperationException("ApiSettings:BaseUrl appsettings.json içinde bulunamadý!");

    client.BaseAddress = new Uri(baseUrl);
});

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<CarServiceTracking.UI.Web.Services.CarApiService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
