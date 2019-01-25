using System.Collections.Generic;
using System.Linq;
using DataLayer.Models.Container;
using DataLayer.Models.Row;

namespace Web.Models.Lightbox.Forms
{
    public class RowEditModel : BaseFormModel
    {
        public Row Row;

        
        public RowEditModel(int id)
        {
            try
            {
                Row = dbContext.Rows.First(x => x.RowId == id);
            }
            catch
            {
                Row = new Row();
            }
        }
        
        public IList<Container> GetContainersList()
        {
            return dbContext.Containers.ToList();
        }

        public string GetBlockName(int blockId)
        {
            return dbContext.Blocks.First(x=> x.BlockId == blockId).Title;
        }
    }
}