var builder = WebApplication.CreateBuilder(args);

// Hizmetleri ekle
builder.Services.AddControllersWithViews(); // MVC hizmetlerini ekler
builder.Services.AddRazorPages(); // Razor Pages hizmetlerini ekler

// Kimlik doðrulama ve yetkilendirme hizmetlerini ekle
builder.Services.AddAuthentication("YourCookieScheme")
    .AddCookie("YourCookieScheme", options =>
    {
        options.LoginPath = "/Account/Login"; // Örnek
    });

builder.Services.AddAuthorization(options =>
{
    // Yetkilendirme politikalarýný tanýmlayýn
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
});

var app = builder.Build();

// Geliþtirme ortamýnda hata ayrýntýlarýný göster
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

// Kimlik doðrulama ve yetkilendirme iþlemlerini ekle
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
