using System.Collections.Generic;
using System.Linq;
using DataLayer.Models.Block;
using DataLayer.Models.Container;

namespace Web.Models.Lightbox.Forms
{
    public class ContainerEditFormModel:BaseFormModel
    {
        public Container Container;

        public ContainerEditFormModel(int id)
        {
            try
            {
                Container = dbContext.Containers.First(x => x.ContainerId == id);
            }
            catch
            {
                Container = new Container();
            }
        }
        
        public IList<Block> GetBlocksList()
        {
            return dbContext.Blocks.ToList();
        }
    }
}