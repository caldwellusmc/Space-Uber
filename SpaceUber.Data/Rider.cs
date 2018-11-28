using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceUber.Data
{
    public class Rider
    {
        public int RiderId { get; set; }
        public Guid OwnerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Destination { get; set; }
        public int ReviewId { get; set; }
    }
}
