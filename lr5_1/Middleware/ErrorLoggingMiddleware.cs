using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

public class ErrorLoggingMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorLoggingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context); // Передаємо запит далі
        }
        catch (Exception ex)
        {
            // Логування помилки у файл
            await LogErrorToFile(ex);
            throw; // Проброс виключення далі
        }
    }

    private Task LogErrorToFile(Exception ex)
    {
        var logFilePath = "logs/error_log.txt";
        var logMessage = $"{DateTime.Now}: {ex.Message}{Environment.NewLine}{ex.StackTrace}{Environment.NewLine}";
        return File.AppendAllTextAsync(logFilePath, logMessage);
    }
}
