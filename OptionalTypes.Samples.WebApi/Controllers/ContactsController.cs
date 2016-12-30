using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;
using System.Web.Mvc;
using OptionalTypes.Samples.WebApi.domain;
//using System.Web.Mvc;
using OptionalTypes.Samples.WebApi.repository;
using OptionalTypes.Samples.WebApi.dtos;
using OptionalTypes.Samples.WebApi.mappers;
//using Swashbuckle.Swagger;

namespace OptionalTypes.Samples.WebApi.Controllers
{
 
    public class ContactsController : ApiController
    {
        private IContactRepository _contactRepository;

        public ContactsController()
        {
            _contactRepository = new InMemoryContactRepository();
        }

           [System.Web.Http.Route("api/contacts")]
                // GET api/values
                [System.Web.Http.HttpGet]
                [ResponseType(typeof(IEnumerable<ContactDto>))]
                public IHttpActionResult Get()
                {
                    return Ok(_contactRepository.GetAll().Select(x =>
                    {
                        var contactDto = new ContactDto();

                        ContactMapper.Map(x, contactDto);
                        return contactDto;
                    }));
                }
       
                [System.Web.Http.Route("api/contacts/{id}")]
                [System.Web.Http.HttpGet()]
                [ResponseType(typeof(ContactDto))]
                
                public IHttpActionResult Get(int id)
                {
                    Contact contact = _contactRepository.Get(id);
                    if (contact == null)
                        return NotFound();

                    var contactDto = new ContactDto();
                    ContactMapper.Map(contact, contactDto);
                    return  Ok(contactDto);
                }

        [System.Web.Http.Route("api/contacts")]

        [System.Web.Http.HttpPost]
               public IHttpActionResult Post([FromBody] ContactDto contactDto)
               {
                   if (!ModelState.IsValid)
                       return BadRequest();

                   var contact = new Contact()
                   {
                       Id = _contactRepository.GetAll().Count() + 1
                   };

                   ContactMapper.Map(contactDto, contact);
                   _contactRepository.Save(contact);

                   return Ok();
               }

        [System.Web.Http.Route("api/contacts")]

        [System.Web.Http.HttpPut()]
               public IHttpActionResult Put(int id,
                   [FromBody] ContactDto contactDto)
               {

                   Contact contact = _contactRepository.Get(id);
                   if (contact == null)
                       return  NotFound();

                   ContactMapper.Map(contactDto, contact);

                   _contactRepository.Save(contact);

                   return Ok();
               }
      
    }

}
