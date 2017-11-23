using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace RubrikasMasterDetail.Models
{
    public class Criterion : BaseModel
    {
        private string name;
        private float weight;

        public ObservableCollection<Level> Levels { get; set; } = new ObservableCollection<Level>();

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

        public static bool IsValid(Criterion item)
        {
            return !string.IsNullOrWhiteSpace(item.Name) &&
                   item.Levels.Count >= 4 &&
                   item.Levels.Aggregate(true, (current, level) => current & Level.IsValid(level));
        }
    }
}
