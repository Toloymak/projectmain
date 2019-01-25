using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models.Person
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string StaffId { get; set; }
        public int Role { get; set; }
        public int IsDuty { get; set; }
    }
}