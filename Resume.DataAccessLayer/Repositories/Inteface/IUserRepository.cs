using Resume.DataAccessLayer.Models.User;
using Resume.DataAccessLayer.ViewModels.User;

namespace Resume.DataAccessLayer.Repositories.Inteface;

public interface IUserRepository
{
    #region Methods

    Task InsertAsync(User user);

    Task<User> GetByIdAsync(int id);

    Task<User> GetByEmailAsync(string email);

    Task<bool> DuplicatedEmailAsync(int id, string email);

    Task<bool> DuplicatedMobileAsync(int id, string mobile);

    void Update(User user);

    Task<FilterUserViewModel> FilterAsync(FilterUserViewModel model);

    Task SaveAsync();

    #endregion
}