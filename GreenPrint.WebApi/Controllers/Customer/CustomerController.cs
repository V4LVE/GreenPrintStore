using GreenPrint.Service.DataTransferObjects;
using GreenPrint.Service.Interfaces;
using GreenPrint.Service.Services;
using GreenPrint.WebApi.ExtensionMethods;
using GreenPrint.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace GreenPrint.WebApi.Controllers.Customer
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        #region
        private readonly ICustomerService _CustomerService;
        private readonly ILogger<CustomerController> _logger;
        #endregion

        #region Constructor
        public CustomerController(ICustomerService CustomerService, ILogger<CustomerController> logger)
        {
            _CustomerService = CustomerService;
            _logger = logger;
        }
        #endregion





       

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(CustomerModel Customer)
        {
            var CustomersDto = Customer.MapCustomerToDtoTHIS();

            try
            {
                await _CustomerService.CreateAsync(CustomersDto);
                return CreatedAtAction("GetCustomers", CustomersDto);
            }
            catch (Exception e)
            {
                return UnprocessableEntity(e.Message);
            }
        }

        [HttpDelete]
        [Route("remove/{CustomerId:int}")]
        public async Task<IActionResult> Remove(int CustomerId)
        {
            var Customer = await _CustomerService.GetByIdAsync(CustomerId);

            if (Customer == null)
                return NotFound();

            try
            {
                await _CustomerService.DeleteAsync(Customer);
                return NoContent(); // Success
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return UnprocessableEntity(e.Message);
            }
        }

        [HttpPut]
        [Route("edit")]
        public async Task<IActionResult> Edit(CustomerDTO Customer)
        {
            try
            {
                await _CustomerService.UpdateAsync(Customer);
                return CreatedAtAction("GetCustomer", new { CustomerId = Customer.Id }, Customer);
            }
            catch (Exception e)
            {
                return UnprocessableEntity(e.Message);
            }
        }

        [HttpPatch]
        [Route("update/{CustomerId:int}")]
        public async Task<IActionResult> EditPartially(int CustomerId, [FromBody] JsonPatchDocument<CustomerDTO> patchDocument)
        {
            var Customer = await _CustomerService.GetByIdAsync(CustomerId);
            if (Customer == null)
            {
                return NotFound();
            }

            try
            {
                patchDocument.ApplyTo(Customer);
                await _CustomerService.UpdateAsync(Customer);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return UnprocessableEntity(e.Message);
            }

            return CreatedAtAction("GetCustomer", new { CustomerId = Customer.Id }, Customer);
        }
    }
}
