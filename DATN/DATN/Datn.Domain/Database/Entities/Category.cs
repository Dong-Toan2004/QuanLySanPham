using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datn.Domain.Database.Entities
{
    public class Category
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Phải nhập tên")]
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
