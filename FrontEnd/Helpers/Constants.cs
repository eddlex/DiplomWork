namespace FrontEnd.Helpers;
public static class Constants
{
    public sealed class Errors
    {
        public static readonly Errors UserNameExists = new Errors(nameof(UserNameExists), 50001, "UserName already exists");
        public static readonly Errors EmailNameExists = new Errors(nameof(UserNameExists), 50002, "Email already exists");
        
        public static readonly Errors SomethingWrong = new Errors(nameof(SomethingWrong), 50003, "Something Wrong");
        public static readonly Errors TokenNotFound = new Errors(nameof(TokenNotFound), 50004, "Token Not Found");
        public static readonly Errors WrongPasswordOrUserName = new Errors(nameof(TokenNotFound), 50004, "UserName or password is wrong");
        
        public string Text { get; private set; }
        public string UniqueName { get; private set; }
        private int Code { get; }



        private static Dictionary<int, Errors> _errors = new();

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
            _errors.Add(this.Code, this);
        }
    }
    
   
}