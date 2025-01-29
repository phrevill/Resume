using Resume.DataAccessLayer.Models.Common;

namespace Resume.DataAccessLayer.Models.AboutMe;

public class AboutMe:BaseEntity<int>
{
    #region Properties

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? Mobile { get; set; }

    public string? Position { get; set; }

    public DateOnly? BirthDate { get; set; }

    public string? Location { get; set; }

    public string Bio { get; set; }

    public string ImageName { get; set; }

    public string BackgroundImageName { get; set; }




    #endregion
}