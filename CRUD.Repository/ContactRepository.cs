using CRUD.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Repository
{
    public class ContactRepository : RepositoryBase<Contact>, IContactRepository
    {
        public void AddContact(Contact model)
        {
            Add(model);
            SaveChange();
        }
        public IEnumerable<Contact> ReadALL()
        {
            return Read(x => x.Status == EnumStatus.Active, true);
        }
        public bool DeleteContact(Guid Id)
        {
            return DeleteById(Id);
        }

    }
}
