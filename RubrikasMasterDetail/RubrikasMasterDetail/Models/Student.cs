namespace RubrikasMasterDetail.Models
{
    public class Student : BaseModel
    {
        private string name;
        private string id;

        public string Name
        {
            get => name;
            set
            {
                if (!string.IsNullOrWhiteSpace(value)) SetProperty(ref name, value);
            }
        }

        public string Id
        {
            get => id;
            set
            {
                if (!string.IsNullOrWhiteSpace(value)) SetProperty(ref id, value);
            }
        }

        public static bool IsValid(Student item)
        {
            return !string.IsNullOrWhiteSpace(item.Name) && 
                   !string.IsNullOrWhiteSpace(item.Id);
        }
    }
}