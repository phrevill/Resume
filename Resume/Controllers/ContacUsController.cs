using Microsoft.AspNetCore.Mvc;
using Resume.Bussines.Services.Inteface;
using Resume.Web.Areas.Admin.Views.ContactUs;

namespace Resume.Web.Controllers
{
    public class ContacUsController : SiteBaseController
    {
        #region Fields

        private readonly IContacUsService _contacUsService;

        #endregion

        #region Constructor

        public ContacUsController(IContacUsService contacUsService)
        {
            _contacUsService = contacUsService;
        }

        #endregion

        #region Action

        #region ContactUs

        [HttpGet("/contact-us")]
        public IActionResult ContactUs()
        {
            return View();
        }

        [HttpPost("/contact-us")]
        public async Task<IActionResult> ContactUs(CreateContactUsViewModel model)
        {
            #region Validations

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            #endregion

            var result = await _contacUsService.CreateAsync(model);
            switch (result)
            {
                case CreateContactUsResult.Success:
                    TempData[SuccessMessage] = "پیام شما با موفقیت ثبت شد. نتیجه از طریق ایمیل به شما اطلاع رسانی خواهد شد.";
                    return RedirectToAction("ContactUs");

                case CreateContactUsResult.Error:
                    TempData[ErrorMessage] = "خطایی رخ داده است لطفا مجدد تلاش کنید.";
                    break;
            }

            return View();
        }

        #endregion

        #endregion


    }
}
