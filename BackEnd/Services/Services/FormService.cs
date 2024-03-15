using BackEnd.Services.Db;
using System.Data;
using BackEnd.Helpers;
using BackEnd.Models.Input;
using BackEnd.Models.Input.Post;
using BackEnd.Models.Output;
using BackEnd.Services.Interfaces;
using FrontEnd.Helpers;
using MudBlazor;

namespace BackEnd.Services.Services
{
    public class FormService : IFormService
    {
        private readonly DbService dbService;
        public (int UserId, int DepartmentId, int RoleId) Token { get; set; }
        public FormService(IDbService dbService,
                           IHttpContextAccessor httpContextAccessor)
        {
            this.dbService = (DbService)dbService;
            if (httpContextAccessor.HttpContext != null)
                this.Token = httpContextAccessor.HttpContext.User.ParseToken();
        }

        // public async Task<List<Form>> GetForms(int? GroupId = null)
        // {
        //     var cmd = dbService.CreateCommand();
        //     cmd.CommandType = CommandType.StoredProcedure;
        //     cmd.CommandText = "spGetForms";
        //
        //     cmd.Parameters.AddWithValue("GroupId", GroupId);
        //
        //     using var reader = await cmd.ExecuteReaderAsync();
        //     var result = new List<Form>();
        //     if (reader.HasRows)
        //     {
        //
        //         var dicOrdinals = new Dictionary<string, int>()
        //         {
        //             { nameof(Form.Id),  reader.GetOrdinal(nameof(Form.Id))},
        //             { nameof(Form.GroupId), reader.GetOrdinal(nameof(Form.GroupId))},
        //             { "Row" +  nameof(FormRow.Id),  reader.GetOrdinal("Row" +  nameof(FormRow.Id))},
        //             { "Row" +  nameof(FormRow.Name),  reader.GetOrdinal("Row" +  nameof(FormRow.Name))},
        //             { "Row" +  nameof(FormRow.Value),  reader.GetOrdinal("Row" +  nameof(FormRow.Value))},
        //         };
        //
        //         while (reader.Read())
        //         {
        //             var formId = reader.GetInt32(dicOrdinals[nameof(Form.Id)]);
        //
        //             if (!result.Any(p => p.Id == formId))
        //             {
        //                 result.Add(new Form()
        //                 {
        //                     Id = formId,
        //                     GroupId = reader.GetInt32(dicOrdinals[nameof(Form.GroupId)]),
        //                     Rows = new()
        //                 });
        //             }
        //
        //             var item = result.Where(p => p.Id == formId).FirstOrDefault();
        //
        //             item?.Rows.Add(new FormRow()
        //             {
        //                 Id = reader.GetInt32(dicOrdinals["Row" + nameof(FormRow.Id)]),
        //                 Name = reader.GetString(dicOrdinals["Row" + nameof(FormRow.Name)]),
        //                 Value = reader.GetInt32(dicOrdinals["Row" + nameof(FormRow.Value)])
        //             });
        //         }
        //     }
        //     return result;
        // }


        public async Task<List<Form>> GetForms()
        {
            var result = (await this.dbService.QueryAsync<Form>("spGetForms",
            new {
                Token.RoleId,
                Token.DepartmentId
            })).ToList();
            return result;
        }

        public async Task<Form> AddForm(FormPost model)
        {
            var department = (int?)model?.GetType()?.GetProperty("DepartmentId")?.GetValue(model);
            if (Token.RoleId == 0 ||
                Token.RoleId == 1 && Token.DepartmentId != department)
                throw Alert.Create(Constants.Error.WrongPermissions);

            var result = (await this.dbService.QueryAsync<Form>("spAddForm", model)).FirstOrDefault();
            if (result is null)
                throw Alert.Create(Constants.Error.SomethingWrong);
            return result;
        }
        
        
        public async Task<int> DeleteForm(FormDelete model)
        {
            var department = (int?)model?.GetType()?.GetProperty("DepartmentId")?.GetValue(model);
            if (Token.RoleId == 0 ||
                Token.RoleId == 1 && Token.DepartmentId != department)
                throw Alert.Create(Constants.Error.WrongPermissions);

            var result = (await this.dbService.QueryAsync<int?>("spDeleteForm", new{model?.Id})).FirstOrDefault();
            if (result is null)
                throw Alert.Create(Constants.Error.SomethingWrong);
            return result.Value;
        }

        public async Task<Form> EditForm(FormPut model)
        {
            var department = (int?)model?.GetType()?.GetProperty("DepartmentId")?.GetValue(model);
            if (Token.RoleId == 0 ||
                Token.RoleId == 1 && Token.DepartmentId != department)
                throw Alert.Create(Constants.Error.WrongPermissions);
            
            var result = (await this.dbService.QueryAsync<Form?>("spEditForm", model)).FirstOrDefault();
            if (result is null)
                throw Alert.Create(Constants.Error.SomethingWrong);
            return result;
        }

        public async Task<List<FormRow?>> GetFormRows(int id)
        {
            var result = await this.dbService.QueryAsync<FormRow>("spGetFormRows", new {id});
            return result.ToList();
        }
        
        public async Task<int> DeleteFormRow(FormRowDelete model)
        {
            var result = (await this.dbService.QueryAsync<int?>("spDeleteFormRow", new {model.Id})).FirstOrDefault();
            if (result is null)
                throw Alert.Create(Constants.Error.SomethingWrong);
                
            return result.Value;
        }
        
        public async Task<FormRow> AddFormRow(FormRowPost model)
        {
            var result = (await this.dbService.QueryAsync<FormRow>("spAddFormRow", model)).FirstOrDefault();
            if (result is null)
                throw Alert.Create(Constants.Error.SomethingWrong);
                
            return result;
        }



        public async Task<Guid> AddFormIdentification(FormIdentificationPost model)
        {
            var result = (await this.dbService.QueryAsync<Guid?>("spAddFormIdentification", model)).FirstOrDefault();
            if (result is null)
                throw Alert.Create(Constants.Error.SomethingWrong);
            return result.Value;
        }
    }
}
