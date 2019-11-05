using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace BitirmeProjesi.Models
{//Validation eklenecek buraya .Extended'ı sildik çünkü User.cs'in partial class'ı olmasını istiyoruz

    [MetadataType(typeof(UserMetadata))]
    public partial class User
    {
         public string ConfirmPassword { get; set; }//Ado.net entity model'in user classında olmadığından buradaknie ekledik partial class ile ayrı bir şekilde tanımlıyoruz compile olurken birlikte oluyor.

    }

    public class UserMetadata
    {
        [Display(Name = "First Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "First name required")]
        public string FirstName { get; set; }


        [Display(Name = "Last Name")]
        [Required(AllowEmptyStrings =false,ErrorMessage ="Last name required")]
        public string LastName { get; set; }


        [Display(Name = "Email")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email ID required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name ="Date of Birth")]
        [Required(AllowEmptyStrings = false, ErrorMessage = " Birth required")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode =true,DataFormatString ="{0:MM/dd/yyyy}")]
        public DateTime DateOfBirth { get; set; }

        [Required(AllowEmptyStrings =false,ErrorMessage ="Password is required")]
        [DataType(DataType.Password)]
        [MinLength(6,ErrorMessage ="Minimum 6 characters required")]
        public string Password { get; set; }

        [Display(Name ="Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Confirm password and password does not match")]
        public string ConfirmPassword { get; set; }
    }
}