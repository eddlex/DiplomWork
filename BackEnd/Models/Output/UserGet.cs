using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models.Output
{
    public class UserGet
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string DepartmentId { get; set; }
        public string RoleId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }
        
    }
}
