using RubrikasMasterDetail.Models;

namespace RubrikasMasterDetail.ViewModels
{
    public class CourseDetailViewModel : BaseViewModel
    {
        public Course Course { get; set; }
        
        public CourseDetailViewModel(Course item = null)
        {
            Title = item?.Name; 
            Course = item;
        }
    }
}
