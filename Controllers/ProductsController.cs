using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewPhoneShop2.Models;
using NewPhoneShop2.Data;
using NewPhoneShop2.Data.Services;
using System.Threading.Tasks;
using System.Linq;


namespace NewPhoneShop2.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductsService _service;

        public ProductsController(IProductsService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allProducts = await _service.GetAllAsync();
            return View(allProducts);
        }

        public async Task<IActionResult> Filter(string searchString)
        {
            var allProducts = await _service.GetAllAsync();
            

            if (!string.IsNullOrEmpty(searchString))
            {
                var newString = CapitaliseFirstLetter(searchString).ToString();
                var filteredResult = allProducts.Where(n => n.Name.Contains(newString) || 
                        n.Category.ToString().Contains(newString) ||
                        n.BrandName.ToString().Contains(newString)).ToList();
                return View("Index", filteredResult);
            }
            return View("Index", allProducts);
        }

        //Capitalising the first letter of word
        private object CapitaliseFirstLetter(string str)
        {
            if (str.Length == 1)
                return str.ToUpper();
            else
                return (char.ToUpper(str[0]) + str.Substring(1).ToLower());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewProductVM product)
        {
           if (!ModelState.IsValid)
            {
                return View(product);
            }
            await _service.AddNewProductAsync(product);
            return RedirectToAction(nameof(Index));
        }

        //Get: Product/Details/1    
        public async Task<IActionResult> Details(int id)
        {
            var productDetail = await _service.GetByIdAsync(id);

            if(productDetail == null) return View("NotFound");
            return View(productDetail);
        }

        //Post: Product Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var productDetails = await _service.GetProductByIdAsync(id);
            if (productDetails == null) return View("NotFound");

            var response = new NewProductVM()
            {
                Id = productDetails.Id,
                BrandName = productDetails.BrandName,
                Name = productDetails.Name,
                Category = productDetails.Category,
                ProfilePictureURL = productDetails.ProfilePictureURL,
                Properties = productDetails.Properties,
                Price = productDetails.Price,
            };
            return View(productDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewProductVM product)
        {
            if (id != product.Id) return View("NotFound");
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            await _service.UpdateProductAsync(product);
            return RedirectToAction(nameof(Index));
        }

        //Post: Product Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var productDetails = await _service.GetByIdAsync(id);
            if (productDetails == null) return View("NotFound");
            return View(productDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {          
            var productDetails = await _service.GetByIdAsync(id);
            if (productDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));      
        }
    }
}
