using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resume.DataAccessLayer.Models.ContactUs;
using Resume.Web.Areas.Admin.Views.ContactUs;

namespace Resume.DataAccessLayer.Repositories.Inteface
{
    public interface IContactUsRepository
    {
        Task InsertAsync(ContactUs contactUs);

        Task<FilterContactUsViewModel> FilterAsync(FilterContactUsViewModel model);

        Task<ContactUsDetailsViewModel> GetInfoByIdAsync(int id);

        Task<ContactUs> GetByIdAsync(int id);

        void Update(ContactUs contactUs);

        Task SaveAsync();
    }
}