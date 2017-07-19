using System.Collections.Generic;
using OptionalTypes.Samples.NetCore.Domain;

namespace OptionalTypes.Samples.NetCore.Repository
{
    public interface IContactRepository
    {
        IEnumerable<Contact> GetAll();
        Contact Get(int id);
        void Save(Contact contact);
    }
}