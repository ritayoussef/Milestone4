using ECommerce.Api.Orders.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
/*Course: 		Web Programming 3
* Assessment: 	Milestone 4
* Created by:   Rita Youssef - 2124602
* Date: 		1st December 2024
* Class Name: 	OrdersController.cs
* Description:  This class contains httpget endpoints to retrieve orders by customer Id using IOrdersProvider.
* Time for Task:	10 hours
    */
namespace ECommerce.Api.Orders.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersProvider ordersProvider;

        public OrdersController(IOrdersProvider ordersProvider)
        {
            this.ordersProvider = ordersProvider;
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetOrdersAsync(int customerId)
        {
            var result = await ordersProvider.GetOrdersAsync(customerId);
            if (result.IsSuccess)
            {
                return Ok(result.Orders);
            }
            return NotFound();
        }
    }
}