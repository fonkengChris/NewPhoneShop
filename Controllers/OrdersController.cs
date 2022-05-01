using Microsoft.AspNetCore.Mvc;
using NewPhoneShop2.Data.Cart;
using NewPhoneShop2.Data.Services;
using NewPhoneShop2.Data.ViewModels;
using System.Threading.Tasks;

namespace NewPhoneShop2.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IProductsService _productsService;
        private readonly ShoppingCart _shoppingCart;
        private readonly IOrdersServive _ordersServive;

        public OrdersController(IProductsService productService, ShoppingCart shoppingCart, IOrdersServive ordersServive)
        {
            _productsService = productService;
            _shoppingCart = shoppingCart;
            _ordersServive = ordersServive;
        }

        public async Task<IActionResult> Index()
        {
            string userId = "";

            var orders = await _ordersServive.GetOrdersByIdAsync(userId);
            return View(orders);
        }
        public IActionResult ShoppingCart()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var response = new ShoppingCartVM()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };
            return View(response);
        }

        public async Task<IActionResult> AddItemToShoppingCart(int id)
        {
            var item = await _productsService.GetProductByIdAsync(id);

            if (item != null)
            {
                _shoppingCart.AddItemToCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }

        public async Task<IActionResult> RemoveItemFromShoppingCart(int id)
        {
            var item = await _productsService.GetProductByIdAsync(id);

            if (item != null)
            {
                _shoppingCart.RemoveItemFromCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }

        public async Task<IActionResult> CompleteOrder()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            string userId = "";
            string userEmailAddres = "";

            await _ordersServive.StoreOrderAsync(items, userId, userEmailAddres);
            await _shoppingCart.ClearShoppingCartAsync();

            return View("OrderCompleted");
        }
    }
}
