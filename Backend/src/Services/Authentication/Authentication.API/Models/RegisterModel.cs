﻿using Microsoft.AspNetCore.Identity;

namespace Authentication.API.Models
{
    public class RegisterModel
    {
        public string FullName {  get; set; } 
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }    
        public DateTime CreatedDate { get; set; }
    }
}
