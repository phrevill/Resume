using Resume.DataAccessLayer.ViewModels.AboutMe;

namespace Resume.Bussines.Services.Inteface;

public interface IAboutMeService
{
    #region Admin

    Task<AdminSideEditAboutMeViewModel?> GetInfoAsync();
    Task<ClientSideEditAboutMeViewModel?> GetClientSideInfoAsync();

    Task<AdminSideEditAboutMeResult> UpdateAsync(AdminSideEditAboutMeViewModel model);

    #endregion
}