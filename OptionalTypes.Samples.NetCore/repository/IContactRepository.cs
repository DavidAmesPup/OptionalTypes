﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OptionalTypes.Samples.NetCore.domain;

namespace OptionalTypes.Samples.NetCore.repository
{
    public interface IContactRepository
    {
        IEnumerable<Contact> GetAll();
        Contact Get(int id);
        void Save(Contact contact);

    }
}
