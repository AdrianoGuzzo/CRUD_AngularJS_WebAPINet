using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Model.Model
{
    public class Contact : ModelBase
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public DateTime Birthday { get; set; }

        public ICollection<Phone> Phones { get; set; }
    }
}
