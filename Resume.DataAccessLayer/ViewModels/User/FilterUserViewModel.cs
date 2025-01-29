using System.ComponentModel.DataAnnotations;
using Resume.DataAccessLayer.ViewModels.Common;

namespace Resume.DataAccessLayer.ViewModels.User;

public class FilterUserViewModel : BasePaging<UserDetailsViewModel>
{
    //bayad null pazir bashe
    [Display(Name = "موبایل")]
    public string? Mobile { get; set; }

    [Display(Name = "ایمیل")]
    public string? Email { get; set; }
}