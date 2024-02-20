
using System.Data.SqlClient;

namespace FrontEnd.Helpers;

public class Exeption : System.Exception 
{
    public Exeption(Constants.Error error) : base(error.Text)
    {
    }

    public Exeption(string msg) : base(msg)
    {
    }
    
    public Exeption(System.Exception e) : base(e.Message)
    {
    }

}

public static class Alert
{
    
    public static Exeption Create(SqlException e)
    {
        if (Constants.Errors != null && Constants.Errors.TryGetValue(e.Number, out var error))
        {
            return new Exeption(error.Text);
        }
        return new Exeption(e);
    }
    
    public static Exeption Create(System.Exception e)
    {
        return new Exeption(e);
    }
        
    public static Exeption Create(string message)
    {
        return new Exeption(message);
    }
        
    public static Exeption Create(Constants.Error error)
    {
        return new Exeption(error);
    }
}


