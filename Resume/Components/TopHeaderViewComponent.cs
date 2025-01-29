using Microsoft.AspNetCore.Mvc;
using Resume.Bussines.Services.Inteface;

namespace Resume.Web.Components;

public class TopHeaderViewComponent: ViewComponent
{
    #region Field

    private readonly IAboutMeService _aboutMeService;

    #endregion

    #region Cunstractor

    public TopHeaderViewComponent(IAboutMeService aboutMeService)
    {
        _aboutMeService = aboutMeService;
    }

    #endregion

    #region Methods

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var model = await _aboutMeService.GetClientSideInfoAsync();
        return View("TopHeader", model);
    }

    #endregion
}