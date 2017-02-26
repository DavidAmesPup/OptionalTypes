using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using OptionalTypes.Samples.WebApi.domain;
using OptionalTypes.Samples.WebApi.dtos;
using OptionalTypes.Samples.WebApi.mappers;
using OptionalTypes.Samples.WebApi.repository;
//using System.Web.Mvc;

//using Swashbuckle.Swagger;

namespace OptionalTypes.Samples.WebApi.Controllers
{
    public class ContactsController : ApiController
    {
        private readonly IContactRepository _contactRepository;

        public ContactsController()
        {
            _contactRepository = new InMemoryContactRepository();
        }

        [Route("api/contacts")]
        // GET api/values
        [HttpGet]
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

        [Route("api/contacts/{id}")]
        [HttpGet]
        [ResponseType(typeof(ContactDto))]
        public IHttpActionResult Get(int id)
        {
            var contact = _contactRepository.Get(id);
            if (contact == null)
                return NotFound();

            var contactDto = new ContactDto();
            ContactMapper.Map(contact, contactDto);
            return Ok(contactDto);
        }

        [Route("api/contacts")]
        [HttpPost]
        public IHttpActionResult Post([FromBody] ContactDto contactDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var contact = new Contact
            {
                Id = _contactRepository.GetAll().Count() + 1
            };

            ContactMapper.Map(contactDto, contact);
            _contactRepository.Save(contact);

            return Ok();
        }

        [Route("api/contacts")]
        [HttpPut]
        public IHttpActionResult Put(int id,
            [FromBody] ContactDto contactDto)
        {
            var contact = _contactRepository.Get(id);
            if (contact == null)
                return NotFound();

            ContactMapper.Map(contactDto, contact);

            _contactRepository.Save(contact);

            return Ok();
        }
    }
}