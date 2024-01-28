namespace FrontEnd.Helpers;
public static class Constants
{
    private static Dictionary<int, Errors>? _errors;

    static Constants()
    {
        _errors ??= new();
        _errors.Add(Errors.UserNameExists.Code, Errors.UserNameExists);
        _errors.Add(Errors.EmailNameExists.Code, Errors.EmailNameExists);
        _errors.Add(Errors.SomethingWrong.Code, Errors.SomethingWrong);
        _errors.Add(Errors.TokenNotFound.Code, Errors.TokenNotFound);
        _errors.Add(Errors.WrongPasswordOrUserName.Code, Errors.WrongPasswordOrUserName);
        _errors.Add(Errors.BackEnd.Code, Errors.BackEnd);
        
    }
    public sealed class Errors
    {
        public static readonly Errors UserNameExists = new Errors(nameof(UserNameExists), 50001, "UserName already exists");
        public static readonly Errors EmailNameExists = new Errors(nameof(UserNameExists), 50002, "Email already exists");
        
        public static readonly Errors SomethingWrong = new Errors(nameof(SomethingWrong), 50003, "Something Wrong");
        public static readonly Errors TokenNotFound = new Errors(nameof(TokenNotFound), 50004, "Token Not Found");
        public static readonly Errors WrongPasswordOrUserName = new Errors(nameof(WrongPasswordOrUserName), 50005, "UserName or password is wrong");
        public static readonly Errors BackEnd = new Errors(nameof(BackEnd), 50006, "Api call error");
        
        public string Text { get; private set; }
        public string UniqueName { get; private set; }
        public int Code { get; }
        
        

        public static AlertException CreateException(int code)
        {
            
            return new AlertException(_errors[code].Text);
        }
        
        public static AlertException CreateException(string message)
        {
            return new AlertException(message);
        }
        
        private Errors(string uniqueName, int code, string text) 
        {
            this.UniqueName = uniqueName;
            this.Code = code;
            this.Text = text;
        }
    }
    
   
}