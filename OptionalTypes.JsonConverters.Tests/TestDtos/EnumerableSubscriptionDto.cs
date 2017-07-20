using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OptionalTypes.JsonConverters.Tests.TestDtos
{
    public class EnumerableSubscriptionDto
    {
        public Optional<IEnumerable<string>> StringList { get; set; }
        public string SubscriptionUri { get; set; }
    }
}
