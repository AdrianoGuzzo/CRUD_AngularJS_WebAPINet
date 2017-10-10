using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Model.Model
{
    public class Phone : ModelBase
    {
        public string Number { get; set; }

        public Guid IdContact {get;set;}

        [ForeignKey("IdContact")]
        public Contact Contact { get; set; }
    }
}
