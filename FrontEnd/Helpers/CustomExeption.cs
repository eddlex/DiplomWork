
using System.Data.SqlClient;
using MudBlazor;

namespace FrontEnd.Helpers;

public interface IExeptionService
{
    public CutomExeption Create(string msg);
    public CutomExeption Create(SqlException e);
    public CutomExeption Create(Constants.Error code);
    public CutomExeption Create(Exception e);
}
public class ExeptionService : IExeptionService
{
    private readonly ISnackbar snackbar;

    public ExeptionService(ISnackbar snackbar)
    {
        this.snackbar = snackbar;
    }

    public CutomExeption Create(string msg)
    {
        snackbar.ShowExeption(msg);
        return Alert.Create(msg);
    }

    public CutomExeption Create(Constants.Error code)
    {
        var error = Alert.Create(code);
        snackbar.ShowExeption(error.Message);
        return error;
    }
    public CutomExeption Create(SqlException e)
    {
        var error = Alert.Create(e);
        snackbar.ShowExeption(error.Message);
        return error;
    }
    
    public CutomExeption Create(Exception e)
    {
        var error = Alert.Create(e);
        snackbar.ShowExeption(error.Message);
        return error;
    }
    
    
    
}
public class CutomExeption : System.Exception
{
    
    public CutomExeption(Constants.Error error) : base(error.Text)
    {
    }

    public CutomExeption(string msg) : base(msg)
    {
    }
    
    public CutomExeption(System.Exception e) : base(e.Message)
    {
    }

}

public static class Alert
{

    public static void ShowExeption(this ISnackbar snackbar, string message)
    {
        snackbar.Configuration.SnackbarVariant = Variant.Filled;   
        snackbar.Configuration.MaxDisplayedSnackbars = 10;
        snackbar.Configuration.PositionClass = Defaults.Classes.Position.BottomEnd;
        snackbar.Configuration.ShowCloseIcon = true;
        snackbar.Add($"Error {message}", Severity.Error);
    }
    
    public static void ShowExeption(this ISnackbar snackbar, Constants.Error message)
    {
        snackbar.Configuration.SnackbarVariant = Variant.Filled;   
        snackbar.Configuration.MaxDisplayedSnackbars = 10;
        snackbar.Configuration.PositionClass = Defaults.Classes.Position.BottomEnd;
        snackbar.Configuration.ShowCloseIcon = true;
        snackbar.Add($"Error {message}", Severity.Error);
    }
    
    
    
    public static void ShowSuccess(this ISnackbar snackbar, string message)
    {
        snackbar.Configuration.SnackbarVariant = Variant.Filled;   
        snackbar.Configuration.MaxDisplayedSnackbars = 10;
        snackbar.Configuration.PositionClass = Defaults.Classes.Position.BottomEnd;
        snackbar.Configuration.ShowCloseIcon = true;
        snackbar.Add($"Error {message}", Severity.Info);
    }
    
    
    public static void ShowSuccess(this ISnackbar snackbar, Constants.Success message)
    {
        snackbar.Configuration.SnackbarVariant = Variant.Filled;   
        snackbar.Configuration.MaxDisplayedSnackbars = 10;
        snackbar.Configuration.PositionClass = Defaults.Classes.Position.BottomEnd;
        snackbar.Configuration.ShowCloseIcon = true;

        snackbar.Add($"Success {message.Text}", Severity.Success);
    }
    
    public static CutomExeption Create(SqlException e)
    {
        if (Constants.Errors != null && Constants.Errors.TryGetValue(e.Number, out var error))
        {
            return new CutomExeption(error.Text);
        }
        return new CutomExeption(e);
    }
    
    public static CutomExeption Create(System.Exception e)
    {
        return new CutomExeption(e);
    }
        
    public static CutomExeption Create(string message)
    {
        return new CutomExeption(message);
    }
        
    public static CutomExeption Create(Constants.Error error)
    {
        return new CutomExeption(error);
    }
}


