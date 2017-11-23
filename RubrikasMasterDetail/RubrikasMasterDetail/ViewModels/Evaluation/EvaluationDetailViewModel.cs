using RubrikasMasterDetail.Models;

namespace RubrikasMasterDetail.ViewModels
{
    public class EvaluationDetailViewModel : BaseViewModel
    {
        public Evaluation Item { get; set; }
        
        public EvaluationDetailViewModel(Evaluation item)
        {
            Item = item;
            Title = item?.Name;
        }
    }
}
