using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace CRUD_Ingenieria_web.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string role { get; set; } // role = "admin" , role = "user"

        [Required(ErrorMessage ="Username is required.")]
        [Display(Name ="Username")]       
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }

        [Compare("Password",ErrorMessage = "This field must be equal to password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
