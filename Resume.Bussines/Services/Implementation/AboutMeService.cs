using Resume.Bussines.Extensions;
using Resume.Bussines.Services.Inteface;
using Resume.Bussines.Tools;
using Resume.DataAccessLayer.Models.AboutMe;
using Resume.DataAccessLayer.Repositories.Inteface;
using Resume.DataAccessLayer.ViewModels.AboutMe;

namespace Resume.Bussines.Services.Implementation;

public class AboutMeService : IAboutMeService
{
    #region Fields

    private readonly IAboutMeRepository _aboutMeRepository;

    #endregion

    #region Cunstractor

    public AboutMeService(IAboutMeRepository aboutMeRepository)
    {
        _aboutMeRepository = aboutMeRepository;
    }
    #endregion
    #region Methods

    public async Task<AdminSideEditAboutMeViewModel?> GetInfoAsync()
    {
        return await _aboutMeRepository.GetInfoAsync();
    }

    public async Task<AdminSideEditAboutMeResult> UpdateAsync(AdminSideEditAboutMeViewModel model)
    {
        AboutMe aboutMe = await _aboutMeRepository.GetAsync();

        if (aboutMe == null)
            return AdminSideEditAboutMeResult.AboutMeNotFound;

        aboutMe.FirstName = model.FirstName;
        aboutMe.LastName = model.LastName;
        aboutMe.Email = model.Email;
        aboutMe.Mobile = model.Mobile;
        aboutMe.Position = model.Position;
        aboutMe.BirthDate = model.BirthDate;
        aboutMe.Location = model.Location;
        aboutMe.Bio = model.Bio;

        if (model.Avatar != null)
        {
            string imageName = Guid.NewGuid()+ Path.GetExtension(model.Avatar.FileName);
            model.Avatar.AddImageToServer(imageName, SiteTools.AboutMeAvatar);

            aboutMe.ImageName = imageName;
        }
        if (model.BackgroundImage != null)
        {
            string backGroundIimageName = Guid.NewGuid() + Path.GetExtension(model.BackgroundImage.FileName);
            model.BackgroundImage.AddImageToServer(backGroundIimageName, SiteTools.AboutMeBackground);

            aboutMe.BackgroundImageName = backGroundIimageName;
        }

        _aboutMeRepository.Update(aboutMe);
        await _aboutMeRepository.SaveAsync();

        return AdminSideEditAboutMeResult.Success;
    }

    public async Task<ClientSideEditAboutMeViewModel?> GetClientSideInfoAsync()
    {
        return await _aboutMeRepository.GetClientSideInfoAsync();
    }
    #endregion
}