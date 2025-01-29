using Microsoft.AspNetCore.Mvc;
using Resume.Bussines.Services.Inteface;
using Resume.DataAccessLayer.ViewModels.User;

namespace Resume.Web.Areas.Admin.Controllers
{

    public class UserController : AdminBaseController
    {
        #region Fields

        private readonly IUserService _userService;


        #endregion

        #region Constructor

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        #endregion

        #region Actions

        #region List

        public async Task<IActionResult> List(FilterUserViewModel filter)
        {
            var result = await _userService.FilterAsync(filter);
            return View(result);
        }

        #endregion

        #region Create

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserViewModel model)
        {
            #region Validation

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            #endregion

            var result = await _userService.CreateAsync(model);

            #region Check Result

            switch (result)
            {
                case CreateUserResult.Success:
                    TempData[SuccessMessage] = "کاربر جدید با موفقیت افزوده شد.";
                    return RedirectToAction("List");

                case CreateUserResult.Error:
                    TempData[ErrorMessage] = "خطایی رخ داده است.";
                    break;

            }

            #endregion
            return View(model);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }
        #endregion

        #region Update

        public async Task<IActionResult> Update(int id)
        {
            var user = await _userService.GetForEditByIdAsync(id);
            if (user==null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Update(EditUserViewModel model)
        {
            #region Validation

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            #endregion

            var result = await _userService.UpdateAsync(model);

            #region Check Result

            switch (result)
            {
                case EditUserResult.Success:
                    TempData[SuccessMessage] = "کاربر با موفقیت ویرایش شد.";
                    return RedirectToAction("List");

                case EditUserResult.Error:
                    TempData[ErrorMessage] = "خطایی رخ داده است.";
                    break;

                case EditUserResult.UserNotFound:
                    TempData[ErrorMessage] = "کاربری پیدار نشد.";
                    break;

                case EditUserResult.EmailDuplicated:
                    TempData[ErrorMessage] = "ایمیل تکراری است.";
                    break;

                case EditUserResult.MobileDuplicated:
                    TempData[ErrorMessage] = "شماره موبایل تکراری است.";
                    break;
            }

            #endregion
            return View(model);
        }
        #endregion

        #endregion
    }
}
