using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using OptionalTypes.Samples.NetCore.domain;
using OptionalTypes.Samples.NetCore.dtos;
using OptionalTypes.Samples.NetCore.mappers;
using OptionalTypes.Samples.NetCore.repository;

namespace OptionalTypes.Samples.NetCore.Controllers
{
    [Route("api/[controller]")]
    public class ContactsController : Controller
    {
        private readonly IContactRepository _contactRepository;

        public ContactsController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }


        [HttpGet]
        [Produces(typeof(IEnumerable<ContactDto>))]
        public IActionResult Get()
        {
            return new OkObjectResult(_contactRepository.GetAll().Select(x =>
            {
                var contactDto = new ContactDto();

                ContactMapper.Map(x, contactDto);
                return contactDto;
            }));
        }

        [HttpGet("{id}")]
        [Produces(typeof(ContactDto))]
        public IActionResult Get(int id)
        {
            var contact = _contactRepository.Get(id);
            if (contact == null)
                return new NotFoundResult();

            var contactDto = new ContactDto();
            ContactMapper.Map(contact, contactDto);
            return new OkObjectResult(contactDto);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ContactDto contactDto)
        {
            if (!ModelState.IsValid)
                return new BadRequestObjectResult(ModelState);

            var contact = new Contact
            {
                Id = _contactRepository.GetAll().Count() + 1
            };

            ContactMapper.Map(contactDto, contact);
            _contactRepository.Save(contact);

            return new OkResult();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id,
            [FromBody] ContactDto contactDto)
        {
            var contact = _contactRepository.Get(id);
            if (contact == null)
                return new NotFoundResult();

            ContactMapper.Map(contactDto, contact);

            _contactRepository.Save(contact);

            return new OkResult();
        }
    }
}