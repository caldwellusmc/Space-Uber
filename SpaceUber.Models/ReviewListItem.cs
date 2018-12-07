using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceUber.Models
{
    public class ReviewListItem
    {
        [Display(Name ="Review ID")]
        public int ReviewId { get; set; }

        [Display(Name ="Driver's First Name")]
        public string FirstName { get; set; }

        [Display(Name ="Driver's Last Name")]
        public string LastName { get; set; }

        [Display(Name ="Description")]
        public string Description { get; set; }

        //public override string ToString() => FirstName;
    }
}
