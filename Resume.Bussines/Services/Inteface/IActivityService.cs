using Resume.DataAccessLayer.ViewModels.Activity;

namespace Resume.Bussines.Services.Inteface;

public interface IActivityService
{
    Task<FilterActivityViewModel> FilterAsync(FilterActivityViewModel model);

    Task<CreateActivityResult> CreateAsync(CreateActivityViewModel model);

    Task<EditActivityResult?> UpdateAsync(EditActivityViewModel model);

    Task<EditActivityViewModel?> GetInfoByIdAsync(int id);
    Task<List<ActivityDetailsViewModel>> GetAllInfo();
}