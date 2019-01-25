using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models.Container
{
    public class Container
    {
        [Key]
        public  int ContainerId { get; set; }
        public  int BlockId { get; set; }
        public  string Text { get; set; }
        public int Priority { get; set; }
    }
}