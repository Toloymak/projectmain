using System.Linq;

namespace DataLayer.Models
{
    public class EditBase
    {
        protected MainDbContext dbContext = new MainDbContext();
        
        protected bool IsOnlyOneDutyId(int id) => dbContext
                       .DutySchedule.Count(x => x.DutyScheduleId == id) == 1;
        
    }
}