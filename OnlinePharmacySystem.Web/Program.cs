var builder = WebApplication.CreateBuilder(args);

// Hizmetleri ekle
builder.Services.AddControllersWithViews(); // MVC hizmetlerini ekler
builder.Services.AddRazorPages(); // Razor Pages hizmetlerini ekler

// Kimlik do�rulama ve yetkilendirme hizmetlerini ekle
builder.Services.AddAuthentication("YourCookieScheme")
    .AddCookie("YourCookieScheme", options =>
    {
        options.LoginPath = "/Account/Login"; // �rnek
    });

builder.Services.AddAuthorization(options =>
{
    // Yetkilendirme politikalar�n� tan�mlay�n
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
});

var app = builder.Build();

// Geli�tirme ortam�nda hata ayr�nt�lar�n� g�ster
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

// Kimlik do�rulama ve yetkilendirme i�lemlerini ekle
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
