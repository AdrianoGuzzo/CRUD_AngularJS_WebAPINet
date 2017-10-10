using CRUD.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Service
{
    public interface IContactService
    {
        bool AddContact(Contact model);
        List<object> ReadALL();
        bool DeleteContact(Guid Id);
        List<object> ReadPhonesByContact(Guid Id);
    }
}
