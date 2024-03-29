﻿using BackEnd.Models.Input;
using BackEnd.Models.Input.Post;
using BackEnd.Models.Output;

namespace BackEnd.Services.Interfaces
{
    public interface IFormService
    {
        Task<List<Form>> GetForms();
        Task<Form> AddForm(FormPost model);
        Task<int> DeleteForm(FormDelete model);
        Task<Form> EditForm(FormPut model);
        
        Task<List<FormRow?>> GetFormRows(int id);
        Task<int> DeleteFormRow(FormRowDelete model);
        Task<FormRow> AddFormRow(FormRowPost model);
        Task<Guid> AddFormIdentification(FormIdentificationPost model);
    }
}
