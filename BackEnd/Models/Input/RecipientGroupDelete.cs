﻿namespace BackEnd.Models.Input
{
    public class RecipientGroupDelete
    {
        public int     Id           { get; set; }
        public string? Name         { get; set; }
        public int     DepartmentId { get; set; }
        public string? Description  { get; set; }
    }
}