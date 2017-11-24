using System;
using System.Collections.ObjectModel;
using System.Reactive.Linq;

namespace RubrikasMasterDetail.Models
{
    public class Evaluation : BaseModel
    {
        private string description;
        private string name;
        private Rubric rubric;

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

        public Rubric Rubric
        {
            get => rubric;
            set
            {
                if (rubric != null && Rubric.IsValid(rubric)) SetProperty(ref rubric, value);
            }
        }

        public ObservableCollection<Grade> Grades { get; set; } = new ObservableCollection<Grade>();

        public static bool IsValid(Evaluation item)
        {
            return !string.IsNullOrWhiteSpace(item.Name) &&
                   !string.IsNullOrWhiteSpace(item.Description) &&
                   item.Rubric != null &&
                   Rubric.IsValid(item.Rubric);
        }
    }
}