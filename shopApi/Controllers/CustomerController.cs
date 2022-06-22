using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using shopBL;
using shopModel;

namespace shopApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    private iCustomerBL _custBL;
    private iCustItemJoinBL _custJoin;
    public CustomerController(iCustomerBL p_custBL, iCustItemJoinBL custJoin)
    {
        _custBL = p_custBL;
        _custJoin = custJoin;
    }


    [HttpGet("GetAllCustomer")]
    public async Task<IActionResult> GetAllCustomer()
    {
        try
        {
            List<Customer> listOfCurrentCustomer = await _custBL.GetAllCustomerAsync();
            return Ok(listOfCurrentCustomer);
        }
        catch (SqlException)
        {
            return NotFound("Customer not found");
        }
    } 

    
    
    [HttpPost("AddCustomer")]
    public IActionResult AddCustomer([FromBody]Customer p_cust)
    {
        try
        {
        _custBL.AddCustomer(p_cust);
        return Created("Customer Added", p_cust);
        }
        catch (System.Exception)
        {
            return Conflict();
        }    
    }

    [HttpGet("SearchCustomerBy")]
    public IActionResult SearchCustomer([FromQuery] string custName)
    {
        try
        {
        return Ok(_custBL.searchCustomerByName(custName));
        }
        catch (SqlException)
        {
            return Conflict();
        }
    }
    [HttpPut("AdditemQuant")]
    public IActionResult AddItemQuant([FromQuery] int p_quant, [FromQuery] int p_itemID, [FromQuery] int p_custID)
    {
        Customer found = _custBL.SearchCustomerByID(p_custID);

        if (found == null)
        {
            return NotFound("Customer was not found");
        }
        else
        {
            try
            {
                _custJoin.AddItemQuant(p_quant,p_custID,p_itemID);
                return Ok();
            }
            catch (SqlException)
            {
                return Conflict();
            } 
        }
    }
}
