﻿namespace BackEnd.Models.Output
{
    public class Recipient
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Mail { get; set; }
        public int DepartmentId { get; set; }
        public int GroupId { get; set; }
        public string? Description { get; set; }
        public int WeightId { get; set; }
    }
}
