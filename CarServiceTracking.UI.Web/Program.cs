using CarServiceTracking.UI.Web.Services;
using CarServiceTracking.UI.Web.Infrastructure;
using CarServiceTracking.UI.Web.Middlewares;
using System.Globalization;
using System.Text;
using Microsoft.AspNetCore.Localization;

var builder = WebApplication.CreateBuilder(args);

// =====================
// UTF-8 Encoding & Culture
// =====================
Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
QuestPDF.Settings.License = QuestPDF.Infrastructure.LicenseType.Community;

var cultureInfo = new CultureInfo("tr-TR");
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    options.DefaultRequestCulture = new RequestCulture("tr-TR");
    options.SupportedCultures = new[] { cultureInfo };
    options.SupportedUICultures = new[] { cultureInfo };
});

// =====================
// MVC
// =====================
builder.Services.AddControllersWithViews();

// =====================
// Session
// =====================
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromHours(8);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// =====================
// HttpContextAccessor
// =====================
builder.Services.AddHttpContextAccessor();

// =====================
// JWT Token Handler
// =====================
builder.Services.AddTransient<JwtTokenHandler>();

// =====================
// API HttpClient (named: api)
// =====================
builder.Services.AddHttpClient("api", client =>
{
    var baseUrl = builder.Configuration["ApiSettings:BaseUrl"]
        ?? throw new InvalidOperationException(
            "ApiSettings:BaseUrl appsettings.json içinde bulunamadı!");

    client.BaseAddress = new Uri(baseUrl);
})
.AddHttpMessageHandler<JwtTokenHandler>(); // JWT token'ı otomatik ekler

// =====================
// DI - API Services
// =====================
// Mevcut Servisler
builder.Services.AddScoped<ServiceRequestApiService>();
builder.Services.AddScoped<CustomerCarApiService>();
builder.Services.AddScoped<CarApiService>();
builder.Services.AddScoped<AuthApiService>();
builder.Services.AddScoped<CustomerApiService>();
builder.Services.AddScoped<ListItemApiService>();

// ADIM 7 - Yeni Modül Servisleri
builder.Services.AddScoped<PartApiService>();
builder.Services.AddScoped<AppointmentApiService>();
builder.Services.AddScoped<MechanicApiService>();
builder.Services.AddScoped<InvoiceApiService>();
builder.Services.AddScoped<PaymentApiService>();
builder.Services.AddScoped<RentalApiService>();
builder.Services.AddScoped<ServiceAssignmentApiService>();
builder.Services.AddScoped<PdfService>();

var app = builder.Build();

// =====================
// Middleware
// =====================

// Global Exception Handling (En başta olmalı)
app.UseMiddleware<ExceptionHandlingMiddleware>();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
    app.UseHttpsRedirection();
}

// UTF-8 Encoding globally
System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

app.UseRequestLocalization();

app.UseStaticFiles();

app.UseRouting();

// 🔥 KRİTİK SIRA
app.UseSession();        // MUTLAKA routing'den sonra

// =====================
// Authorization Middlewares (Route-based)
// =====================
app.UseWhen(context => context.Request.Path.StartsWithSegments("/Admin"), appBuilder =>
{
    appBuilder.UseMiddleware<AdminOnlyMiddleware>();
});

app.UseWhen(context => context.Request.Path.StartsWithSegments("/Customer"), appBuilder =>
{
    appBuilder.UseMiddleware<CustomerOnlyMiddleware>();
});

app.UseAuthorization();

// =====================
// ROUTING (Clean Architecture - No Areas)
// =====================

// Default route → Tüm controller'lar için tek pattern
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Auth}/{action=Login}/{id?}"
);

app.Run();
