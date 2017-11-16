namespace RubrikasMasterDetail.Models
{
    internal class Student : BaseModel
    {
        private string name;

        public string Name
        {
            get => name;
            set
            {
                if (!string.IsNullOrWhiteSpace(value)) SetProperty(ref name, value);
            }
        }
    }
}