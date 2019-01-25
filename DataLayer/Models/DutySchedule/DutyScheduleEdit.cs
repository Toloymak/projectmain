using System;
using System.Collections.Generic;

namespace DataLayer.Models.DutySchedule
{
    public class DutyScheduleEdit:EditBase
    {
        public DutySchedule DutySchedule { get; set; }

        public DutyScheduleEdit(DutySchedule dutySchedule)
        {
            DutySchedule = dutySchedule;
        }
        
        public string Update()
        {
            if (CheckValues() != null) return CheckValues();
            
            try
            {
                if(IsOnlyOneDutyId(DutySchedule.DutyScheduleId)) Edit();
                else Create();
                return null;
            }
            catch
            {
                return "Не удалось изменить запись";
            }
        }

        private string CheckValues()
        {
            var resultString = "";
            

            if (DutySchedule.PersonId is 0)
                resultString = "дежурного";
            if (DutySchedule.BeginDate == DateTime.MinValue)
                resultString = resultString == "" ? "дату начала" : $"{resultString}, дату начала";
            if (DutySchedule.EndDate == DateTime.MinValue)
                resultString = resultString == "" ? "дату окончания" : $"{resultString}, дату окончания";

            return resultString == "" ? null: $"Необходимо указать: {resultString}";
        }

        private void Create()
        {
            dbContext.DutySchedule.Add(DutySchedule);
            dbContext.SaveChanges();
        }

        private void Edit()
        {
            // Todo: В работе
        }
    }
}