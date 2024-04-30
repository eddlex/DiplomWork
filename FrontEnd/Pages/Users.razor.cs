using FrontEnd.Interface;
using FrontEnd.Model;
using Microsoft.AspNetCore.Components;
using FrontEnd.Model.Dialog;
using FrontEnd.Shared.Dialog;
using MudBlazor;
using FrontEnd.Helpers;


namespace FrontEnd.Pages;

public partial class Users
{
    [Inject]
    private IUserService? UserService { get; set; } 
    private List<User?>? GridUsers { get; set;}


    [Inject]
    private IDepartmentService? DepartmentService { get; set; }
    private List<DepartmentBl>? Departments { get; set; }

    protected override async Task OnInitializedAsync()
    {
        if (this.UserService != null &&
            this.DepartmentService != null)
        {
            this.GridUsers = await this.UserService.GetUsers();
            this.Departments = await this.DepartmentService.GetDepartments();
        }
    }

    private async Task DeleteUser(int id)
    {
        if (this.UserService != null && await DialogService.DeleteConfirmationPopUp())
        {
            var result = await this.UserService.DeleteUser(GridUsers.Find(r => r.Id == id));
            if (result.HasValue && this.GridUsers is { Count: > 0 })
            {
                this.GridUsers.Remove(this.GridUsers.First(r => r.Id == id));
            }
        }
    }

    private async Task EditUser(int id)
    {
        if (this.UserService != null)
        {
            var editedRow = this.GridUsers?.Find(r => r.Id == id);
            var user = await OpenDialog(editedRow);
            if (user != default && editedRow != null)
            {
                var result = await this.UserService.EditUser(user);
                if (result != null)
                {
                    this.GridUsers?.Remove(editedRow);
                    this.GridUsers?.Add(result);

                }
            }
        }        
    }

    private async Task<User?> OpenDialog(User? row = default)
    {
        var options = new DialogOptions
        {
            CloseOnEscapeKey = true,
            MaxWidth = MaxWidth.Large,
            Position = DialogPosition.Center,
        };

        var parameters = new DialogParameters<User>();

        var dialog = new UserDialog()
        {
            Department = new Select<DepartmentBl?>("Ամբիոն", "DepartmentId", this.Departments)

        };

        if (row is not null)
        {
            dialog.Department.SelectedValue = row.DepartmentId;
            dialog.UserName = row.UserName;
            dialog.Email = row.Email;
            dialog.RoleId = row.RoleId;
            dialog.CreationDate = row.CreationDate;
            dialog.UpdateDate = row.UpdateDate;

        }

        parameters.Add("ObjectType", dialog);

        var result = await (await DialogService.ShowAsync<DialogComponent<UserDialog>>("Խմբագրել", parameters, options)).Result;
        if (!result.Canceled && dialog.Department.SelectedValue is not null)
        {
            return new User()
            {
                DepartmentId = dialog.Department.SelectedValue.Value,
                UserName = dialog.UserName,
                Email = dialog.Email,
                RoleId = dialog.RoleId,
                CreationDate = dialog.CreationDate,
                UpdateDate =dialog.UpdateDate,
                Id = row?.Id ?? 0
            };
        }

        return default;
    }
}

