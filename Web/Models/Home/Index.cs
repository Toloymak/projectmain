using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using DataLayer;
using DataLayer.Models.Block;
using DataLayer.Models.Container;
using DataLayer.Models.Row;
using DataLayer.Tables;
using Web.Models.Edit;
using Web.Models.Lightbox;

namespace Web.Models.Home
{
    public class Index
    {
        private MainDbContext dbContext = new MainDbContext();

        public List<Block> GetBlocks(int column)
        {
            return dbContext.Blocks
                .Where(x => x.Column == column)
                .Where(block=> 0 != dbContext.Containers
                                   .Count(container => container.BlockId == block.BlockId))
                .OrderBy(e=>e.Priority)
                .ToList();
        }

        public List<Container> GetContainerses(int blockId)
        {
            
            return dbContext.Containers
                .Where(x => x.BlockId == blockId)
                .Where(container => 0 != dbContext.Rows
                                        .Count(row => row.ContainerId == container.ContainerId))
                .OrderBy(e=>e.Priority)
                .ToList();
        }

        public List<Row> GetRows(int containerId)
        {
            return dbContext.Rows
                .Where(x => x.ContainerId == containerId)
                .OrderBy(e=>e.Priority)
                .ToList();
        }
        
        public string GetLinkText(Row row)
        {
            return string.IsNullOrEmpty(row.Text) ? row.Link : row.Text;
        }

        public string GetColumnClass(int column)
        {
            return column == 0 ? "left" : "right";
        }
        
        //public EditLightboxModel GetEditLightboxModel(FormModel.Type formType)
        //{
        //    return new EditLightboxModel {FormModel = new FormModel {FormType = formType}};
        //}
        
    }
}