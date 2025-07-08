var builder = WebApplication.CreateBuilder(args);

// Servisleri ekle
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Hata ve güvenlik yapılandırması
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// HTTPS yönlendirmesi ve statik dosyalar
app.UseHttpsRedirection();
app.UseStaticFiles();

// Yönlendirme ve yetkilendirme
app.UseRouting();
app.UseAuthorization();

// Default route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
