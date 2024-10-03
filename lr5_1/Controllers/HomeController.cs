using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(string value, DateTime expiryDate)
    {
        // Записуємо дані у Cookies з терміном дії
        CookieOptions options = new CookieOptions
        {
            Expires = expiryDate
        };
        Response.Cookies.Append("userValue", value, options);

        return RedirectToAction("CookiesCheck");
    }

    [HttpGet]
    public IActionResult CookiesCheck()
    {
        // Перевірка наявності значення в Cookies
        string? userValue = Request.Cookies["userValue"];
        if (string.IsNullOrEmpty(userValue))
        {
            ViewBag.Message = "Cookies не встановлені або закінчився термін дії.";
        }
        else
        {
            ViewBag.Message = $"Значення в Cookies: {userValue}";
        }

        return View();
    }

    // Метод для виклику виключення
    [HttpPost]
    public IActionResult ThrowException()
    {
        // Пробуємо викликати виключення спеціально
        throw new Exception("Це тестове виключення для логування.");
    }
}
