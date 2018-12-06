using SpaceUber.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceUber.Models
{
    public class ReviewDetail
    {
        [Display(Name ="Review ID")]
        public int ReviewId { get; set; }

        [Display(Name ="First Name")]
        public string FirstName { get; set; }

        [Display(Name ="Last Name")]
        public string LastName { get; set; }

        [Display(Name ="Description")]
        public string Description { get; set; }

        public int DriverId { get; set; }

        public Driver Driver { get; set; }

        public override string ToString() => $"[{ReviewId}]";
    }
}
