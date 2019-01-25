using System;
using System.Collections.Generic;
using System.Linq;
using DataLayer;
using DataLayer.Models.DutySchedule;

namespace Web.Models.Duty
{
    public class ScheduleModel
    {
        private MainDbContext dbContext = new MainDbContext();
        
        public List<DutySchedule> DutyScheduleList { get; set; }

        public ScheduleModel()
        {
            DutyScheduleList = GetSchedule();
        }

        private List<DutySchedule> GetSchedule() => 
            dbContext.DutySchedule.OrderByDescending(d=>d.BeginDate).Take(25).ToList();

        public string GetPersonName(int id) => 
            dbContext.Person.Where(x => x.PersonId == id).Select(x => x.Name).First();

        public bool IsActual(DateTime beginDate, DateTime endDate) => 
            beginDate <= DateTime.Now && endDate >= DateTime.Now;


        public DutyState CheckActual(DateTime beginDate, DateTime endDate)
        {
            if (endDate < DateTime.Now) return DutyState.Old;
            if (beginDate > DateTime.Now) return DutyState.Feature;
            return DutyState.Current;
        }
        
        public enum DutyState
        {
            Feature = 0,
            Current = 1,
            Old = 2
        }
    }
}