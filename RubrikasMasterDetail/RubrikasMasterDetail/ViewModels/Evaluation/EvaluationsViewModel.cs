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
    public class EvaluationsViewModel : BaseViewModel
    {
        private Course Course;
        public EvaluationsViewModel(Course course)
        {
            Course = course;
            Title = "Evaluaciones";
            Items = new ObservableCollection<Evaluation>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewEvaluationPage, Evaluation>(this, "AddItem", async (obj, item) =>
            {
                var _item = await firebase
                    .Child("Course")
                    .Child(Course.Key)
                    .Child("Evaluation")
                    .PostAsync(item);
                item.Key = _item.Key;
                Items.Add(item);

            });
        }

        public ObservableCollection<Evaluation> Items { get; set; }
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
                    .Child("Evaluation")
                    .OrderByKey()
                    .OnceAsync<Evaluation>();
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
