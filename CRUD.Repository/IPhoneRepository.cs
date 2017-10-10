using CRUD.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Repository
{
    public interface IPhoneRepository
    {
        IEnumerable<Phone> ReadPhonesByContact(Guid Id);
    }
}
