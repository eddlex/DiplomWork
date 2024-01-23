namespace FrontEnd.Helpers;
public class AlertException : Exception
{
    public AlertException(Constants.Errors error) : base(error.Text)
    {
    }
    
    public AlertException(string msg) : base(msg)
    {
    }
    
} 