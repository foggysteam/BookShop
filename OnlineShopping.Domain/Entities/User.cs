using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OnlineShopping.Domain.Entities
{
    public class User
    {
        [Key]
        [Display(Name = "User ID:")]
        public int UserId { get; set; }
        [Required(ErrorMessage = "Please enter a User name.")]
        [Display(Name = "User name:")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Please enter a Password.")]
        [Display(Name = "Password:")]
        public string Password { get; set; }
    }
}
