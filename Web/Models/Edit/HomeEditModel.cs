using System.Collections.Generic;
using System.Linq;
using DataLayer;
using DataLayer.Models.Block;
using DataLayer.Models.Container;
using DataLayer.Models.Row;
using DataLayer.Tables;
using Web.Models.Lightbox;

namespace Web.Models.Edit
{
    public class HomeEditModel
    {
        private MainDbContext mainDbContext = new MainDbContext();
        
        public List<Block> GetBlocks()
        {
            return mainDbContext.Blocks.ToList();
        }

        public List<Container> GetContainers(int blockId)
        {
            return mainDbContext.Containers.Where(x => x.BlockId == blockId).ToList();
        }

        public List<Row> GetRows(int containerId)
        {
            return mainDbContext.Rows.Where(x => x.ContainerId == containerId).ToList();
        }
    }
}