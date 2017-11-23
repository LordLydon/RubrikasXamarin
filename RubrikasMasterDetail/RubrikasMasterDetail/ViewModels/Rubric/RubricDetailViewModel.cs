using RubrikasMasterDetail.Models;

namespace RubrikasMasterDetail.ViewModels
{
    public class RubricDetailViewModel : BaseViewModel
    {
        public Rubric Item { get; set; }
        
        public RubricDetailViewModel(Rubric item)
        {
            Item = item;
            Title = item?.Name;
        }
    }
}
