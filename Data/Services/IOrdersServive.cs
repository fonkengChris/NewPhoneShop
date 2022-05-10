using NewPhoneShop2.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewPhoneShop2.Data.Services
{
    public interface IOrdersServive
    {
        Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAddress);
        Task<List<Order>> GetOrdersByIdAndRoleAsync(string userId, string userRole);
    }
}
