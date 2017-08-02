using System.Collections.Generic;

namespace OptionalTypes.JsonConverters.Tests.TestDtos
{
    public class EnumerableSubscriptionDto
    {
        public Optional<IEnumerable<string>> StringList { get; set; }
        public string SubscriptionUri { get; set; }
    }
}