using OptionalTypes.Samples.NetCore.dtos;
using OptionalTypes.Samples.NetCore.Domain;

namespace OptionalTypes.Samples.NetCore.mappers
{
    public static class ContactMapper
    {
        public static void Map(ContactDto source,
            Contact dest)
        {
            dest.FirstName = source.FirstName.GetValueOrDefault(dest.FirstName);
            dest.LastName = source.LastName.GetValueOrDefault(dest.LastName);
            dest.StreetAddress = source.StreetAddress.GetValueOrDefault(dest.StreetAddress);
            dest.DateOfBirth = source.DateOfBirth.GetValueOrDefault(dest.DateOfBirth);
            dest.CountryId = source.CountryId.GetValueOrDefault(dest.CountryId);
        }

        public static void Map(Contact source,
            ContactDto dest)
        {
            dest.CountryId = source.CountryId;
            dest.DateOfBirth = source.DateOfBirth;
            dest.FirstName = source.FirstName;
            dest.LastName = source.LastName;
            dest.StreetAddress = source.StreetAddress;
        }
    }
}