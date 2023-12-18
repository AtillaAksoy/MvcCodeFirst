using MvcCodeFirst.Models.Entities;
using MvcCodeFirst.Models.ViewModels;

namespace MvcCodeFirst.Repositories.Utils.AppUserUtils
{
    public class RegisterConvertVM
    {
        public static AppUser AppUserConvert(RegisterVM registerVM)
        {
            AppUser appUser = new AppUser()
            {
                Firstname = registerVM.Firstname,
                Lastname = registerVM.Lastname,
                Email = registerVM.Email,
                Username = registerVM.Username,
                Password = registerVM.Password,
                Gender = registerVM.Gender,
            };
            return appUser;
        }
    }
}
