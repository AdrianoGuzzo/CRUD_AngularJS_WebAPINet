using CRUD.Model.Model;
using CRUD.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Service
{
    public class ContactService : ServiceBase, IContactService
    {
        IContactRepository contactRepository;
        public ContactService()
        {
            contactRepository = new ContactRepository();
        }

        public bool AddContact(Contact model)
        {
            if (model.Phones != null)
                Parallel.ForEach(model.Phones, (phone) =>
                {
                    phone.Id = Guid.NewGuid();
                    phone.DateCreate = DateTime.Now;
                    phone.Status = EnumStatus.Active;
                });
            contactRepository.AddContact(model);
            return true;
        }

        public List<object> ReadALL()
        {
            return contactRepository.ReadALL().Select(x => new
            {
                Id = x.Id,
                Birthday = x.Birthday.ToString("dd/MM/yyyy"),
                Name = x.Name,
                Email = x.Email
            }).ToList<object>();

        }
        public bool DeleteContact(Guid Id)
        {
            return contactRepository.DeleteContact(Id);
        }

        public List<object> ReadPhonesByContact(Guid Id)
        {
            IPhoneRepository phoneRepository = new PhoneRepository();
            return phoneRepository.ReadPhonesByContact(Id).Select(x => new
            {
                Number = x.Number
            }).ToList<object>();
        }

    }
}
