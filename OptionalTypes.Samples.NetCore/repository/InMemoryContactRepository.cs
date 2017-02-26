using System.Collections.Generic;
using System.Linq;
using OptionalTypes.Samples.NetCore.domain;

namespace OptionalTypes.Samples.NetCore.repository
{
    public class InMemoryContactRepository : IContactRepository
    {
        private readonly Dictionary<int, Contact> _contacts = new Dictionary<int, Contact>();

        public Contact Get(int id)
        {
            return _contacts.ContainsKey(id) ? _contacts[id] : null;
        }

        public void Save(Contact contact)
        {
            _contacts[contact.Id] = contact;
        }

        public IEnumerable<Contact> GetAll()
        {
            return _contacts.Values.ToList();
        }
    }
}