using System;
using System.Collections.Generic;
using System.Text;

namespace RubrikasMasterDetail.Models
{
    public class Level : BaseModel
    {
        private string name;
        private float score;

        public string Name
        {
            get => name;
            set
            {
                if (!string.IsNullOrWhiteSpace(value)) SetProperty(ref name, value);
            }
        }

        public float Score
        {
            get => score;
            set => SetProperty(ref score, value);
        }

        public static bool IsValid(Level item)
        {
            return !string.IsNullOrWhiteSpace(item.Name) &&
                   item.Score >= 0 &&
                   item.Score <= 5;
        }
    }
}
