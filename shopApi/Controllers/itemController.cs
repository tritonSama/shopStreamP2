using Microsoft.AspNetCore.Mvc;
using shopBL;
using shopModel;

namespace shopApi.Controllers
{

[ApiController]
[Route("[controller]")]
public class ITemController : ControllerBase
{
    private iItemBL _itemBL;
    private iCustItemJoinBL _custJoin;
    public ITemController(iItemBL p_itemBL, iCustItemJoinBL custJoin)
    {
        _itemBL = p_itemBL;
        _custJoin = custJoin;
    }


    [HttpGet("GetAllItem")]
    public IActionResult GetAllItem()
    {
        List<Item> listOfCurrentItem = _itemBL.GetAllItem();
        return Ok(listOfCurrentItem);
    }   

    // [HttpPut("AddItemQuant")]
    // public IActionResult AddItemQuant([FromQuery] int p_item, [FromQuery] int p_itemID, [FromQuery] int p_custID)
    // {
    //     Customer found = _itemBL.SearchCustomerById(p_item, p_itemID);
    //     _custJoin.AddItemQuant(p_item, p_itemID, p_custID);
    //     return Ok();
    // }
}
}