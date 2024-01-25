
using FrontEnd.Interface;
using FrontEnd.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;


namespace FrontEnd.Pages;

public class Element
{
    public int UserId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string UniversityId { get; set; }
    public string Phone { get; set; }
    public string Role { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime UpdateDate { get; set; }
}