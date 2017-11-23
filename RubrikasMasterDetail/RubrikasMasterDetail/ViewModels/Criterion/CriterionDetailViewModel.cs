using RubrikasMasterDetail.Models;

namespace RubrikasMasterDetail.ViewModels
{
    public class CriterionDetailViewModel : BaseViewModel
    {
        public Criterion Item { get; set; }
        
        public CriterionDetailViewModel(Criterion item)
        {
            Item = item;
            Title = item?.Name;
        }
    }
}
