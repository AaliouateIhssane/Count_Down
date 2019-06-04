using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace TP2_ASP.NET_Final_.Models
{
    public class MessageClass
    {
        [Required(ErrorMessage = "Enter Email !")]
        [Display(Name = "Email:")]
        [DataType(DataType.EmailAddress)]
        [StringLength(maximumLength: 20, MinimumLength = 9, ErrorMessage = "Email lenght must be max 20 & min 9")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter username !")]
        [Display(Name = "UserName:")]
        [StringLength(maximumLength: 20, MinimumLength = 3, ErrorMessage = "Username lenght must be max 20 & min 3")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Enter Message !")]
        [Display(Name = "Message:")]
        [StringLength(maximumLength: 300, MinimumLength = 3, ErrorMessage = "Message lenght must be max 300 & min 3")]
        public string mssg { get; set; }

       
    }
}