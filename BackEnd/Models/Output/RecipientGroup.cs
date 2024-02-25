namespace BackEnd.Models.Output
{
    public class RecipientGroup
    {
        public int Id             { get; set; }
        public string Name        { get; set; }
        public string Description { get; set; }
        public int    DepartmentId{ get; set; }
    }
}
