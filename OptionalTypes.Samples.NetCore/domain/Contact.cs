﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Optionals.Samples.NetCore.domain
{
    /// <summary>
    /// Sample domain object. Of course, in a real application, this would live in a different project.
    /// </summary>
    public class Contact
    {
        public int Id;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        public string StreetAddress { get; set; }
        public int? CountryId { get; set; }
        public DateTime? DateOfBirth { get; set; }

    }
}
