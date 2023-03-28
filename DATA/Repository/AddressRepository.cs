using DATA.Entities;
using DATA.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.Repository
{
        public class AddressRepository : IAddressRepository
        {
            private readonly DataContext _dataContext;

            public AddressRepository(DataContext dataContext)
            {
                _dataContext = dataContext;
            }

            public Address GetAddressById(int id)
            {
                return _dataContext.Addresses.FirstOrDefault(x => x.Id == id);
            }

            public IEnumerable<Address> GetAddresses()
            {
                return _dataContext.Addresses.ToList();
            }
        
    }
}
