using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Model;

public class Recipient
{ 
    public int Id { get; set; }
    [Required(ErrorMessage = "test error")]
    public string Name { get; set; }
    public string Mail { get; set; }
    public int GroupId { get; set; }
    public int UniversityId { get; set; }
    public string Description { get; set; }
    
}