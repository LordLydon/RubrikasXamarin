using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Xamarin.Database.Query;
using RubrikasMasterDetail.Models;
using RubrikasMasterDetail.Pages;
using Xamarin.Forms;

namespace RubrikasMasterDetail.ViewModels
{
    public class GradeEvaluationViewModel : BaseViewModel
    {
        public Course Course { get; set; }
        public Evaluation Evaluation { get; set; }
        public GradedStudent GradedStudent { get; set; }
        
        public GradeEvaluationViewModel(Course course, Evaluation evaluation, GradedStudent gradedStudent)
        {
            Course = course;
            Evaluation = evaluation;
            GradedStudent = gradedStudent;
            Title = $"Evaluación {Evaluation.Name} - Estudiante {GradedStudent.Student.Name}" ;
            Items = new ObservableCollection<GradedCategory>();

            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<GradeCategory, GradedCategory>(this, "AddItem", async (obj, structure) =>
            {
                //GradedStudent.Grade.CatGrades.Add(structure.Grade);
            });
        }
        
        public ObservableCollection<GradedCategory> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        private async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var categories = Evaluation.Rubric.Categories;

                var grades = GradedStudent.Grade.CatGrades;

                for (var i = 0; i < categories.Count; i++)
                {
                    var mark = grades.FirstOrDefault(g => g.CatKey == i);
                    if (mark == null)
                    {
                        mark = new CatGrade
                        {
                            CatKey = i,
                            Mark = 0f
                        };
                        GradedStudent.Grade.CatGrades.Add(mark);
                    }

                    Items.Add(new GradedCategory() {Grade = mark, Category = categories[i]});
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
    }

    public struct GradedCategory
    {
        public Category Category { get; set; }
        public CatGrade Grade { get; set; }
    }
}
