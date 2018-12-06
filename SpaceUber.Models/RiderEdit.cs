using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceUber.Models
{
    public class RiderEdit
    {
        [Display(Name ="Rider ID")]
        public int RiderId { get; set; }

        [Display(Name ="First Name")]
        [MinLength(1, ErrorMessage = "Please enter your first name.")]
        public string FirstName { get; set; }

        [Display(Name ="Last Name")]
        [MinLength(1, ErrorMessage = "Please enter your last name.")]
        public string LastName { get; set; }

        [Display(Name ="Destination")]
        [MinLength(1, ErrorMessage = "Please enter a destination.")]
        public string Destination { get; set; }
    }
}
