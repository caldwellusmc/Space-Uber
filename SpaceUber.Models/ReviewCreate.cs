﻿using SpaceUber.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceUber.Models
{
    public class ReviewCreate
    {
        public int DriverId { get; set; }
        //[Required]
        //[MinLength(1, ErrorMessage = "Please enter your first name.")]
       // public string FirstName { get; set; }

        //[Required]
        //[MinLength(1, ErrorMessage = "Please enter your last name")]
        //public string LastName { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "Please enter a description.")]
        public string Description { get; set; }

        public Driver Driver { get; set; }


        private string _fullName;

        public string FullName
        {
            get { return _fullName; }
            set { _fullName = Driver.FirstName + " " + Driver.LastName; }
        }

       // public override string ToString() => FirstName;
    }
}
