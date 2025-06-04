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
            ErrorCode.NotFound => new ProblemDetails
            {
                Title = "Not Found",
                Detail = "Нету данных",
                Status = 404
            },
            ErrorCode.BadRequest => new ProblemDetails
            {
                Title = "Bad Request",
                Detail = "Неправильный запрос",
                Status = 400
            },
            ErrorCode.Unauthorized => new ProblemDetails
            {
                Title = "Unauthorized",
                Detail = "Не авторизован",
                Status = 401
            },
            ErrorCode.Forbidden => new ProblemDetails
            {
                Title = "Forbidden",
                Detail = "Доступ запрещён",
                Status = 403
            },
            ErrorCode.Conflict => new ProblemDetails
            {
                Title = "Conflict",
                Detail = "Конфликт данных",
                Status = 409
            },
            ErrorCode.Validation => new ProblemDetails
            {
                Title = "Validation Error",
                Detail = "Ошибка валидации",
                Status = 422
            },
            ErrorCode.UnprocessableEntity => new ProblemDetails
            {
                Title = "Unprocessable Entity",
                Detail = "Невозможно обработать сущность",
                Status = 422
            },
            ErrorCode.TooManyRequests => new ProblemDetails
            {
                Title = "Too Many Requests",
                Detail = "Слишком много запросов",
                Status = 429
            },
            ErrorCode.ServiceUnavailable => new ProblemDetails
            {
                Title = "Service Unavailable",
                Detail = "Сервис недоступен",
                Status = 503
            },
            ErrorCode.InternalServerError => new ProblemDetails
            {
                Title = "Internal Server Error",
                Detail = "Внутренняя ошибка сервера",
                Status = 500
            },
            _ => new ProblemDetails
            {
                Title = "Error",
                Detail = "Неизвестная ошибка",
                Status = 500
            }
        };

        return StatusCode(problemDetails.Status ?? 500, problemDetails);
    }

}
