using Resume.DataAccessLayer.Models.Common;

namespace Resume.DataAccessLayer.Models.Activity;

public class Activity: BaseEntity<int>
{
    public string Title { get; set; }

    public string Description { get; set; }

    public string Icon { get; set; }
}