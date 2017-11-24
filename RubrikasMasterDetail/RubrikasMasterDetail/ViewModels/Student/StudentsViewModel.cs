using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Firebase.Xamarin.Database.Query;
using RubrikasMasterDetail.Models;
using RubrikasMasterDetail.Pages;
using Xamarin.Forms;

namespace RubrikasMasterDetail.ViewModels
{
    public class StudentsViewModel : BaseViewModel
    {
        private Course Course;
        public StudentsViewModel(Course course)
        {
            Course = course;
            Title = "Estudiantes";
            Items = new ObservableCollection<Student>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewStudentPage, Student>(this, "AddItem", async (obj, item) =>
            {
                var _item = await firebase
                    .Child("Course")
                    .Child(Course.Key)
                    .Child("Student")
                    .PostAsync(item);
                item.Key = _item.Key;
                Items.Add(item);

            });
        }

        public ObservableCollection<Student> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        private async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await firebase
                    .Child("Course")
                    .Child(Course.Key)
                    .Child("Student")
                    .OrderByKey()
                    .OnceAsync<Student>();
                
                foreach (var item in items)
                {
                    var i = item.Object;
                    i.Key = item.Key;
                    Items.Add(i);
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
}
