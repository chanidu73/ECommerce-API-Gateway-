using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserService.Models
{
    public class AuthModel
    {
        [Key]
        public string Token  {get;set;  }
        public string RefreshToken  {get; set; }
        public DateTime TokenExpiration  {get;set ;}
    }
}