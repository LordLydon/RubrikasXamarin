using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace RubrikasMasterDetail.Models
{
    public class Grade : BaseModel
    {
        private string studentId;
        private float mark;
        
        public string StudentId
        {
            get => studentId;
            set
            {
                if (!string.IsNullOrWhiteSpace(value)) SetProperty(ref studentId, value);
            }
        }

        public float Mark
        {
            get => mark;
            set => SetProperty(ref mark, value);
        }

        public ObservableCollection<CatGrade> CatGrades { get; set; } = new ObservableCollection<CatGrade>();

        public static bool IsValid(Grade item)
        {
            return !string.IsNullOrWhiteSpace(item.studentId) &&
                   item.Mark >= 0 &&
                   item.Mark <= 5 &&
                   item.CatGrades.Count > 0 &&
                   item.CatGrades.Aggregate(true, (current, cgrade) => current & CatGrade.IsValid(cgrade));
        }


    }
}
