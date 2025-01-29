using Resume.Bussines.Services.Inteface;
using Resume.DataAccessLayer.Models.Activity;
using Resume.DataAccessLayer.Repositories.Inteface;
using Resume.DataAccessLayer.ViewModels.Activity;

namespace Resume.Bussines.Services.Implementation;

public class ActivityService: IActivityService
{
    #region Field

    private readonly IActivityRepository _activityRepository;

    #endregion

    #region Cunstractor
    public ActivityService(IActivityRepository activityRepository)
    {
        _activityRepository = activityRepository;
    }
    #endregion

    #region Methods

    public Task<FilterActivityViewModel> FilterAsync(FilterActivityViewModel model)
    {
        return _activityRepository.FilterAsync(model);
    }

    public async Task<EditActivityViewModel> GetInfoByIdAsync(int id)
    {
        return await _activityRepository.GetInfoByIdAsync(id);
    }

    public async Task<EditActivityResult?> UpdateAsync(EditActivityViewModel model)
    {
        var activity = await _activityRepository.GetByIdAsync(model.Id);
        if (activity == null)
            return EditActivityResult.ActivityNotFound;

        activity.Title = model.Title;
        activity.Description = model.Description;
        activity.Icon = model.Icon;

        _activityRepository.Update(activity);
        await _activityRepository.SaveAsync();

        return EditActivityResult.Success;
    }

    public async Task<CreateActivityResult> CreateAsync(CreateActivityViewModel model)
    {
        Activity activity=new Activity()
        {
            CreateDate = DateTime.Now,
            Description = model.Description,
            Title = model.Title,
            Icon = model.Icon,
        };
        await _activityRepository.InsertAsync(activity);
        await _activityRepository.SaveAsync();

        return CreateActivityResult.Success;
    }

    public async Task<List<ActivityDetailsViewModel>> GetAllInfo()
    {
        return await _activityRepository.GetAllInfo();
    }
    #endregion
}