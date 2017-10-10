using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Model.Model
{
    public abstract class ModelBase
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime? DateCreate { get; set; }
        public DateTime? DateAlter { get; set; }
        public EnumStatus Status { get; set; }
    }
}
