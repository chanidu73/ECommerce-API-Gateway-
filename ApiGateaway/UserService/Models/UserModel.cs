using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserService.Models
{
    public class UserModel
    {
        [Key]
        public int UserId { get;set; }
        public string Username { get;set; }
        public string Email  {get;set; }
        public string PasswordHash  { get;set; }
        public string Role { get;set; }
        public DateTime CreatedDate { get;set; }
    }
}