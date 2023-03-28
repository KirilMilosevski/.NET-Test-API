using DATA.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniversityApplication.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;
        private readonly ILogger<AddressController> _logger;

        public AddressController(ILogger<AddressController> logger, IAddressService addressService)
        {
            _addressService = addressService;
            _logger = logger;
        }

        [HttpGet]
        [Route("GetAllAddresses")]
        public IEnumerable<Address> GetAddresses()
        {
            var addresses = _addressService.GetAddresses();

            return addresses;
        }

        [HttpGet]
        [Route("GetAddressById")]
        public IActionResult GetAddressById(int id)
        {
            Address address = _addressService.GetAddressById(id);

            if (address == null)
            {
                return NotFound("Address with that id does not exist!");
            }

            return Ok(address);
        }
    }
}
