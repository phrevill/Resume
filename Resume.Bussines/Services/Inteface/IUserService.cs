using Resume.DataAccessLayer.Models.User;
using Resume.DataAccessLayer.ViewModels.Account;
using Resume.DataAccessLayer.ViewModels.User;

namespace Resume.Bussines.Services.Inteface;

public interface IUserService
{
    #region Methods

    Task<CreateUserResult> CreateAsync(CreateUserViewModel model);

    Task<EditUserViewModel> GetForEditByIdAsync(int id);

    Task<EditUserResult> UpdateAsync(EditUserViewModel model);

    Task<FilterUserViewModel> FilterAsync(FilterUserViewModel model);

    Task<LoginResult> LoginAsync(LoginViewModel model);

    Task<User> GetByEmailAsync(string email);

    Task<UserDetailsViewModel> GetInformationAsync(int id);

    #endregion
}