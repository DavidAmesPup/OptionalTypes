namespace OptionalTypes.JsonConverters.Tests.TestDtos
{
    public class ApplicationReceived
    {
        public Optional<string> FirstName { get; set; }
        public Optional<string> LastName { get; set; }
        public Optional<string> Company { get; set; }
        public Optional<string> EmailAddres { get; set; }
        public Optional<string> Position { get; set; }
        public Optional<int> BrandId { get; set; }
        public Optional<int> DepartmentId { get; set; }
    }
}