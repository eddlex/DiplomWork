namespace FrontEnd.Helpers;
public static class Constants
{
    public static Dictionary<int, Error>? Errors { get; set; }

    static Constants()
    {
        Errors ??= new();
        Errors.Add(Error.UserNameExists.Code, Error.UserNameExists);
        Errors.Add(Error.EmailNameExists.Code, Error.EmailNameExists);
        Errors.Add(Error.SomethingWrong.Code, Error.SomethingWrong);
        Errors.Add(Error.TokenNotFound.Code, Error.TokenNotFound);
        Errors.Add(Error.WrongPasswordOrUserName.Code, Error.WrongPasswordOrUserName);
        Errors.Add(Error.BackEnd.Code, Error.BackEnd);
        Errors.Add(Error.NotExistAnyUniversity.Code, Error.NotExistAnyUniversity);
        
    }
    public sealed class Error
    {
        public static readonly Error UserNameExists = new Error(nameof(UserNameExists), 50001, "UserName already exists");
        public static readonly Error EmailNameExists = new Error(nameof(EmailNameExists), 50002, "Email already exists");
        
        public static readonly Error SomethingWrong = new Error(nameof(SomethingWrong), 50003, "Something Wrong");
        public static readonly Error TokenNotFound = new Error(nameof(TokenNotFound), 50004, "Token Not Found");
        public static readonly Error WrongPasswordOrUserName = new Error(nameof(WrongPasswordOrUserName), 50005, "UserName or password is wrong");
        public static readonly Error BackEnd = new Error(nameof(BackEnd), 50006, "Api call error");
        public static readonly Error NotExistAnyUniversity = new Error(nameof(NotExistAnyUniversity), 50007, "Not found any university!");
        
        public string Text { get; private set; }
        public string UniqueName { get; private set; }
        public int Code { get; }
        
        private Error(string uniqueName, int code, string text) 
        {
            this.UniqueName = uniqueName;
            this.Code = code;
            this.Text = text;
        }
    }
    
   
}