using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace BackEnd.Models.Output
{
    public class Form
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public string? Name { get; set; }
        public int DepartmentId { get; set; }
        public string? Description { get; set; }
    }

    public class FormRow
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
    }

}
