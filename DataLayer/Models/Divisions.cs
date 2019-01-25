using System.ComponentModel.DataAnnotations;

namespace DataLayer.Tables
{
    public class Divisions
    {
        [Key]
        public int DivisionId { get; set; }
        
        public string Title { get; set; }
    }
}