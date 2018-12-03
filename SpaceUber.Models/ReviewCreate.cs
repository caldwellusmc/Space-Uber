﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceUber.Models
{
    public class ReviewCreate
    {
        [Required]
        [MinLength(1, ErrorMessage = "Please enter your first name.")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "Please enter your last name")]
        public string LastName { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "Please enter a description.")]
        public string Description { get; set; }

        public override string ToString() => FirstName;
    }
}