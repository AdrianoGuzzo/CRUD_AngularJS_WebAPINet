using CRUD.Model.Model;
using CRUD.Repository.Interface;
using CRUD.Service.Interface;
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
        IPhoneRepository phoneRepository;
        public ContactService()
        {
            contactRepository = GetContactRepository();
            phoneRepository = GetPhoneRepository();
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
        public bool UpdateContact(Contact model)
        {
            foreach (Phone phone in model.Phones.Where(x => x.Id == Guid.Empty))
            {
                phone.Id = Guid.NewGuid();
                phone.IdContact = model.Id;
                phoneRepository.AddPhone(phone);
            }
            contactRepository.UpdateContact(model);
            
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
        public bool DeleteContact(Guid Id) => contactRepository.DeleteContact(Id);


        public List<object> ReadPhonesByContact(Guid Id)
        {
            return phoneRepository.ReadPhonesByContact(Id).Select(x => new
            {
                Number = x.Number
            }).ToList<object>();
        }
        public bool DeletePhone(Guid Id) => phoneRepository.DeletePhone(Id);


        public object GetContactById(Guid Id)
        {
            Contact model = contactRepository.GetContactById(Id);
            return new
            {
                Id = model.Id,
                Name = model.Name,
                Email = model.Email,
                Birthday = model.Birthday,
                DateCreate = model.DateCreate,
                Status = (int)model.Status,
                Phones = model.Phones.Where(x => x.Status == EnumStatus.Active).Select(x => new { Id = x.Id, IdContact = x.IdContact, Number = x.Number, Status = (int)x.Status, DateCreate = x.DateCreate }).ToList()
            };
        }

    }
}
