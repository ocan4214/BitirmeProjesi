using BitirmeProjesi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BitirmeProjesi.Controllers
{
    [RequireHttps]
    public class UserController : Controller
    {
        //Registration Action
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Registration()
        {
            return View();
        }

        //Registration POST Action
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Registration([Bind(Exclude = "IsEmailVerified,ActivationCode")]User user)
        {

            bool Status = false;
            string message = "";

            //
            //Model Validation
            if (ModelState.IsValid)
            {

                #region //Email is already Exist
                var isExist = IsEmailExist(user.Email);
                if (isExist)
                {
                    ModelState.AddModelError("EmailExist", "Email already exist");//EmailExist Key ismi ile ModelState'e ekliyoruz ValidationMessage da ise kontrol ediyor "EmailExist" adlı bir field var ise
                    return View(user);//Email varsa yine kayıt sayfası gelecek
                }

                #endregion

                #region //Generate Activation Code 

                user.ActivationCode = Guid.NewGuid();


                #endregion

                #region //Password Hashing

                user.Password = Crypto.Hash(user.Password);//Crypto class static
                user.ConfirmPassword = Crypto.Hash(user.ConfirmPassword);//

                #endregion

                user.IsEmailVerified = false;//Başlangıçta false olacak

                #region //Save data to Database

                


                Profile userProfile = new Profile();           
                userProfile.User = user;
                user.Profile = userProfile;
                
                
     
                using (LogRegDBEntities1 dataconnection = new LogRegDBEntities1())
                {
                    dataconnection.Profiles.Add(userProfile);
                    dataconnection.Users.Add(user);
                    dataconnection.SaveChanges();



                    #region //Send Email to User

                    SendVerificationLink(user.Email, user.ActivationCode.ToString());
                    message = "Registration succesfully done. Account activation link" +
                               "has been sent to your email id:" + user.Email;
                    Status = true;


                    #endregion

                }

                #endregion

            }
            else
            {
                message = "Invalid Request";
            }

            ViewBag.Message = message;
            ViewBag.Status = Status;

            return View(user);
        }

        //Verify Account
        [HttpGet]
        public ActionResult VerifyAccount(string id)
        {
            bool Status = false;
            using (LogRegDBEntities1 databaseconnection = new LogRegDBEntities1())
            {
                databaseconnection.Configuration.ValidateOnSaveEnabled = false; //to avoid confirm password does not match issue on save change //Burayı boz ve dene 

                var verifiedAccount = databaseconnection.Users.Where(a => a.ActivationCode == new Guid(id)).FirstOrDefault();
                

                if (verifiedAccount != null)
                {
                    verifiedAccount.IsEmailVerified = true;                  
                    databaseconnection.SaveChanges();
                    Status = true;
                }
                else
                {
                    ViewBag.Message = "Invalid Request";
                }



            }
            ViewBag.Status = Status;//True olacak
            return View();
        }

        //Login
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        //Login POST
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLogin login, string ReturnURL = "")
        {
            string message = "";

            using (LogRegDBEntities1 databaseconnection = new LogRegDBEntities1())
            {
                var user = databaseconnection.Users.Where(a => a.Email == login.Email).FirstOrDefault();
                if (user != null)
                {//Login password'u hash ile sha256 encrypt ettik daha sonra encrypt hallerini kıyaslıyoruz
                    if (string.Compare(Crypto.Hash(login.Password), user.Password) == 0)//0 ise birbirlerine eşit oluyorlar 0 dan küçük ise ilk string daha önce geliyor
                    {
                        if (user.IsEmailVerified)
                        {

                            int timeout = login.RememberMe ? 525600 : 10;//525600 min = 1 year  condition ? consequent : alternative ternary conditional operator
                            var ticket = new FormsAuthenticationTicket(login.Email, login.RememberMe, timeout);//İncele cookie oluşturuyor timeout dakika cinsinden
                            string encrypted = FormsAuthentication.Encrypt(ticket);
                            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                            cookie.Expires = DateTime.Now.AddMinutes(timeout);
                            cookie.HttpOnly = true;
                            Response.Cookies.Add(cookie);
                            

                            if (Url.IsLocalUrl(ReturnURL))
                            {
                                return RedirectToAction("ProfilePage", "Profile", new { id = user.UserId });
                            }
                            else
                            {
                                return RedirectToAction("ProfilePage", "Profile",new { id=user.UserId });
                            }

                        }
                        else
                        {
                            message = "Please Verify your account!";
                        }
                    }
                    else
                    {
                        message = "Invalid credential provided";
                    }


                }
                else
                {
                    message = "Invalid credential provided";
                }


            }

            ViewBag.Message = message;
            return View();
        }

        //Logout
        [HttpPost]
        [Authorize]//belli koşulu sağlayan kullanıcılar bu methodu uygulayabiliyor
        public ActionResult Logout()//İncele
        {
            FormsAuthentication.SignOut();//Eğer sign out yaparsak oluşturduğumuz cookie'yi siler
            return RedirectToAction("Login", "User");

        }



        [NonAction]
        public bool IsEmailExist(string Email)
        {
            using (LogRegDBEntities1 dataconnection = new LogRegDBEntities1())
            {
                var variable = dataconnection.Users.Where(a => a.Email == Email).FirstOrDefault();

                return variable != null;//Variable null değilse true null ise false dönecek

            }
        }

        //INCELE
        [NonAction]//email ve aktivasyon kodu lazım gönderilecek
        public void SendVerificationLink(string Email, string activitionCode, string emailFor = "VerifyAccount")
        {

            var verifyUrl = "/User/" + emailFor + "/" + activitionCode;
            var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);//Request methodunun Path ve Query'isini değiştiriyor yani .com//sonrasını değiştiriyor. şuanki request'in pathandquery'sinideğiştiriyor.URL kısmı localhost.com olan kısmı

            var fromEmail = new MailAddress("hasanonurcansarihan@gmail.com", "hasanonurcansarihan");
            var toEmail = new MailAddress(Email);
            var fromEmailPassword = "VurucuKahpe17";

            string subject = "";
            string body = "";

            if (emailFor == "VerifyAccount")
            {

                subject = "Your account is succesfully created!";

                body = "<br/><br/> We are excited to tell you that your Email account has been succesfully created. Please click on the link below to verify your account" + "<br/></br><a href='" + link + "'>" + link + "</a> ";

            }

            else if(emailFor=="ResetPassword")
            {
                subject = "Reset Password";
                body = "Hi,<br/><br/> Şifre yenileme isteğiniz alınmıştır. Lütfen aşağıdaki Linke Tıklayınız. <br/><br/> <a href="+link+">" +link+"</a>";


            }


            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword)
            };


            using (var message = new MailMessage(fromEmail, toEmail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })

                smtp.Send(message);//try catch mail gönderemediğinde uyarı tekrar gönderme vb.
        }


        //Forgot Password

        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ForgotPassword(string Email)
        {
            //Verify Email

            string message = "";
            
            using (LogRegDBEntities1 connection = new LogRegDBEntities1())
            {
                var account = connection.Users.Where(a => a.Email == Email).FirstOrDefault();

                if (account != null)
                {
                    //Send email for reset password
                    string resetCode = Guid.NewGuid().ToString();
                    SendVerificationLink(account.Email, resetCode, "ResetPassword");
                    account.ResetPasswordCode = resetCode;

                    connection.Configuration.ValidateOnSaveEnabled = false;//This line is  added for  password not match issue , as we have added  a confirm password property
                    connection.SaveChanges();


                }

                else
                {
                    message = "Account not found";
                }
                ViewBag.Message = message; 
                return View();
            }

        }

        public ActionResult ResetPassword(string id)
        {

            //Verify  the reset password link
            //Find account associated with this link
            //Redirect to reset password page

            using (LogRegDBEntities1 connection = new LogRegDBEntities1())
            {
                var user = connection.Users.Where(a => a.ResetPasswordCode == id).FirstOrDefault();
                if(user!=null)
                {
                    ResetPasswordModel model = new ResetPasswordModel();
                    model.ResetCode = id;
                    return View(model);//ResetPasswordModel oluşturduk bu oluşturduğumuz model üstünden şifre yenileme olayını yapıyoruz. BU sayede ana User class'a dokunmadan hallediyoruz. ViewModel
                }
                else
                {
                    return HttpNotFound();
                }
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ResetPassword(ResetPasswordModel model)
        {
            var message = "";

            if(ModelState.IsValid)
            {
                using (LogRegDBEntities1 connection = new LogRegDBEntities1())
                {
                    var user = connection.Users.Where(a => a.ResetPasswordCode == model.ResetCode).FirstOrDefault();
                    if(user!=null)
                    {
                        user.Password = Crypto.Hash(model.NewPassword);
                        user.ResetPasswordCode = "";//Bir link ile sadece bir kez şifre değiştirilebilmesi için
                        connection.Configuration.ValidateOnSaveEnabled = false;
                        connection.SaveChanges();
                        message = "New password is updated succesfully";

                    }


                }
            }
            else
            {
                message = " Something is invalid";
            }


            ViewBag.Message = message;
            return View(model);
        }

    }


}