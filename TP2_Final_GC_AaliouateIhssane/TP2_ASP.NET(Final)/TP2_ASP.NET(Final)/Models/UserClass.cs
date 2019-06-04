using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TP2_ASP.NET_Final_.Models
{
    public class UserClass
    {
        [Required(ErrorMessage ="Enter username !")]
        [Display(Name ="UserName:")]
        [StringLength(maximumLength:25,MinimumLength =3,ErrorMessage ="Username lenght must be max 25 & min 3")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Enter the password !")]
        [Display(Name = "Password:")]
        [DataType(DataType.Password)]
        public string UserPassword { get; set; }

        [Required(ErrorMessage = "Enter the Confirm_password !")]
        [Display(Name = "Confirm_Password:")]
        [DataType(DataType.Password)]
        [Compare("UserPassword")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Enter the job !")]
        [Display(Name = "Job:")]
        [StringLength(maximumLength: 25, MinimumLength = 7, ErrorMessage = "Job lenght must be max 25 & min 7")]
        public string job { get; set; }

        [Required(ErrorMessage = "Enter Email !")]
        [Display(Name = "Email:")]
        [DataType(DataType.EmailAddress)]
        [StringLength(maximumLength: 40, MinimumLength = 10, ErrorMessage = "Job lenght must be max 40 & min 10")]
        public string email { get; set; }

        [Required(ErrorMessage = "Upload profile image !")]
        [Display(Name = "Profile_image:")]
        [StringLength(maximumLength: 15, MinimumLength = 7, ErrorMessage = "image lenght must be max 15 & min 7")]

        public string Photo { get; set; }
    }
}