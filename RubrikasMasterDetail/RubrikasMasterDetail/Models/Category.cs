using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace RubrikasMasterDetail.Models
{
    public class Category : BaseModel
    {
        private string name;
        private float weight;

        public ObservableCollection<Criterion> Criteria { get; set; } = new ObservableCollection<Criterion>();

        public string Name
        {
            get => name;
            set
            {
                if (!string.IsNullOrWhiteSpace(value)) SetProperty(ref name, value);
            }
        }

        public float Weight
        {
            get => weight;
            set => SetProperty(ref weight, value);
        }

        public static bool IsValid(Category item)
        {
            return !string.IsNullOrWhiteSpace(item.Name) &&
                   item.Criteria.Aggregate(0f, (current, criterion) => current + criterion.Weight) == 100f &&
                item.Criteria.Aggregate(true, (current, criterion) => current & Criterion.IsValid(criterion));
        }
    }
}