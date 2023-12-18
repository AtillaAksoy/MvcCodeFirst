using MvcCodeFirst.Models.ViewModels;

namespace MvcCodeFirst.Repositories.Abstracts
{
    public interface IAppUserRepository
    {
        public string CreateUser(RegisterVM model);
        public bool LoginUser(LoginVM model);
        public bool ForgotPasswordReset(ForgotPasswordVM model);
    }
}
