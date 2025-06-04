using AcademicWorkManagerService.Domain.Constants;
using KDS.Primitives.FluentResult;
using Microsoft.AspNetCore.Mvc;

namespace AcademicWorkManagerService.Presentation.Controllers;

[ApiController]
public class BaseController : ControllerBase
{
    [NonAction]
    public IActionResult GenerateProblemResponse(Error error)
    {
        ProblemDetails problemDetails = error.Code switch
        {
                {
                    Title = "Not Found",
                    Detail = "Нету данных",
                    Status = 404
                {
                    Title = "Bad Request",
                    Detail = "Неправильный запрос",
                    Status = 400
                {
                    Title = "Unauthorized",
                    Detail = "Не авторизован",
                    Status = 401
                {
                    Title = "Forbidden",
                    Detail = "Доступ запрещён",
                    Status = 403
                {
                    Title = "Conflict",
                    Detail = "Конфликт данных",
                    Status = 409
                {
                    Title = "Validation Error",
                    Detail = "Ошибка валидации",
                    Status = 422
                {
                    Title = "Unprocessable Entity",
                    Detail = "Невозможно обработать сущность",
                    Status = 422
                {
                    Title = "Too Many Requests",
                    Detail = "Слишком много запросов",
                    Status = 429
                {
                    Title = "Service Unavailable",
                    Detail = "Сервис недоступен",
                    Status = 503
                {
                    Title = "Internal Server Error",
                    Detail = "Внутренняя ошибка сервера",
                    Status = 500
                {
                    Title = "Error",
                    Detail = "Неизвестная ошибка",
                    Status = 500
            }
                };
                break;
        }

        return StatusCode(problemDetails.Status ?? 500, problemDetails);
    }


}
