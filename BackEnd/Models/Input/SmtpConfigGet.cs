using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models.Input
{
    public class SmtpConfigGet
    {
        //[Required]
        public int Id { get; set; }
        public int UniversityId { get; }
    }
}
