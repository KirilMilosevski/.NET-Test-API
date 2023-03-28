using DATA.Entities;
using DATA.Interfaces;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;

        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public Address GetAddressById(int id)
        {
            return _addressRepository.GetAddressById(id);
        }

        public IEnumerable<Address> GetAddresses()
        {
            return _addressRepository.GetAddresses();
        }
    }
}
