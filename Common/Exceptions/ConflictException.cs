
namespace job_helper_api.Common.Exceptions;

public class ConflictException : Exception
{
    public ConflictException(string Message) : base(Message)
    {
    }
}