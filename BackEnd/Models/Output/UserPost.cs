using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models.Output
{
    public class UserPost
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int DepartmentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public bool EmailIsVerified { get; set; }
        public bool PhoneIsVerified { get; set; }
        public int RoleId { get; set; }

    }
}
