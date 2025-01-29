using Resume.DataAccessLayer.Models.AboutMe;
using Resume.DataAccessLayer.ViewModels.AboutMe;

namespace Resume.DataAccessLayer.Repositories.Inteface;

public interface IAboutMeRepository
{
    #region Methods

    Task<AdminSideEditAboutMeViewModel?> GetInfoAsync();
    Task<ClientSideEditAboutMeViewModel?> GetClientSideInfoAsync();

    Task<AboutMe> GetAsync();

    void Update(AboutMe aboutMe);

    Task SaveAsync();

    #endregion
}