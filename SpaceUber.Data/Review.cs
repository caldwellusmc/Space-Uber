using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceUber.Data
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        //[Required]
        //public string FirstName { get; set; }

        //[Required]
        //public string LastName { get; set; }

        [Required]
        public string Description { get; set; }

        public int DriverId { get; set; }

        public virtual Driver Driver { get; set; }

    }
}
