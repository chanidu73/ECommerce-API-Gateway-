using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserService.Models
{
    public class RegisterModel
    {
        [Key]
        public string Username {get;set; }
        public string Email { set; get;}
        public string Password { get;set; }
        public string Role { get;set; }
    }
}