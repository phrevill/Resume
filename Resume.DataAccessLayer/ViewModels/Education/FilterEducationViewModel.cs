using System.ComponentModel.DataAnnotations;
using Azure;
using Resume.DataAccessLayer.ViewModels.Common;

namespace Resume.DataAccessLayer.ViewModels.Education;

public class FilterEducationViewModel:BasePaging<EducationViewModel>
{
    [Display(Name = "عنوان")]
    public string? Title { get; set; }

    [Display(Name = "تاریخ از")]
    public DateOnly? Start { get; set; }

    [Display(Name = "تاریخ تا")]
    public DateOnly? End { get; set; }
}