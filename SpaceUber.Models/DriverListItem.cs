using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceUber.Models
{
    public class DriverListItem
    {
        public int DriverId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int LicenseNumber { get; set; }
        public string SpaceshipMake { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
