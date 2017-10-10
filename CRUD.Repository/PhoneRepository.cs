using CRUD.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Repository
{
    public class PhoneRepository : RepositoryBase<Phone>, IPhoneRepository
    {
        public IEnumerable<Phone> ReadPhonesByContact(Guid Id)
        {
            return Read(x => x.IdContact == Id && x.Status == EnumStatus.Active, true);
        }
    }
}
