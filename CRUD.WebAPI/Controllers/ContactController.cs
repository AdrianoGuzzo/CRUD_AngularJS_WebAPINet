using CRUD.Model.Model;
using CRUD.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CRUD.WebAPI.Controllers
{
    public class ContactController : ApiControllerBase
    {
        private readonly IContactService ContactService;
        public ContactController(IContactService _ContactService)
        {
            ContactService = _ContactService;
        }

        [HttpPost]
        [Route("api/contact/save")]
        public object SaveContact(Contact model)
        {
            try
            {
                return new { Status = ContactService.AddContact(model) };
            }
            catch (Exception ex)
            {
                return new { Status = false, erros = returnError(ex) };
            }
        }

        [HttpGet]
        [Route("api/contact/list")]
        public object ListContact()
        {
            try
            {
                return new { Status = true, Data = ContactService.ReadALL() };
            }
            catch (Exception ex)
            {
                return new { Status = false, erros = returnError(ex) };
            }
        }

        [HttpDelete]
        [Route("api/contact/delete/{Id}")]
        public object DeleteContact(Guid Id)
        {
            try
            {
                return new { Status = ContactService.DeleteContact(Id) };
            }
            catch (Exception ex)
            {
                return new { Status = false, erros = returnError(ex) };
            }
        }

        [HttpGet]
        [Route("api/contact/phones/{Id}")]
        public object ListPhonesByContact(Guid Id)
        {
            try
            {
                return new { Status = true, Data = ContactService.ReadPhonesByContact(Id) };
            }
            catch (Exception ex)
            {
                return new { Status = false, erros = returnError(ex) };
            }
        }

        [HttpGet]
        [Route("api/contact/get/{Id}")]
        public object GetContact(Guid Id)
        {
            try
            {
                return new { Status = true, Data = ContactService.GetContactById(Id) };
            }
            catch (Exception ex)
            {
                return new { Status = false, erros = returnError(ex) };
            }
        }
        [HttpPut]
        [Route("api/contact/update")]
        public object UpdateContact(Contact model)
        {
            try
            {
                return new { Status = true, Data = ContactService.UpdateContact(model) };
            }
            catch (Exception ex)
            {
                return new { Status = false, erros = returnError(ex) };
            }
        }
        [HttpDelete]
        [Route("api/contact/deletePhone/{Id}")]
        public object DeletePhone(Guid Id)
        {
            try
            {
                return new { Status = true, Data = ContactService.DeletePhone(Id) };
            }
            catch (Exception ex)
            {
                return new { Status = false, erros = returnError(ex) };
            }
        }

    }
}
