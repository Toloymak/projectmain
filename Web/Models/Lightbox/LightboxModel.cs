using DataLayer.Models.Person;
using static Web.Models.Lightbox.LightboxConstants;

namespace Web.Models.Lightbox
{
    public class LightboxModel
    {
        public int Id { get; }
        public bool IsCreate { get; }
        
        public LightboxType.Type Type { get; }
        public string Title { get; }

        private string TypeString;

        public LightboxModel(string type, int id)
        {
            Id = id;
            IsCreate = GetIsCreate();
            
            Type = GetLightboxType(type);
            Title = GetTitle();

            TypeString = GetTypeString(type);
        }

        private string GetTypeString(string type) =>
            (Type == LightboxType.Type.DescriptionRow) ? "row" : type;
        

        private bool GetIsCreate() => Id == 0;
        
        private LightboxType.Type GetLightboxType(string type)
        {
            switch (type.ToLower())
            {
                case "block": return LightboxType.Type.Block;
                case "container": return LightboxType.Type.Container;
                case "row": return LightboxType.Type.Row;
                case "descriptionrow": return LightboxType.Type.DescriptionRow;
                case "duty" : return LightboxType.Type.Duty;
                case "person" : return LightboxType.Type.Person;
                default: return LightboxType.Type.Error;
            }
        }
        
        private string GetTitle()
        {
            if (Type==LightboxType.Type.Block)
                return IsCreate ? NewBlockTitle : EditBlockTitle;
            if (Type==LightboxType.Type.Container)
                return IsCreate ? NewContainerTitle : EditContainerTitle;
            if (Type==LightboxType.Type.Row)
                return IsCreate ? NewRowTitle : EditRowTitle;
            if (Type == LightboxType.Type.DescriptionRow) 
                return DescriptionRowTitle;
            if (Type == LightboxType.Type.Duty)
                return IsCreate ? NewDutyTitle : EditDutyTitle;
            if (Type == LightboxType.Type.Person)
                return IsCreate ? NewPersonTitle : EditPersonTitle;
            
            return ErrorTitle;
        }

        public string GetUpdateUrl() => $"'Update{TypeString}'";
        public string GetDeleteUrl() => $"'Update{TypeString}?isDelete=true'";
    }
}