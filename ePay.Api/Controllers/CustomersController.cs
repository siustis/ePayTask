using ePay.Api.Models;
using ePay.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ePay.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomersController : ControllerBase
{
    private readonly ICustomerRepository _repository;

    public CustomersController(ICustomerRepository repository)
    {
        _repository = repository;
    }

    // GET: api/customers
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Customer>>> Get()
    {
        return Ok(await _repository.GetAllAsync());
    }

    // POST: api/customers
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] List<Customer> customers)
    {
        foreach (var customer in customers)
        {
            if (!TryValidateModel(customer))
            {
                return BadRequest(ModelState);
            }

            if (await _repository.ExistsAsync(customer.Id))
            {
                return BadRequest("ID has been used before");
            }

            await _repository.AddAsync(customer);
        }

        return Ok();
    }
}
