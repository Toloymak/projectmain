using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models.Block
{
    public class Block
    {
        [Key]
        public int BlockId { get; set; }
        
        public int DivisionId { get; set; }
        public string Title { get; set; }
        public int Column { get; set; }
        public int Priority { get; set; }

    }
}