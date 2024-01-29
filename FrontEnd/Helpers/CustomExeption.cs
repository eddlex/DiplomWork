
using System.Data.SqlClient;

namespace FrontEnd.Helpers;

public class AlertException : System.Exception
{
    public AlertException(Constants.Error error) : base(error.Text)
    {
    }

    public AlertException(string msg) : base(msg)
    {
    }
    
    public AlertException(System.Exception e) : base(e.Message)
    {
    }

}

public static class Exception
{
    // public static AlertException Create(int code)
    // {
    //     if (Constants.Errors != null && Constants.Errors.TryGetValue(code, out var error))
    //     {
    //         return new AlertException(error.Text);
    //     }
    //     return new AlertException("un");
    // }
    
    public static AlertException Create(SqlException e)
    {
        if (Constants.Errors != null && Constants.Errors.TryGetValue(e.Number, out var error))
        {
            return new AlertException(error.Text);
        }
        return new AlertException(e);
    }
        
    public static AlertException Create(string message)
    {
        return new AlertException(message);
    }
        
    public static AlertException Create(Constants.Error error)
    {
        return new AlertException(error);
    }
}


