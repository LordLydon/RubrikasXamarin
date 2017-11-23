using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace RubrikasMasterDetail.Models
{
    public class Course : BaseModel
    {
        private string name;
        private string nrc;

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
                if (!string.IsNullOrWhiteSpace(value))// && value.Length == 4 && Regex.IsMatch(value, "^\\d{4}$"))
                    SetProperty(ref nrc, value);
            }
        }

        public static bool IsValid(Course item)
        {
            return !string.IsNullOrWhiteSpace(item.Name) && 
                   !string.IsNullOrWhiteSpace(item.NRC);
        }
    }
}