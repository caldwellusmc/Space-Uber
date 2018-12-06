using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceUber.Data
{
    public class Driver
    {
        [Key]
        public int DriverId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public int LicenseNumber { get; set; }

        [Required]
        public string SpaceshipMake { get; set; }

        private string _fullName;

        public string FullName
        {
            get { return _fullName; }
            set { _fullName = FirstName + " " + LastName; }
        }


    }
}
