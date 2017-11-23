using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Firebase.Xamarin.Database.Query;
using RubrikasMasterDetail.Models;
using RubrikasMasterDetail.Pages;
using Xamarin.Forms;

namespace RubrikasMasterDetail.ViewModels
{
    public class NewEvaluationViewModel : BaseViewModel
    {
        public Evaluation Item { get; set; }
        public bool CanSave => !IsBusy;
        
        public NewEvaluationViewModel()
        {
            Title = "Creación de Evaluación";
            Item = new Evaluation
            {
                Description = "Descripción de la Evaluación"
            };
            Rubrics = new ObservableCollection<Rubric>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        public ObservableCollection<Rubric> Rubrics { get; set; }
        public Command LoadItemsCommand { get; set; }

        private async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Rubrics.Clear();
                var items = await firebase
                    .Child("Rubric")
                    .OrderByKey()
                    .OnceAsync<Rubric>();
                
                foreach (var item in items)
                {
                    var i = item.Object;
                    i.Key = item.Key;
                    Rubrics.Add(i);
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
