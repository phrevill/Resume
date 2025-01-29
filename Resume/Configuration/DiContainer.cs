using Resume.Bussines.Services.Impelmetesion;
using Resume.Bussines.Services.Implementation;
using Resume.Bussines.Services.Inteface;
using Resume.Bussines.Services.Interfaces;
using Resume.DAL.Repositories.Implementation;
using Resume.DataAccessLayer.Repositories.Implementation;
using Resume.DataAccessLayer.Repositories.Implementesion;
using Resume.DataAccessLayer.Repositories.Inteface;

namespace Resume.Web.Configuration
{
    public static class DiContainer
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            #region Repositories

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IContactUsRepository, ContactUsRepository>();
            services.AddScoped<IAboutMeRepository, AboutMeRepository>();
            services.AddScoped<IActivityRepository, ActivityRepository>();
            services.AddScoped<IEducationRepository, EducationRepository>();
            
            
            #endregion

            #region Services

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IContacUsService, ContactUsService>();
            services.AddScoped<IAboutMeService, AboutMeService>();
            services.AddScoped<IActivityService, ActivityService>();
            services.AddScoped<IEducationService, EducationService>();

            services.AddScoped<IViewRenderService, ViewRenderService>();
            services.AddScoped<IEmailService, EmailService>();

            #endregion
        }
    }
}
