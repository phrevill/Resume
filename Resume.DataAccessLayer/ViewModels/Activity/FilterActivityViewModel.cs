using Resume.DataAccessLayer.ViewModels.Common;
using System.ComponentModel.DataAnnotations;

namespace Resume.DataAccessLayer.ViewModels.Activity;

public class FilterActivityViewModel : BasePaging<ActivityDetailsViewModel>
{
    [Display(Name = "عنوان")]
    public string Title { get; set; }

}