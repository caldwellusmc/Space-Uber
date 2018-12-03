using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceUber.Models
{
    public class RiderListItem
    {
        public int RiderId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Destination { get; set; }

        // public override string ToString() => FirstName;
        public override string ToString()
        {
            return FirstName;
        }
    }
}
