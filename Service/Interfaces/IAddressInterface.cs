﻿using DATA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IAddressService
    {
        IEnumerable<Address> GetAddresses();
        Address GetAddressById(int id);

    }
}
