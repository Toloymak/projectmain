using System.Linq;
using DataLayer.Models.Container;
using DataLayer.Resource;

namespace DataLayer.Models.Row
{
    public class RowEdit : EditBase
    {
        public Row Row { get; set; }
        private const string fieldIsEmpty = "Укажите ссылку, описание или текст";

        public RowEdit(Row row)
        {
            Row = row;
        }
        
        public string Update()
        {
            if (CheckFields() != null) return CheckFields();

            try
            {
                if(IsOnlyOneRowId(dbContext, Row.RowId)) Edit();
                else Create();
                return null;
            }
            catch
            {
                return Messages.EditFail;
            }
        }
        
        public string Delete()
        {
            try
            {
                var currentContainers = dbContext.Rows
                    .First(x => x.RowId == Row.RowId);
                
                dbContext.Rows.Remove(currentContainers);
                dbContext.SaveChanges();
                
                return null;
            }
            catch
            {
                return Messages.DeleteFail;
            }
        }

        private string CheckFields()
        {
            if (!ContainerEdit.IsOnlyOneContainerId(dbContext, Row.ContainerId)) return $"ContainerId {Messages.NotUnique}";
            if (Row.Text is null && Row.Link is null && Row.Description is null) return fieldIsEmpty;
            return null;
        }

        private void Edit()
        {
            var currentContainer = dbContext.Rows
                .First(x => x.RowId == Row.RowId);
            currentContainer.Text = Row.Text;
            currentContainer.Link = Row.Link;
            currentContainer.Description = Row.Description;
            currentContainer.ContainerId = Row.ContainerId;
            currentContainer.Priority = Row.Priority;

            dbContext.SaveChanges();
        }

        private void Create()
        {
            dbContext.Rows.Add(Row);
            dbContext.SaveChanges();
        }
        
        public static bool IsOnlyOneRowId(MainDbContext context, int id)
        {
            return context.Rows
                       .Count(x => x.RowId == id) == 1;
        }

    }
}