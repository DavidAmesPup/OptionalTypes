using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Optionals.Types;

namespace Optionals.Samples.NetCore.dtos
{
    public class ContactDto
    {
        public Optional<string> FirstName { get; set; }
        public Optional<string> LastName { get; set; }
        public Optional<string> StreetAddress { get; set; }
        public Optional<Nullable<Int64>> CountryId { get; set; }
        public Optional<DateTime?> DateOfBirth { get; set; }

    }
}
