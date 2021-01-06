using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PlantDex.Application.DataTransferObjects.Authentication
{
    public class LoginViewModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public strsing Password { get; set; }
    }
}
