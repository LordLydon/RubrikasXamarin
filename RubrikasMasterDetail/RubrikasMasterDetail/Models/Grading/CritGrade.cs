using System;
using System.Collections.Generic;
using System.Text;

namespace RubrikasMasterDetail.Models
{
    public class CritGrade : BaseModel
    {
        private int critKey;
        private Level level;

        public int CritKey
        {
            get => critKey;
            set => SetProperty(ref critKey, value);
        }

        public Level Level
        {
            get => level;
            set
            {
                if (value != null && Level.IsValid(value)) SetProperty(ref level, value);
            }
        }

        public static bool IsValid(CritGrade item)
        {
            return item.Level != null &&
                   Level.IsValid(item.Level) &&
                   item.CritKey >= 0;
        }
    }
}
