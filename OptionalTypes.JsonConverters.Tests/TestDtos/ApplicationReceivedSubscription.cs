namespace OptionalTypes.JsonConverters.Tests.TestDtos
{
    public class ApplicationReceivedSubscription
    { 
        public Optional<string> SomeString { get; set; }
        public Optional<ApplicationReceived> Criteria { get; set; }
        public string SubscriptionUri { get; set; }

    }
}