using CRUD.Model.Model;
using CRUD.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Repository
{
    public class ContactRepository : RepositoryBase<Contact>, IContactRepository
    {
        public bool AddContact(Contact model)
        {
            Add(model);
            SaveChange();
            return true;
        }
        public bool UpdateContact(Contact model)
        {
        
            AddOrUpdate(model);
            SaveChange();
            return true;
        }
        public IEnumerable<Contact> ReadALL()
        {
            return Read(x => x.Status == EnumStatus.Active, true);
        }
        public bool DeleteContact(Guid Id)
        {
            return DeleteById(Id);
        }

        public Contact GetContactById(Guid Id)
        {
            return Find(Id, x => x.Phones);
        }

    }
}
