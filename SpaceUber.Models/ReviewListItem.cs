﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceUber.Models
{
    public class ReviewListItem
    {
        public int ReviewId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }

        public override string ToString() => FirstName;
    }
}
