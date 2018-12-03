using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceUber.Models
{
    public class RiderCreate
    {
        [Required]
        [MinLength(1, ErrorMessage = "Please enter your first name.")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "Please enter your last name")]
        public string LastName { get; set; }

        [Required]
        [MinLength(1, ErrorMessage ="Please enter a destination.")]
        public string Destination { get; set; }

        public override string ToString() => FirstName;
    }
}
