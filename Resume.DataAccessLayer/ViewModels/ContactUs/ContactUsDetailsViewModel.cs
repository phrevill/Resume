using System.ComponentModel.DataAnnotations;
namespace Resume.Web.Areas.Admin.Views.ContactUs;

public class ContactUsDetailsViewModel
{

    public int ContactUsId { get; set; }

    public string? Title { get; set; }

    public string? Mobile { get; set; }

    public string? Email { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Description { get; set; }

    [Display(Name = "پاسخ")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    public string? Answer { get; set; }

    public DateTime CreateDate { get; set; }
}


public enum AnswerResult
    {
        Success,
        ContactUsNotFound,
        Error,
        AnswerIsNull
    }
