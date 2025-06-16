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
        ProblemDetails problemDetails;

        switch (error.Code)
        {
            case ErrorCode.NotFound:
                problemDetails = new ProblemDetails
                {
                    Title = "Not Found",
                    Detail = error.Message ?? "Нет данных",
                    Status = 404
                };
                break;
            case ErrorCode.BadRequest:
                problemDetails = new ProblemDetails
                {
                    Title = "Bad Request",
                    Detail = error.Message ?? "Неправильный запрос",
                    Status = 400
                };
                break;
            case ErrorCode.Unauthorized:
                problemDetails = new ProblemDetails
                {
                    Title = "Unauthorized",
                    Detail = error.Message ?? "Не авторизован",
                    Status = 401
                };
                break;
            case ErrorCode.Forbidden:
                problemDetails = new ProblemDetails
                {
                    Title = "Forbidden",
                    Detail = error.Message ?? "Доступ запрещён",
                    Status = 403
                };
                break;
            case ErrorCode.Conflict:
                problemDetails = new ProblemDetails
                {
                    Title = "Conflict",
                    Detail = error.Message ?? "Конфликт данных",
                    Status = 409
                };
                break;
            case ErrorCode.Validation:
                problemDetails = new ProblemDetails
                {
                    Title = "Validation Error",
                    Detail = error.Message ?? "Ошибка валидации",
                    Status = 422
                };
                break;
            case ErrorCode.UnprocessableEntity:
                problemDetails = new ProblemDetails
                {
                    Title = "Unprocessable Entity",
                    Detail = error.Message ?? "Невозможно обработать сущность",
                    Status = 422
                };
                break;
            case ErrorCode.TooManyRequests:
                problemDetails = new ProblemDetails
                {
                    Title = "Too Many Requests",
                    Detail = error.Message ?? "Слишком много запросов",
                    Status = 429
                };
                break;
            case ErrorCode.ServiceUnavailable:
                problemDetails = new ProblemDetails
                {
                    Title = "Service Unavailable",
                    Detail = error.Message ?? "Сервис недоступен",
                    Status = 503
                };
                break;
            case ErrorCode.InternalServerError:
                problemDetails = new ProblemDetails
                {
                    Title = "Internal Server Error",
                    Detail = error.Message ?? "Внутренняя ошибка сервера",
                    Status = 500
                };
                break;
            default:
                problemDetails = new ProblemDetails
                {
                    Title = "Error",
                    Detail = error.Message ?? "Неизвестная ошибка",
                    Status = 500
                };
                break;
        }

        return StatusCode(problemDetails.Status ?? 500, problemDetails);
    }



}
