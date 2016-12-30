﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OptionalTypes;
namespace OptionalTypes.Samples.WebApi.dtos
{
    public class ContactDto
    {
       
            public Optional<string> FirstName { get; set; }
            public Optional<string> LastName { get; set; }
            public Optional<string> StreetAddress { get; set; }
            public Optional<long?> CountryId { get; set; }
            public Optional<DateTime?> DateOfBirth { get; set; }


       
    }
}