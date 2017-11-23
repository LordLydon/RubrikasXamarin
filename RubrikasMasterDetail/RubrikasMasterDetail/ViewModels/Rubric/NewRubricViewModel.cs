using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Firebase.Xamarin.Database.Query;
using RubrikasMasterDetail.Models;
using RubrikasMasterDetail.Pages;
using Xamarin.Forms;

namespace RubrikasMasterDetail.ViewModels
{
    public class NewRubricViewModel : BaseViewModel
    {
        public Rubric Item { get; set; }
        
        public NewRubricViewModel()
        {
            Title = "Creación de Rubrica";
            Item = new Rubric
            {
                Description = "Descripción de la Rubrica"
            };
            Categories = Item.Categories = new ObservableCollection<Category>();
            UpdateLabel();
            
            MessagingCenter.Subscribe<NewCategoryPage, Category>(this, "AddItem", async (obj, item) =>
            {
                Categories.Add(item);
                UpdateLabel();
            });

            MessagingCenter.Subscribe<NewCategoryPage, Category>(this, "UpdateItem", async (obj, item) =>
            {
                UpdateLabel();
            });
        }

        public ObservableCollection<Category> Categories { get; set; }

        private string categoriesLabel;

        public string CategoriesLabel
        {
            get => categoriesLabel;
            private set {
                if (!string.IsNullOrWhiteSpace(value)) SetProperty(ref categoriesLabel, value);
            }
        }

        private void UpdateLabel()
        {
            CategoriesLabel =
                $"Categorias ({Categories.Aggregate(0f, (current, category) => current + category.Weight)}/100)";
        }
    }
}
