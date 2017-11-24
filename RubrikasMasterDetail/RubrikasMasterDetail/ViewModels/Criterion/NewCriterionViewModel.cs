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
    public class NewCriterionViewModel : BaseViewModel
    {
        public Criterion Item { get; set; }
        
        public NewCriterionViewModel()
        {
            Title = "Creación de Elementos";
            Item = new Criterion();
            Levels = Item.Levels = new ObservableCollection<Level>
            {
                new Level
                {
                    Name = "Nivel 1",
                    Score = 1.25f
                },
                new Level
                {
                    Name = "Nivel 2",
                    Score = 2.5f
                },
                new Level
                {
                    Name = "Nivel 3",
                    Score = 3.75f
                },
                new Level
                {
                    Name = "Nivel 4",
                    Score = 5f
                }
            };
        }

        public NewCriterionViewModel(Criterion criterion)
        {
            Title = "Creación de Elementos";
            Item = criterion;
            Levels = Item.Levels;
        }

        public ObservableCollection<Level> Levels { get; set; }

    }
}
