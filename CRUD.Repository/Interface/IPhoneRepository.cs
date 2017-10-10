using CRUD.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Repository.Interface
{
    public interface IPhoneRepository
    {
        IEnumerable<Phone> ReadPhonesByContact(Guid Id);
        bool AddPhone(Phone model);
        bool UpdatePhone(Phone model);
        bool DeletePhone(Guid Id);
    }
}
