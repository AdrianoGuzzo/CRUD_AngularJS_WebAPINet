using CRUD.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Service.Interface
{
    public interface IContactService
    {
        bool AddContact(Contact model);
        bool UpdateContact(Contact model);
        bool DeleteContact(Guid Id);
        List<object> ReadALL();       
        List<object> ReadPhonesByContact(Guid Id);
        bool DeletePhone(Guid Id);
        object GetContactById(Guid Id);
        
    }
}
