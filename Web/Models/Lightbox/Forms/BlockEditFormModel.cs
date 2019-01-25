using System;
using System.Linq;
using DataLayer.Models.Block;

namespace Web.Models.Lightbox.Forms
{
    public class BlockEditFormModel:BaseFormModel
    {
        public Block Block;

        public BlockEditFormModel(int id)
        {
            try
            {
                Block = dbContext.Blocks.First(x => x.BlockId == id);
            }
            catch
            {
                Block = new Block();
            }
        }
    }
}