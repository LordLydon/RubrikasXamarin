using RubrikasMasterDetail.Models;

namespace RubrikasMasterDetail.ViewModels
{
    public class StudentDetailViewModel : BaseViewModel
    {
        public Student Item { get; set; }
        
        public StudentDetailViewModel(Student item)
        {
            Item = item;
            Title = item?.Name;
        }
    }
}
