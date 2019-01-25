using System.Linq;
using DataLayer.Models.Block;
using DataLayer.Resource;

namespace DataLayer.Models.Container
{
    public class ContainerEdit:EditBase
    {
        public Container Container { get; set; }

        public ContainerEdit(Container container)
        {
            Container = container;
        }
        
        public string Update()
        {
            if (!BlockEdit.IsOnlyOneBlockId(dbContext, Container.BlockId)) return $"BlockId {Messages.NotUnique}";

            try
            {
                if(IsOnlyOneContainerId(dbContext, Container.ContainerId)) Edit();
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
                var currentContainers = dbContext.Containers
                    .First(x => x.ContainerId == Container.ContainerId);
                dbContext.Containers.Remove(currentContainers);
                dbContext.SaveChanges();
                return null;
            }
            catch
            {
                return Messages.DeleteFail;
            }
        }

        private void Edit()
        {
            var currentContainer = dbContext.Containers
                .First(x => x.ContainerId == Container.ContainerId);
            currentContainer.BlockId = Container.BlockId;
            currentContainer.Text = Container.Text;
            currentContainer.Priority = Container.Priority;
                
            dbContext.SaveChanges();
        }
        
        
        private void Create()
        {
            dbContext.Containers.Add(Container);
            dbContext.SaveChanges();
        }
        
        public static bool IsOnlyOneContainerId(MainDbContext context, int id)
        {
            return context.Containers
                       .Count(x => x.ContainerId == id) == 1;
        }
    }
}