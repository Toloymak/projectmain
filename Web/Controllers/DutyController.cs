using System;
using DataLayer.Models.DutySchedule;
using Microsoft.AspNetCore.Mvc;
using Web.Models.Duty;
using Web.Models.Lightbox.Forms;

namespace Web.Controllers
{
    public class DutyController: Controller
    {
        public ViewResult Schedule()
        {
            return View(new ScheduleModel());
        }
    }
}