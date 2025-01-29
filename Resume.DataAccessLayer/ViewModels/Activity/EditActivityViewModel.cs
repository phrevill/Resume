using System.ComponentModel.DataAnnotations;

namespace Resume.DataAccessLayer.ViewModels.Activity;

public class EditActivityViewModel
{
    public int Id { get; set; }

    [Display(Name = "عنوان")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MaxLength(350, ErrorMessage = "تعداد کاراکتر شده بیش از حد مجاز است")]
    public string Title { get; set; }

    [Display(Name = "توضیحات")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MaxLength(700, ErrorMessage = "تعداد کاراکتر شده بیش از حد مجاز است")]
    public string Description { get; set; }

    [Display(Name = "آیکون")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MaxLength(200, ErrorMessage = "تعداد کاراکتر شده بیش از حد مجاز است")]
    public string Icon { get; set; }
}

public enum EditActivityResult
{
    Success,
    ActivityNotFound,
    Error
}