namespace OptionalTypes.JsonConverters.Tests.TestDtos
{
    public enum SomeEnum
    {
        TitleCase
    }

    public class EnumDto
    {
        public Optional<SomeEnum> Value { get; set; }
    }
}