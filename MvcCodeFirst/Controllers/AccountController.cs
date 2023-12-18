using Microsoft.AspNetCore.Mvc;
using MvcCodeFirst.Models.ViewModels;
using MvcCodeFirst.Repositories.Abstracts;

namespace MvcCodeFirst.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAppUserRepository _appUserRepository;

        //todo: Veritabanı instance daha sonra Program.cs içerisinde service'e dahil edilecek.
        //ProjectContext db = new ProjectContext();
        public AccountController(IAppUserRepository appUserRepository)
        {
            _appUserRepository = appUserRepository;
        }//dependency injection

        public IActionResult Register()
        {
            //bir register formu oluşturun. Bu form içerisinde kullanıcının propertylerine ait inputlar tanımlayın. Ziyaretçi bu inputları doldurarak işlemi post etsin. Post action'a gönderilen model veritabanına kaydedilsin.
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterVM registerVM)
        {


            if (ModelState.IsValid)
            {
                #region Test işlemi
                //Veritabanında kullanıcı oluşturma
                //AppUser appUser = new AppUser()
                //{
                //    Firstname = registerVM.Firstname,
                //    Lastname = registerVM.Lastname,
                //    Email = registerVM.Email,
                //    Username = registerVM.Username,
                //    Password = registerVM.Password,
                //    Gender = registerVM.Gender,
                //};

                //AppUser appUser = RegisterConvertVM.AppUserConvert(registerVM);

                //try
                //{
                //    _context.Users.Add(appUser);
                //    _context.SaveChanges();
                //}
                //catch (Exception ex)
                //{

                //    Console.WriteLine(ex.Message);
                //}

                //return RedirectToAction("Login"); 
                #endregion

                var result = _appUserRepository.CreateUser(registerVM);
                TempData["Result"] = result;
                return View();
            }
            else
            {
                #region hata görme
                //Hataları görmek istedğimizde ModelState.Values dizisinde görebiliriz.
                //foreach (var item in ModelState.Values)
                //{

                //} 
                #endregion
                return View(registerVM);
            }


        }


        public IActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginVM loginVM)
        {

            if (ModelState.IsValid)
            {
                var result = _appUserRepository.LoginUser(loginVM);
                if (result)
                {
                    TempData["Success"] = "Giriş Başarılı!";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["Error"] = "bilgiler hatalı/şifre hatalı!";
                    return View(loginVM);
                }
            }
            else
            {
                TempData["Error"] = "eksik değer girdiniz!";
                return View(loginVM);
            }
            
            #region Test
            //bir login formu oluşturun. Sadece Kullanıcı adı (Email), Password değerlerine ait inputlar tanımlayın. Ziyaretçi bu alanları doldurup post ettiğinde ilk olarak böyle bir kullanıcının olup olmadığını veritabanından kontrol edin. Eğer varsa kullanıcı ve şifre kontrolü gerçekleştirin. Bilgiler doğruysa anasayfanın üzerinde "Giriş başarılı" yazısını gösterin.
            //if(ModelState.IsValid)
            //{
            //    var user =_context.Users.FirstOrDefault(x => x.Email == loginVM.Email);
            //    if (user == null)
            //    {
            //        TempData["Error"] = "böyle bir kullanıcı bulunamadı!";
            //        return View(loginVM);
            //    }
            //    else
            //    {
            //        bool result=user.Password == loginVM.Password;
            //        if (result)
            //        {
            //            TempData["Success"] = "Giriş Başarılı!";
            //            return RedirectToAction("Index", "Home");
            //        }
            //        else
            //        {
            //            TempData["Error"] = "Kullanıcı bilgisi yanlış!";
            //            return View(loginVM);
            //        }



            //    }

            //}
            //else
            //{
            //    return View(loginVM);
            //} 
           
            #endregion
        }


        public IActionResult ForgotPassword()
        {

            return View();
        }

        [HttpPost]
        public IActionResult ForgotPassword(ForgotPasswordVM forgotPasswordVM)
        {

            if (ModelState.IsValid)
            {
                var result = _appUserRepository.ForgotPasswordReset(forgotPasswordVM);
                if (result)
                {
                    return RedirectToAction("SendEmail", forgotPasswordVM);
                }
                else
                {
                    return View(forgotPasswordVM);

                }
            }
            else
            {

                return View(forgotPasswordVM);
            }
            #region Test
            //if (ModelState.IsValid)
            //{

            //    bool result = _context.Users.Any(x => x.Email == forgotPasswordVM.Email);
            //    if (result)
            //    {
            //        return RedirectToAction("SendEmail", forgotPasswordVM);
            //    }
            //    else
            //    {
            //        return View(forgotPasswordVM);
            //    }


            //}
            //else
            //{
            //    return View(forgotPasswordVM);
            //} 
            #endregion
        }

        public IActionResult SendEmail(ForgotPasswordVM model)
        {
            TempData["SendEmail"] = $"{model.Email} adresine şifre sıfırlama maili gönderildi!";
            return View();
        }


}
}
