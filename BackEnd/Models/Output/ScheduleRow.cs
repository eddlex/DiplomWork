namespace BackEnd.Models.Output;
public class ScheduleRow
{
        public int Id { get; set; }
        public int ScheduleId { get; set; }
        public int SubjectId { get; set; }
        public decimal CalculatedHours { get; set; }
}