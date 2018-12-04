using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceUber.Models
{
    public class DriverCreate
    {
        [Required]
        [MinLength(1, ErrorMessage = "Please enter your first name.")]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "Please enter your last name")]
        [Display(Name ="Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name ="Age")]
        public int Age { get; set; }

        [Required]
        [Display(Name ="License Number")]
        public int LicenseNumber{ get; set; }

        [Required]
        [MinLength(4, ErrorMessage = "Please enter at least 4 characters")]
        [Display(Name ="Spaceship Make")]
        public string SpaceshipMake { get; set; }

        public override string ToString() => FirstName;
    }
}
