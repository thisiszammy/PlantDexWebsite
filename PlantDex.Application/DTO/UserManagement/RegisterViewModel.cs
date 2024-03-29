﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PlantDex.Application.DTO.UserManagement
{
    public class RegisterViewModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Username { get; set; }
        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        [Required]
        [StringLength(16, MinimumLength = 8)]
        public string Password { get; set; }
        [Required]
        [StringLength(16, MinimumLength = 8)]
        public string ConfirmPassword { get; set; }
        public string AccountType { get; set; }
    }
}
