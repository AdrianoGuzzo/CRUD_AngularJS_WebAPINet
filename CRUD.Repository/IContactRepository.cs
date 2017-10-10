using CRUD.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Repository
{
    public interface IContactRepository
    {
        void AddContact(Contact model);
        IEnumerable<Contact> ReadALL();
        bool DeleteContact(Guid Id);
    }
}
