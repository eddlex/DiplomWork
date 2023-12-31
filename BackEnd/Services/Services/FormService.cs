﻿using BackEnd.Services.Db;
using System.Data;
using BackEnd.Models.Output;
using BackEnd.Services.Interfaces;

namespace BackEnd.Services.Services
{
    public class FormService : IFormService
    {
        private readonly DbService dbService;
        public FormService(IDbService dbService)
        {
            this.dbService = (DbService)dbService;
        }

        public async Task<List<Form>> GetForms(int? GroupId = null)
        {
            var cmd = dbService.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "spGetForms";

            cmd.Parameters.AddWithValue("GroupId", GroupId);

            using var reader = await cmd.ExecuteReaderAsync();
            var result = new List<Form>();
            if (reader.HasRows)
            {

                var dicOrdinals = new Dictionary<string, int>()
                {
                    { nameof(Form.Id),  reader.GetOrdinal(nameof(Form.Id))},
                    { nameof(Form.GroupId), reader.GetOrdinal(nameof(Form.GroupId))},
                    { "Row" +  nameof(FormRow.Id),  reader.GetOrdinal("Row" +  nameof(FormRow.Id))},
                    { "Row" +  nameof(FormRow.Name),  reader.GetOrdinal("Row" +  nameof(FormRow.Name))},
                    { "Row" +  nameof(FormRow.Value),  reader.GetOrdinal("Row" +  nameof(FormRow.Value))},
                };

                while (reader.Read())
                {
                    var formId = reader.GetInt32(dicOrdinals[nameof(Form.Id)]);

                    if (!result.Any(p => p.Id == formId))
                    {
                        result.Add(new Form()
                        {
                            Id = formId,
                            GroupId = reader.GetInt32(dicOrdinals[nameof(Form.GroupId)]),
                            Rows = new()
                        });
                    }

                    var item = result.Where(p => p.Id == formId).FirstOrDefault();

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
