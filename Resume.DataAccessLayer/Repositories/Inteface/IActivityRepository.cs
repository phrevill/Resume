using Resume.DataAccessLayer.Models.Activity;
using Resume.DataAccessLayer.ViewModels.Activity;

namespace Resume.DataAccessLayer.Repositories.Inteface;

public interface IActivityRepository
{
    Task<FilterActivityViewModel> FilterAsync(FilterActivityViewModel model);

    Task InsertAsync(Activity activity);

    void Update(Activity activity);

    Task SaveAsync();

    Task<EditActivityViewModel?> GetInfoByIdAsync(int id);

    Task<Activity?> GetByIdAsync(int id);

    Task<List<ActivityDetailsViewModel>> GetAllInfo();
}