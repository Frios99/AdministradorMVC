using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_Ingenieria_web.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="First Name is required")]
        [MaxLength(50, ErrorMessage ="First name should contain maximum fifty characters.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "First Name is required")]
        [MaxLength(50, ErrorMessage = "First name should contain maximum fifty characters.")]
        public string LastName { get; set; }
        public string MobilNumber { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string AddressLine1 { get; set; }
        public string AdressLine2 { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }

    }
}
