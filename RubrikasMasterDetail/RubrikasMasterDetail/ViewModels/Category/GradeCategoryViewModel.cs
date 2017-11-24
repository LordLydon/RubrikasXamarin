using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Xamarin.Database.Query;
using RubrikasMasterDetail.Models;
using Xamarin.Forms;

namespace RubrikasMasterDetail.ViewModels
{
    public class GradeCategoryViewModel : BaseViewModel
    {
        public Course Course { get; set; }
        public Evaluation Evaluation { get; set; }
        public GradedStudent GradedStudent { get; set; }
        public GradedCategory GradedCategory { get; set; }
        
        public GradeCategoryViewModel(Course course, Evaluation evaluation, GradedStudent gradedStudent)
        {
            Course = course;
            Evaluation = evaluation;
            GradedStudent = gradedStudent;
            Title = $"Categoria {GradedCategory.Category.Name} - Estudiante {GradedStudent.Student.Name}" ;
            Items = new ObservableCollection<GradedCriterion>();

            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }
        
        public ObservableCollection<GradedCriterion> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        private async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var criteria = GradedCategory.Category.Criteria;

                var grades = GradedCategory.Grade.CritGrades;
                
                for (var i = 0; i < criteria.Count; i++)
                {
                    var mark = grades.FirstOrDefault(g => g.CritKey == i);
                    if (mark == null)
                    {
                       mark = new CritGrade
                        {
                            CritKey = i,
                            Mark = 0f,
                            Level = "No calificado"
                        };
                        GradedCategory.Grade.CritGrades.Add(mark);
                    }
                    
                    Items.Add(new GradedCriterion{Grade = mark, Criterion = criteria[i]});
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }


        public struct GradedCriterion
        {
            public Criterion Criterion { get; set; }
            public CritGrade Grade { get; set; }
        }
    }
}
