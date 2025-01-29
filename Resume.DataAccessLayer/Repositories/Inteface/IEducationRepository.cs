using Resume.DataAccessLayer.Models.Education;
using Resume.DataAccessLayer.ViewModels.Education;

namespace Resume.DataAccessLayer.Repositories.Inteface;

public interface IEducationRepository
{
    Task<FilterEducationViewModel> FilterAsync(FilterEducationViewModel model);

    Task InsertAsync(Education education);

    Task SaveAsync();

    Task<Education> GetByIdAsync(int id);

    void Update(Education education);

    Task<EditEducationViewModel> GetForEditByIdAsync(int id);
}