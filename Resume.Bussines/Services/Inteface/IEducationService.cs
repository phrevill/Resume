using Resume.DataAccessLayer.ViewModels.Education;

namespace Resume.Bussines.Services.Inteface;

public interface IEducationService
{
    Task<FilterEducationViewModel> FilterAsync(FilterEducationViewModel model);

    Task<CreateEducationResult> CreateAsync(CreateEducationViewModel model);

    Task<EditEducationResult> EditAsync(EditEducationViewModel model);

    Task<EditEducationViewModel> GetForEditByIdAsync(int id);
}