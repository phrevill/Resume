using Microsoft.EntityFrameworkCore;
using Resume.DataAccessLayer.Context;
using Resume.DataAccessLayer.Models.AboutMe;
using Resume.DataAccessLayer.Repositories.Inteface;
using Resume.DataAccessLayer.ViewModels.AboutMe;

namespace Resume.DataAccessLayer.Repositories.Implementation;

public class AboutMeRepository : IAboutMeRepository
{
    #region Fields

    private readonly ResumeContext _context;

    #endregion

    #region Cunstractor

    public AboutMeRepository(ResumeContext context)
    {
        _context = context;
    }

    #endregion

    #region Methods

    public async Task<AdminSideEditAboutMeViewModel?> GetInfoAsync()
    {
        return await _context.AboutMe
            .Select(aboutMe => new AdminSideEditAboutMeViewModel()
            {
                FirstName = aboutMe.FirstName,
                LastName = aboutMe.LastName,
                Mobile = aboutMe.Mobile,
                Email = aboutMe.Email,
                Bio = aboutMe.Bio,
                BirthDate = aboutMe.BirthDate,
                Id = aboutMe.Id,
                ImageName = aboutMe.ImageName,
                Location = aboutMe.Location,
                Position = aboutMe.Position,
                BackgroundImageName = aboutMe.BackgroundImageName

            })
            .FirstOrDefaultAsync();
    }

    public async Task<AboutMe> GetAsync()
    {
        return await _context.AboutMe.FirstOrDefaultAsync();
    }

    public void Update(AboutMe aboutMe)
    {
         _context.AboutMe.Update(aboutMe);
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task<ClientSideEditAboutMeViewModel?> GetClientSideInfoAsync()
    {
        return await _context.AboutMe
            .Select(aboutMe => new ClientSideEditAboutMeViewModel()
            {
                FirstName = aboutMe.FirstName,
                LastName = aboutMe.LastName,
                Mobile = aboutMe.Mobile,
                Email = aboutMe.Email,
                Bio = aboutMe.Bio,
                BirthDate = aboutMe.BirthDate,
                Id = aboutMe.Id,
                ImageName = aboutMe.ImageName,
                Location = aboutMe.Location,
                Position = aboutMe.Position,
                BackgroundImageName = aboutMe.BackgroundImageName

            })
            .FirstOrDefaultAsync();
    }
    #endregion

}