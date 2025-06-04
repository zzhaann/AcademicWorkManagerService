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
                    Detail = "Нету данных",
                    Status = 404
                };
                break;
            case ErrorCode.BadRequest:
                problemDetails = new ProblemDetails
                {
                    Title = "Bad Request",
                    Detail = "Неправильный запрос",
                    Status = 400
                };
                break;
            case ErrorCode.Unauthorized:
                problemDetails = new ProblemDetails
                {
                    Title = "Unauthorized",
                    Detail = "Не авторизован",
                    Status = 401
                };
                break;
            case ErrorCode.Forbidden:
                problemDetails = new ProblemDetails
                {
                    Title = "Forbidden",
                    Detail = "Доступ запрещён",
                    Status = 403
                };
                break;
            case ErrorCode.Conflict:
                problemDetails = new ProblemDetails
                {
                    Title = "Conflict",
                    Detail = "Конфликт данных",
                    Status = 409
                };
                break;
            case ErrorCode.Validation:
                problemDetails = new ProblemDetails
                {
                    Title = "Validation Error",
                    Detail = "Ошибка валидации",
                    Status = 422
                };
                break;
            case ErrorCode.UnprocessableEntity:
                problemDetails = new ProblemDetails
                {
                    Title = "Unprocessable Entity",
                    Detail = "Невозможно обработать сущность",
                    Status = 422
                };
                break;
            case ErrorCode.TooManyRequests:
                problemDetails = new ProblemDetails
                {
                    Title = "Too Many Requests",
                    Detail = "Слишком много запросов",
                    Status = 429
                };
                break;
            case ErrorCode.ServiceUnavailable:
                problemDetails = new ProblemDetails
                {
                    Title = "Service Unavailable",
                    Detail = "Сервис недоступен",
                    Status = 503
                };
                break;
            case ErrorCode.InternalServerError:
                problemDetails = new ProblemDetails
                {
                    Title = "Internal Server Error",
                    Detail = "Внутренняя ошибка сервера",
                    Status = 500
                };
                break;
            default:
                problemDetails = new ProblemDetails
                {
                    Title = "Error",
                    Detail = "Неизвестная ошибка",
                    Status = 500
                };
                break;
        }

        return StatusCode(problemDetails.Status ?? 500, problemDetails);
    }


}
