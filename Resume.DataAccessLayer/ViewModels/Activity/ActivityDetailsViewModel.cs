using Resume.DataAccessLayer.ViewModels.Common;

namespace Resume.DataAccessLayer.ViewModels.Activity;

public class ActivityDetailsViewModel
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public string Icon { get; set; }

    public DateTime CreateDate { get; set; }
}