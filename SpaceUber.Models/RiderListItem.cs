using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceUber.Models
{
    public class RiderListItem
    {
        [Display(Name ="Rider ID")]
        public int RiderId { get; set; }

        [Display(Name ="First Name")]
        public string FirstName { get; set; }

        [Display(Name ="Last Name")]
        public string LastName { get; set; }

        [Display(Name ="Destination")]
        public string Destination { get; set; }

        // public override string ToString() => FirstName;
        public override string ToString()
        {
            return FirstName;
        }
    }
}
