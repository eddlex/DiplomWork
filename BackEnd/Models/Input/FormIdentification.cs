﻿namespace BackEnd.Models.Input
{
    public class FormIdentificationPost
    {
        public int FormId { get; set; }
        public int GroupId { get; set; }
        public int RecipientId { get; set; }
        public DateTime ExpirationTime { get; set; }
    }
}