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
        public string FirstName { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "Please enter your last name")]
        public string LastName { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "Please enter your age")]
        [MaxLength(3, ErrorMessage = "Invalid Response, too many characters")]
        public int Age { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "Please enter at least 5 numbers")]
        public int LicenseNumber{ get; set; }

        [Required]
        [MinLength(4, ErrorMessage = "Please enter at least 4 characters")]
        public string SpaceshipMake { get; set; }

        public override string ToString() => FirstName;
    }
}
