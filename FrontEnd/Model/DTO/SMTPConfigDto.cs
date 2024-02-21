using System.ComponentModel.DataAnnotations;
using FrontEnd.Helpers;

namespace FrontEnd.Model.DTO;

public class SMTPConfigDto
{ 
    public int Id { get; set; }
    public string? Department { get; set; }
    public string? SmtpServer { get; set; }
    public int Port { get; set; }
    public string? UserName { get; set; }
    public string? Password { get; set; }
    public bool EnableSSL { get; set; }


}