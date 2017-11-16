namespace RubrikasMasterDetail.Models
{
    internal class Evaluation : BaseModel
    {
        private string description;
        private string name;

        public string Name
        {
            get => name;
            set
            {
                if (!string.IsNullOrWhiteSpace(value)) SetProperty(ref name, value);
            }
        }

        public string Description
        {
            get => description;
            set
            {
                if (!string.IsNullOrWhiteSpace(value)) SetProperty(ref description, value);
            }
        }
    }
}