using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace RubrikasMasterDetail.Models
{
    public class CatGrade : BaseModel
    {
        private int catKey;
        private float mark;

        public int CatKey
        {
            get => catKey;
            set => SetProperty(ref catKey, value);
        }

        public float Mark
        {
            get => mark;
            set => SetProperty(ref mark, value);
        }

        public ObservableCollection<CritGrade> CritGrades { get; set; } = new ObservableCollection<CritGrade>();

        public static bool IsValid(CatGrade item)
        {
            return item.CatKey >= 0 &&
                   item.Mark >= 0 &&
                   item.Mark <= 5 &&
                   item.CritGrades.Count > 0 &&
                   item.CritGrades.Aggregate(true, (current, cgrade) => current & CritGrade.IsValid(cgrade));
        }
    }
}
