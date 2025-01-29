using Microsoft.AspNetCore.Mvc;
using Resume.Bussines.Services.Inteface;
using Resume.DataAccessLayer.ViewModels.Activity;

namespace Resume.Web.Areas.Admin.Controllers
{
    public class ActivityController : AdminBaseController
    {
        #region Field

        private readonly IActivityService _activityService;

        #endregion

        #region Constractor

        public ActivityController(IActivityService activityService)
        {
            _activityService = activityService;
        }

        #endregion

        #region Actions

        #region list

        public async Task<IActionResult> List(FilterActivityViewModel filter)
        {
            var model = await _activityService.FilterAsync(filter);
            return View(model);
        }
        #endregion

        #region Create

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateActivityViewModel model)
        {
            #region Validation

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            #endregion

            var result = await _activityService.CreateAsync(model);

            switch (result)
            {
                case CreateActivityResult.Success:
                    TempData[SuccessMessage] = "فعالیت جدید با موفقیت اضافه شد.";
                    return RedirectToAction("List");

                case CreateActivityResult.Error:
                    TempData[ErrorMessage] = "خطایی رخ داده است.";
                    break;

            }
            return View(model);
        }
        #endregion

        #region Edit

        public async Task<IActionResult> Update(int id)
        {
            var model= await _activityService.GetInfoByIdAsync(id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(EditActivityViewModel model)
        {
            #region Validation

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            #endregion

            var result = await _activityService.UpdateAsync(model);

            switch (result)
            {
                case EditActivityResult.Success:
                    TempData[SuccessMessage] = "فعالیت با موفقیت ویرایش شد.";
                    return RedirectToAction("List");
                case EditActivityResult.ActivityNotFound:
                    TempData[ErrorMessage] = "فعالیت یافت نشد.";
                    break;
                case EditActivityResult.Error:
                    TempData[ErrorMessage] = "خطایی رخ داده است.";
                    break;
            }
            return View(model);
        }

        #endregion

        #endregion
    }
}
