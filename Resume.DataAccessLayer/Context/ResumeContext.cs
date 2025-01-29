using Microsoft.EntityFrameworkCore;
using Resume.DataAccessLayer.Models.AboutMe;
using Resume.DataAccessLayer.Models.Activity;
using Resume.DataAccessLayer.Models.ContactUs;
using Resume.DataAccessLayer.Models.Education;
using Resume.DataAccessLayer.Models.User;

namespace Resume.DataAccessLayer.Context;

public class ResumeContext : DbContext
{
    #region Constructor

    public ResumeContext(DbContextOptions<ResumeContext> options) : base(options)
    {

    }
    #endregion

    #region Dbset

    public DbSet<User> Users { get; set; }
    public DbSet<ContactUs> ContactUs { get; set; }
    public DbSet<AboutMe> AboutMe { get; set; }
    public DbSet<Activity> Activities { get; set; }
    public DbSet<Education> Educations { get; set; }

    #endregion


    #region ModelCreating

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region Seed Data

        #region User

        modelBuilder.Entity<User>()
            .HasData(new User()
            {
                CreateDate = DateTime.Now,
                Email = "amirshop@gmail.com",
                FirstName = "امیر",
                LastName = "دویران",
                Id = 1,
                IsActive = true,
                Mobile = "09367806232",
                Password = "82-7C-CB-0E-EA-8A-70-6C-4C-34-A1-68-91-F8-4E-7B"
            });

        #endregion

        #region AboutMe

        modelBuilder.Entity<AboutMe>()
            .HasData(new AboutMe()
            {
                Bio = "",
                BirthDate = DateOnly.FromDateTime(DateTime.Now),
                CreateDate = DateTime.Now,
                FirstName = "",
                Email = "",
                LastName = "",
                Location = "",
                Id = 1,
                Mobile = "",
                Position = "",
                ImageName = "",
                BackgroundImageName = ""
            });

        #endregion

        #endregion
    }


    #endregion

}