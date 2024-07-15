using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datn.Domain.Database.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Phải nhập user")]
        public string UserName { get; set; }
        [Required(ErrorMessage ="Phải nhập PassWord")]
        public string PassWord { get; set; }
        public virtual Cart Cart { get; set; }
    }
}
