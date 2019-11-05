using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BitirmeProjesi.Models
{

    //Bu class Login.cshtml'e girilen bilgileri topluyor ve bu girilen bilgilere göre users dbsindeki bilgilerle kıyaslıyor bilgiler doğruysa ticket oluşturup kullanıcının login bilgilerini remember me gibi bilgileri belli bir süre zarfında tutacak bir cookie oluşturuyor.
    public class UserLogin
    {

        [Display(Name ="Email")]
        [Required(AllowEmptyStrings =false,ErrorMessage ="Email ID Required")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password Required")]
        public string Password { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }



    }
}