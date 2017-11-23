using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace RubrikasMasterDetail.Models
{
    public class Rubric : BaseModel
    {
        private string name;
        private string description;

        public ObservableCollection<Category> Categories { get; set; } = new ObservableCollection<Category>();

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
        public static bool IsValid(Rubric item)
        {
            return !string.IsNullOrWhiteSpace(item.Name) &&
                   !string.IsNullOrWhiteSpace(item.Description) &&
                   item.Categories.Aggregate(0f, (current, category) => current + category.Weight) == 100 &&
                   item.Categories.Aggregate(true, (current, category) => current & Category.IsValid(category));
        }
    }
}
