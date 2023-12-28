namespace ClientAPI.Errors;

public class AuthException : Exception
{
    public override string Message { get; }
    public AuthException(string message)
    {
        Message = message;
    }
}