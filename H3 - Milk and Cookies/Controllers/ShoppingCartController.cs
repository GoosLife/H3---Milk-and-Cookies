using H3___Milk_and_Cookies.Shop;
using Microsoft.AspNetCore.Mvc;
using H3___Milk_and_Cookies.SessionExtension;

namespace H3___Milk_and_Cookies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : Controller
    {
        [HttpGet]
        public IEnumerable<Product> AddProduct(string name, decimal price)
        {
            if (HttpContext.Session.GetString("cart") == null)
            {
                HttpContext.Session.SetString("cart", "[]");
            }

            List<Product> cart = SessionExtension.SessionExtensions.GetObjectFromJson<List<Product>>(HttpContext.Session, "cart");

            Product p = new Product(name, price);

            cart.Add(p);

            HttpContext.Session.SetObjectAsJson("cart", cart);

            return cart;
        }
    }
}
