using Microsoft.AspNetCore.Mvc;
using Resume.Bussines.Extensions;
using Resume.Bussines.Services.Inteface;

namespace Resume.Web.Areas.Admin.Components
{
    public class LeftSideBarViewComponent:ViewComponent
    {

        #region Fiels

        private readonly IUserService _userService;

        #endregion

        #region Cunstructor

        public LeftSideBarViewComponent(IUserService userService)
        {
            _userService = userService;
        }

        #endregion
        #region Methods

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewData["User"] = await _userService.GetInformationAsync(User.GetUserId());
            return View("LeftSideBar");
        }

        #endregion
    }
}
