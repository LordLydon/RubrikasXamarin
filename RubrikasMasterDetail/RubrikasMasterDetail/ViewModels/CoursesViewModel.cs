using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Firebase.Xamarin.Database.Query;
using RubrikasMasterDetail.Models;
using Xamarin.Forms;

namespace RubrikasMasterDetail.ViewModels
{
    public class CoursesViewModel : BaseViewModel
    {
        public CoursesViewModel()
        {
            Title = "Browse";
            Items = new ObservableCollection<Course>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewCoursePage, Course>(this, "AddItem", async (obj, item) =>
            {
                var _item = item;
                Items.Add(_item);
                await firebase
                    .Child("Course")
                    .PostAsync(_item);
            });
        }

        public ObservableCollection<Course> Items { get; set; }
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
                    .OrderByKey()
                    .OnceAsync<Course>();
                foreach (var item in items)
                { 
                    Items.Add(item.Object);
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