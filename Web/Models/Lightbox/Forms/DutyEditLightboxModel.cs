using System.Collections.Generic;
using System.Linq;
using DataLayer;
using DataLayer.Models.DutySchedule;
using DataLayer.Models.Person;

namespace Web.Models.Lightbox.Forms
{
    public class DutyEditLightboxModel
    {
        private MainDbContext dbContext = new MainDbContext();
        public List<Person> PersonList { get; }
        public DutySchedule Duty { get; }
        
        public DutyEditLightboxModel()
        {
            PersonList = GetPersonList();
        }

        private List<Person> GetPersonList() => 
            dbContext.Person.ToList();
    }
}