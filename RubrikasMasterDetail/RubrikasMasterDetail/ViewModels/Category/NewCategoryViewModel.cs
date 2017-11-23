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
    public class NewCategoryViewModel : BaseViewModel
    {
        public Category Item { get; set; }
        
        public NewCategoryViewModel()
        {
            Title = "Creación de Categorias";
            Item = new Category();
            Criteria = Item.Criteria = new ObservableCollection<Criterion>();
            UpdateLabel();
            
            MessagingCenter.Subscribe<NewCriterionPage, CriterionResult>(this, "AddItem", async (obj, item) =>
            {
                if(Item == item.Category) Criteria.Add(item.Criterion);
                UpdateLabel();
            });

            MessagingCenter.Subscribe<NewCriterionPage, CriterionResult>(this, "UpdateItem", async (obj, item) =>
            {
                if (Item == item.Category) UpdateLabel();
            });
        }

        public NewCategoryViewModel(Category category)
        {
            Title = "Creación de Categorias";
            Item = category;
            Criteria = Item.Criteria;
            UpdateLabel();

            MessagingCenter.Subscribe<NewCriterionPage, CriterionResult>(this, "AddItem", async (obj, item) =>
            {
                if (Item == item.Category) Criteria.Add(item.Criterion);
                UpdateLabel();
            });

            MessagingCenter.Subscribe<NewCriterionPage, CriterionResult>(this, "UpdateItem", async (obj, item) =>
            {
                if (Item == item.Category) UpdateLabel();
            });
        }

        public ObservableCollection<Criterion> Criteria { get; set; }

        private string criteriaLabel;

        public string CriteriaLabel
        {
            get => criteriaLabel;
            private set
            {
                if (!string.IsNullOrWhiteSpace(value)) SetProperty(ref criteriaLabel, value);
            }
        }

        private void UpdateLabel()
        {
            CriteriaLabel =
                $"Elementos ({Criteria.Aggregate(0f, (current, criterion) => current + criterion.Weight)}/100)";
        }
        
    }

    public struct CriterionResult
    {
        public Criterion Criterion { get; set; }
        public Category Category { get; set; }
    }
}
