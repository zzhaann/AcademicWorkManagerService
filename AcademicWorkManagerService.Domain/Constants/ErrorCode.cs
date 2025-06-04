namespace AcademicWorkManagerService.Domain.Constants;

public static class ErrorCode
{
    public const string NotFound = nameof(NotFound);
    public const string BadRequest = nameof(BadRequest);
    public const string Unauthorized = nameof(Unauthorized);
    public const string Forbidden = nameof(Forbidden);
    public const string Conflict = nameof(Conflict);
    public const string InternalServerError = nameof(InternalServerError);
    public const string Validation = nameof(Validation);
    public const string UnprocessableEntity = nameof(UnprocessableEntity);
    public const string TooManyRequests = nameof(TooManyRequests);
    public const string ServiceUnavailable = nameof(ServiceUnavailable);
}
