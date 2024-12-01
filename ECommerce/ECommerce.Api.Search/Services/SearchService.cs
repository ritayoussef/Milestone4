using ECommerce.Api.Search.Interfaces;
using System.Threading.Tasks;

namespace ECommerce.Api.Search.Services
{
    public class SearchService : ISearchService
    {
        private readonly IOrderService ordersService;
        public SearchService(IOrderService ordersService)
        {
            this.ordersService = ordersService;
        }
        public async Task<(bool IsSuccess, dynamic SearchResults)> SearchAsync(int customerId)
        {
          var ordersResult = await ordersService.GetOrdersAsync(customerId);
            if (ordersResult.IsSuccess) 
            {
                var result = new
                {
                    Orders = ordersResult.Orders
                };
                return (true, result);
            }
            return (false, null);
        }
    }
}
