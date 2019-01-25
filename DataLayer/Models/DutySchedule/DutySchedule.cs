using System;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models.DutySchedule
{
    public class DutySchedule
    {
        [Key]
        public int DutyScheduleId { get; set; }
        public int PersonId { get; set; }

        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}