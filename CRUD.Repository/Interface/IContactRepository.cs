using CRUD.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Repository.Interface
{
    public interface IContactRepository
    {
        bool AddContact(Contact model);
        bool UpdateContact(Contact model);
        IEnumerable<Contact> ReadALL();
        bool DeleteContact(Guid Id);
        Contact GetContactById(Guid Id);
    }
}
