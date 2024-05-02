using System.ComponentModel.DataAnnotations;
using FrontEnd.Helpers;

namespace FrontEnd.Model.BL;

    public class RatingBl
    {
        public int FormIdentificationId { get; set; }

        public List<RatingRowBl> RatingRows { get; set; }

        public List<SuggestionRow>?  Suggestions { get; set; }
    }


    public class RatingRowBl
    {
        public int Id { get; set; }
        public int FormRowId { get; set; }
        public decimal Value { get; set; }
    }

    public class SuggestionRow
    {
        public int Id { get; set; }
        public int FormIdentificationId { get; set;}
        public string? Value {  get; set; }
    }
    
    
    
