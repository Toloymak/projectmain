using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models.Row
{
    public class Row
    {
        [Key]
        public int RowId { get; set; }
        
        public int ContainerId { get; set; }
        public string Link { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
    }
}