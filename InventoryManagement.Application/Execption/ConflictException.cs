public class ConflictException : AppException
{
    public ConflictException(string message = "Resource already exists")
        : base(message, 409)
    {
    }
}