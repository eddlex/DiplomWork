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
        Errors.Add(Error.NotExistAnyDepartment.Code, Error.NotExistAnyDepartment);
        Errors.Add(Error.SessionNotFound.Code, Error.SessionNotFound);
        Errors.Add(Error.WrongPermissions.Code, Error.WrongPermissions);
        Errors.Add(Error.Injection.Code, Error.Injection);
        Errors.Add(Error.CantDeleteRecipientGroup.Code, Error.CantDeleteRecipientGroup);
        Errors.Add(Error.SubjectNotExist.Code, Error.SubjectNotExist);
        Errors.Add(Error.NotExistAnyWeight.Code, Error.NotExistAnyWeight);
        Errors.Add(Error.CantDeleteWeight.Code, Error.CantDeleteWeight);
        Errors.Add(Error.SimilarsNotFound.Code, Error.SimilarsNotFound);


    }
    public sealed class Error
    {
        public static readonly Error UserNameExists = new Error(nameof(UserNameExists), 50001, "UserName already exists");
        public static readonly Error EmailNameExists = new Error(nameof(EmailNameExists), 50002, "Email already exists");
        
        public static readonly Error SomethingWrong = new Error(nameof(SomethingWrong), 50003, "Something Wrong");
        public static readonly Error TokenNotFound = new Error(nameof(TokenNotFound), 50004, "Token Not Found");
        public static readonly Error WrongPasswordOrUserName = new Error(nameof(WrongPasswordOrUserName), 50005, "UserName or password is wrong");
        public static readonly Error BackEnd = new Error(nameof(BackEnd), 50006, "Api call error");
        public static readonly Error NotExistAnyDepartment = new Error(nameof(NotExistAnyDepartment), 50007, "Not found any department!");
        public static readonly Error SessionNotFound = new Error(nameof(SessionNotFound), 50008, "Session Not Found");
        public static readonly Error WrongPermissions = new Error(nameof(WrongPermissions), 50009, "Permission Error");
        public static readonly Error Injection = new Error(nameof(Injection), 50010, "Dependencies Injection Error");
        public static readonly Error CantDeleteRecipientGroup = new Error(nameof(CantDeleteRecipientGroup), 50011, "Exists Recipient which use this group");
        public static readonly Error SubjectNotExist = new Error(nameof(SubjectNotExist), 50012, "Subject Not Exist");
        public static readonly Error NotExistAnyWeight = new Error(nameof(NotExistAnyWeight), 50013, "Not found any weight!");
        public static readonly Error CantDeleteWeight = new Error(nameof(CantDeleteWeight), 50014, "Exists Recipient that uses this weight");
        public static readonly Error SimilarsNotFound = new Error(nameof(SimilarsNotFound), 50015, "Նմանատիպ տողեր չեն գտնվել");




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
    
    
      public sealed class Success
    {
        public static readonly Success FormSubmit = new Success(nameof(FormSubmit), 0, "Form successfully sent");
        public static readonly Success ModelTrain = new Success(nameof(ModelTrain), 0, "Model has been successfully trained");
        public static readonly Success ModelEval = new Success(nameof(ModelEval), 0, "Hours have been successfully evaluated");
        public static readonly Success QuerySuccess = new Success(nameof(QuerySuccess), 0, "հարցումը հաջողությամբ մշակված է");

        public string Text { get; private set; }
        public string UniqueName { get; private set; }
        public int Code { get; }
        
        private Success(string uniqueName, int code, string text) 
        {
            this.UniqueName = uniqueName;
            this.Code = code;
            this.Text = text;
        }
    }
    
   
}