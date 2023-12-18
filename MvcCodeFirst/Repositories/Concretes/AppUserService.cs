using Microsoft.AspNetCore.Mvc.ModelBinding;
using MvcCodeFirst.Models.Context;
using MvcCodeFirst.Models.ViewModels;
using MvcCodeFirst.Repositories.Abstracts;
using MvcCodeFirst.Repositories.Utils.AppUserUtils;

namespace MvcCodeFirst.Repositories.Concretes
{
    public class AppUserService : IAppUserRepository
    {
        private readonly ProjectContext _context;

        public AppUserService(ProjectContext context)
        {
            _context = context;
        }//dependency injection instance


        public string CreateUser(RegisterVM model)
        {
            var user = RegisterConvertVM.AppUserConvert(model);

            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return "Kullanıcı oluşturuldu!";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public bool ForgotPasswordReset(ForgotPasswordVM model)
        {
            
                bool result = _context.Users.Any(x => x.Email == model.Email);
                if (result)
                {
                   return true;
                }
                else
                {
                    return false;
                }
                
        }

        public bool LoginUser(LoginVM model)
        {

            var user = _context.Users.FirstOrDefault(x => x.Email == model.Email);
            if (user == null)
            {
                return false;
                Console.WriteLine("kullanıcı db de bulunamadı");
            }
            else
            {
                bool result = user.Password == model.Password;
                if (result)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
