var builder = WebApplication.CreateBuilder(args);

// Додаємо сервіси для контролерів
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Додаємо middleware для логування помилок
app.UseMiddleware<ErrorLoggingMiddleware>();

app.MapDefaultControllerRoute(); // Це використовує маршрутизацію контролерів

app.Run();
