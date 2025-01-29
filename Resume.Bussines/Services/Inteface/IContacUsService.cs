using Resume.Web.Areas.Admin.Views.ContactUs;

namespace Resume.Bussines.Services.Inteface;

public interface IContacUsService
{
    Task<CreateContactUsResult> CreateAsync(CreateContactUsViewModel model);

    Task<FilterContactUsViewModel> FilterAsync(FilterContactUsViewModel model);

    Task<ContactUsDetailsViewModel> GetByIdAsync(int id);

    Task<AnswerResult> AnswerAsync(ContactUsDetailsViewModel model);
}
