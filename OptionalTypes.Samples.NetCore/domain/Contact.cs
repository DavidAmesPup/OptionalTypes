using System;

namespace OptionalTypes.Samples.NetCore.Domain
{
    /// <summary>
    ///     Sample domain object. Of course, in a real application, this would live in a different project.
    /// </summary>
    public class Contact
    {
        public int Id;
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string StreetAddress { get; set; }
        public long? CountryId { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}