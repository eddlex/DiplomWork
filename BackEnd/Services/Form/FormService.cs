﻿using BackEnd.Services.Db;
using BackEnd.Models;
using BackEnd.Models.Form;
using System.Data;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace BackEnd.Services.Form
{
    public class FormService : IFormService
    {
        private readonly DbService dbService;
        public FormService(IDbService dbService)
        {
            this.dbService = (DbService)dbService;
        }

        public async Task<List<Models.Form.Form>> GetForms(int? GroupId = null)
        {
            var cmd = this.dbService.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "spGetForms";

            cmd.Parameters.AddWithValue("GroupId", GroupId);

            using var reader  = await cmd.ExecuteReaderAsync();
            var result = new List<Models.Form.Form>();
            if (reader.HasRows) 
            {

                var dicOrdinals = new Dictionary<string, int>()
                {
                    { nameof(Models.Form.Form.Id),  reader.GetOrdinal(nameof(Models.Form.Form.Id))},
                    { nameof(Models.Form.Form.GroupId), reader.GetOrdinal(nameof(Models.Form.Form.GroupId))},
                    { "Row" +  nameof(FormRow.Id),  reader.GetOrdinal("Row" +  nameof(FormRow.Id))},
                    { "Row" +  nameof(FormRow.Name),  reader.GetOrdinal("Row" +  nameof(FormRow.Name))},
                    { "Row" +  nameof(FormRow.Value),  reader.GetOrdinal("Row" +  nameof(FormRow.Value))},
                };
      
                while (reader.Read())
                {
                    var formId = reader.GetInt32(dicOrdinals[nameof(Models.Form.Form.Id)]);
                   
                    if (!result.Any(p => p.Id == formId))
                    {
                        result.Add(new Models.Form.Form()
                        {
                            Id = formId,
                            GroupId = reader.GetInt32(dicOrdinals[nameof(Models.Form.Form.GroupId)]),
                            Rows = new()
                        });
                    }

                    var item = (Models.Form.Form)result.Where(p => p.Id == formId).FirstOrDefault();

                    item?.Rows.Add(new FormRow()
                    {
                        Id = reader.GetInt32(dicOrdinals["Row" + nameof(FormRow.Id)]),
                        Name = reader.GetString(dicOrdinals["Row" + nameof(FormRow.Name)]),
                        Value = reader.GetInt32(dicOrdinals["Row" + nameof(FormRow.Value)])
                    }); 
                }
            }
            return result;
        }

        
    }
}
