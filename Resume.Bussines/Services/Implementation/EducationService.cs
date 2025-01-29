using Resume.Bussines.Services.Inteface;
using Resume.DataAccessLayer.Models.Education;
using Resume.DataAccessLayer.Repositories.Inteface;
using Resume.DataAccessLayer.ViewModels.Education;

namespace Resume.Bussines.Services.Implementation;

public class EducationService:IEducationService
{
    #region fields

    private readonly IEducationRepository _educationRepository;

    #endregion

    #region Cunstractor

    public EducationService(IEducationRepository educationRepository)
    {
        _educationRepository = educationRepository;
    }
    #endregion

    #region Methods

    public async Task<FilterEducationViewModel> FilterAsync(FilterEducationViewModel model)
    {
        return await _educationRepository.FilterAsync(model);
    }

    public async Task<CreateEducationResult> CreateAsync(CreateEducationViewModel model)
    {
        Education education = new Education()
        {
            Start = model.Start,
            Description = model.Description,
            End = model.End,
            Title = model.Title,
            CreateDate = DateTime.Now
        };

        await _educationRepository.InsertAsync(education);
        await _educationRepository.SaveAsync();

        return CreateEducationResult.Success;
    }

    public async Task<EditEducationResult> EditAsync(EditEducationViewModel model)
    {
        var education = await _educationRepository.GetByIdAsync(model.Id);

        if (education == null)
        {
            return EditEducationResult.EducationNotFound;
        }

        education.Title = model.Title;
        education.Start = model.Start;
        education.End = model.End;
        education.Description = model.Description;

        _educationRepository.Update(education);
        await _educationRepository.SaveAsync();

        return EditEducationResult.Success;
    }

    public async Task<EditEducationViewModel> GetForEditByIdAsync(int id)
    {
        return await _educationRepository.GetForEditByIdAsync(id);
    }
    #endregion
}