using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Optionals.Samples.NetCore.domain;
using Optionals.Samples.NetCore.dtos;
using Optionals.Samples.NetCore.mappers;
using Optionals.Samples.NetCore.repository;

namespace Optionals.Samples.NetCore.Controllers
{
    [Route("api/[controller]")]
    public class ContactsController : Controller
    {
        private IContactRepository _contactRepository;

        public ContactsController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }


        [HttpGet]
        [Produces(typeof(IEnumerable<Contact>))]
        public IActionResult Get()
        {
            return new OkObjectResult(_contactRepository.GetAll());
        }

        [HttpGet("{id}")]
        [Produces(typeof(Contact))]

        public IActionResult Get(int id)
        {
            Contact contact = _contactRepository.Get(id);
            return contact == null ? new NotFoundResult() as IActionResult : new OkObjectResult(contact) as IActionResult;
        }

        [HttpPost]
        public IActionResult Post([FromBody]ContactDto contactDto)
        {
            if (!ModelState.IsValid)
                return new BadRequestObjectResult(ModelState);

            var contact = new Contact();
            ContactMapper.Map(contactDto, contact);
            _contactRepository.Save(contact);

            return new OkResult();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]ContactDto contactDto)
        {
           
            Contact contact = _contactRepository.Get(id);
            if (contact == null)
                return new NotFoundResult();

            ContactMapper.Map(contactDto, contact);

            _contactRepository.Save(contact);

            return new OkResult();
        }

       
    }
}
