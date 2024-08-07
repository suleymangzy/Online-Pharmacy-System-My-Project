var builder = WebApplication.CreateBuilder(args);

// Hizmetleri ekle
builder.Services.AddControllersWithViews(); // MVC hizmetlerini ekler
builder.Services.AddRazorPages(); // Razor Pages hizmetlerini ekler

// Kimlik doğrulama ve yetkilendirme hizmetlerini ekle
builder.Services.AddAuthentication("YourCookieScheme")
    .AddCookie("YourCookieScheme", options =>
    {
        options.LoginPath = "/Account/Login"; // Örnek
    });

builder.Services.AddAuthorization(options =>
{
    // Yetkilendirme politikalarını tanımlayın
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
});

var app = builder.Build();

// Geliştirme ortamında hata ayrıntılarını göster
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Kimlik doğrulama ve yetkilendirme işlemlerini ekle
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
