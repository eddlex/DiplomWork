using BackEnd.Services.Db;

namespace BackEnd.Services.Form
{
    public class FormService
    {
        private readonly DbService dbService;
        public FormService(IDbService dbService)
        {
            this.dbService = (DbService)dbService;
        }

        public GetForms()
        {

        }

    }
}
