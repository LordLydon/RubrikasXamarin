using RubrikasMasterDetail.Models;

namespace RubrikasMasterDetail.ViewModels
{
    public class CategoryDetailViewModel : BaseViewModel
    {
        public Category Item { get; set; }
        
        public CategoryDetailViewModel(Category item)
        {
            Item = item;
            Title = item?.Name;
        }
    }
}
