
namespace job_helper_api.Exceptions;

public class NotFoundException : Exception
{
    private string message;
    public NotFoundException(string resource, object key)
    {
        message = $"{resource} {key} was not found";
    }

    public string GetMessage()
    {
        return message;
    }
}