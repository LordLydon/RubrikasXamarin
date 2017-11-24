using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Firebase.Xamarin.Database.Query;
using RubrikasMasterDetail.Models;
using RubrikasMasterDetail.Pages;
using Xamarin.Forms;

namespace RubrikasMasterDetail.ViewModels
{
    public class EvaluationDetailViewModel : BaseViewModel
    {
        public Course Course { get; set; }
        public Evaluation Item { get; set; }
        
        public EvaluationDetailViewModel(Course course, Evaluation item)
        {
            Course = course;
            Item = item;
            Title = item?.Name;
            Items = new ObservableCollection<GradedStudent>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            
            MessagingCenter.Subscribe<GradeEvaluation, Grade>(this, "AddItem", async (obj, structure) =>
            {
                //!!Verificar que no se escriban varias veces!!
                
                //Verificar si se cambió la calificación en la db!!
                await firebase
                    .Child("Course")
                    .Child(Course.Key)
                    .Child("Evaluation")
                    .Child(Item.Key)
                    .Child("Grades")
                    .PutAsync(Item.Grades);
                //structure.Grade.Key = _item.Key;
            });
        }

        public ObservableCollection<GradedStudent> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        private async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var students = await firebase
                    .Child("Course")
                    .Child(Course.Key)
                    .Child("Student")
                    .OrderByKey()
                    .OnceAsync<Student>();

                foreach (var student in students)
                {
                    var local = student.Object;
                    local.Key = student.Key;

                    var mark = Item.Grades.FirstOrDefault(g => g.StudentId == local.Key);
                    if (mark == null)
                    {
                        mark = new Grade
                        {
                            Mark = 0,
                            StudentId = local.Key
                        };
                        Item.Grades.Add(mark);
                    }
                    
                    Items.Add(new GradedStudent{Grade = mark, Student = local});
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

    public struct GradedStudent{
        public Student Student { get; set; }
        public Grade Grade { get; set; }
    }
}
