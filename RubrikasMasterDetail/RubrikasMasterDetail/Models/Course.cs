using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace RubrikasMasterDetail.Models
{
    public class Course : BaseModel
    {
        private string name;
        private string nrc;

        private ObservableCollection<Evaluation> Evaluations { get; set; }
        private ObservableCollection<Student> Students { get; set; }
        
        public string Name
        {
            get => name;
            set
            {
                if (!string.IsNullOrWhiteSpace(value)) SetProperty(ref name, value);
            }
        }

        public string NRC
        {
            get => nrc;
            set
            {
                if (!string.IsNullOrWhiteSpace(value) && value.Length == 4 && Regex.IsMatch(value, "^\\d{4}$"))
                    SetProperty(ref nrc, value);
            }
        }
    }
}