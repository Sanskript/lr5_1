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
        // �������� ��� � Cookies � ������� 䳿
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
        // �������� �������� �������� � Cookies
        string? userValue = Request.Cookies["userValue"];
        if (string.IsNullOrEmpty(userValue))
        {
            ViewBag.Message = "Cookies �� ���������� ��� ��������� ����� 䳿.";
        }
        else
        {
            ViewBag.Message = $"�������� � Cookies: {userValue}";
        }

        return View();
    }

    // ����� ��� ������� ����������
    [HttpPost]
    public IActionResult ThrowException()
    {
        // ������� ��������� ���������� ����������
        throw new Exception("�� ������� ���������� ��� ���������.");
    }
}
