using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceUber.Models
{
    public class DriverListItem
    {
        [Display(Name ="Drive Id")]
        public int DriverId { get; set; }

        [Display(Name ="First Name")]
        public string FirstName { get; set; }

        [Display(Name ="Last Name")]
        public string LastName { get; set; }

        [Display(Name ="Age")]
        public int Age { get; set; }

        [Display(Name ="License Number")]
        public int LicenseNumber { get; set; }

        [Display(Name ="Spaceship Make")]
        public string SpaceshipMake { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
