namespace FrontEnd.Helpers;
public static class Constants
{
    public sealed class Errors
    {
        public static readonly Errors SomethingWrong = new Errors(nameof(SomethingWrong), 0, "Something Wrong");
        public static readonly Errors TokenNotFound = new Errors(nameof(TokenNotFound), 1, "Token Not Found");
        public static readonly Errors WrongPassordOrUserName = new Errors(nameof(TokenNotFound), 2, "UserName or password is wrong");
        
        public string Text { get; private set; }
        public string UniqueName { get; private set; }
        public int Code { get; private set; }
        private Errors(string uniqueName, int code, string text) 
        {
            this.UniqueName = uniqueName;
            this.Code = code;
            this.Text = text;
        }
    }
    
   
}