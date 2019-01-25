using System.Linq;
using DataLayer.Models.Container;
using DataLayer.Resource;

namespace DataLayer.Models.Block
{
    public class BlockEdit : EditBase
    {
        private const string TitleIsEmpty = "Не указан заголовок";
        private const string ColumnIsEmpty = "Не указан столбец";

        public Block Block { get; set; }

        public BlockEdit(Block block)
        {
            Block = block;
        }

        public string Update()
        {
            if (CheckFields() != null) return CheckFields();

            try
            {
                if (IsOnlyOneBlockId(dbContext, Block.BlockId)) Edit();
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
                var currentBlock = dbContext.Blocks
                    .First(x => x.BlockId == Block.BlockId);
                dbContext.Blocks.Remove(currentBlock);
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
            if (Block.Title == "" || Block.Title is null) return TitleIsEmpty;
            if (Block.Column != 1 && Block.Column != 2) return ColumnIsEmpty;
            return null;
        }

        private void Create()
        {
            dbContext.Blocks.Add(Block);
            dbContext.SaveChanges();
        }

        private void Edit()
        {
            var selectedBlock = dbContext.Blocks
                .First(x => x.BlockId == Block.BlockId);

            selectedBlock.Column = Block.Column;
            selectedBlock.Title = Block.Title;
            selectedBlock.Priority = Block.Priority;

            dbContext.SaveChanges();
        }
        
        public static bool IsOnlyOneBlockId(MainDbContext context, int id)
        {
            return context
                       .Blocks
                       .Count(x => x.BlockId == id) == 1;
        }
    }
}