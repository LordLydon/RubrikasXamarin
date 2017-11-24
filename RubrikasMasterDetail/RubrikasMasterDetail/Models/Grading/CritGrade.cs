using System;
using System.Collections.Generic;
using System.Text;

namespace RubrikasMasterDetail.Models
{
    public class CritGrade : BaseModel
    {
        private int critKey;
        private string level;
        private float mark;

        public int CritKey
        {
            get => critKey;
            set => SetProperty(ref critKey, value);
        }

        public string Level
        {
            get => level;
            set
            {
                if (!string.IsNullOrWhiteSpace(value)) SetProperty(ref level, value);
            }
        }

        public float Mark
        {
            get => mark;
            set => SetProperty(ref mark, value);
        }

        public static bool IsValid(CritGrade item)
        {
            return !string.IsNullOrWhiteSpace(item.Level) &&
                   item.Mark >= 0 &&
                   item.Mark <= 5 &&
                   item.CritKey >= 0;
        }
    }
}
