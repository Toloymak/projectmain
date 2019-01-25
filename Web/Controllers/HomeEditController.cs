using System;
using System.Net.Mime;
using DataLayer.Models.Block;
using DataLayer.Models.Container;
using DataLayer.Models.DutySchedule;
using DataLayer.Models.Row;
using Microsoft.AspNetCore.Mvc;
using Web.Models.Edit;

namespace Web.Controllers
{
    public class HomeEditController : Controller
    {
        // GET
        public ViewResult Index()
        {
            var editIndexPage = new HomeEditModel();
            return View(editIndexPage);
        }
            
        [HttpPost]
        public JsonResult UpdateBlock(int blockId, string title, int column, int priority, bool isDelete = false)
        {
            var blockEdit = new BlockEdit(new Block
            {
                BlockId = blockId,
                Title = title,
                Column = column,
                Priority = priority,
                DivisionId = 1
            });
            
            var result = isDelete ? blockEdit.Delete() : blockEdit.Update();;
            return new JsonResult(result);
        }
            
        [HttpPost]
        public JsonResult UpdateContainer(string text, int blockId, int priority, int containerId, bool isDelete = false)
        {
            var containerEdit = new ContainerEdit(new Container()
            {
                BlockId = blockId,
                Text = text,
                Priority = priority,
                ContainerId = containerId,
            });

            var result = isDelete ? containerEdit.Delete() : containerEdit.Update();
            return new JsonResult(result);
        }
           
        [HttpPost]
        public JsonResult UpdateRow(string link, string text, string description, int container, int priority,
            int rowId, bool isDelete = false)
        {
            var rowEdit = new RowEdit(new Row()
            {
                Text = text,
                Link = link,
                Description = description,
                ContainerId = container,
                Priority = priority,
                RowId = rowId,
            });
            
            var result = isDelete ? rowEdit.Delete() : rowEdit.Update();
            return new JsonResult(result);
        }

        public JsonResult UpdateDuty(int personId, DateTime beginDate, DateTime endDate, int dutyScheduleId)
        {
                var dutyEdit = new DutyScheduleEdit(new DutySchedule()
                {
                    DutyScheduleId = dutyScheduleId,
                    PersonId = personId,
                    BeginDate = beginDate,
                    EndDate = endDate,
                });

                var result = dutyEdit.Update();
                return new JsonResult(result);
        }
    }
}