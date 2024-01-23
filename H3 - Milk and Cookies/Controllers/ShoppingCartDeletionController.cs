using H3___Milk_and_Cookies.SessionExtension;
using H3___Milk_and_Cookies.Shop;
using Microsoft.AspNetCore.Mvc;

namespace H3___Milk_and_Cookies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartDeletionController : Controller
    {
        [HttpDelete]
        public IEnumerable<Product> Delete(string name, decimal price)
        {
            if (HttpContext.Session.GetString("cart") == null)
            {
                HttpContext.Session.SetString("cart", "[]");
            }

            List<Product> cart = SessionExtension.SessionExtensions.GetObjectFromJson<List<Product>>(HttpContext.Session, "cart");
            try
            {
                cart.Remove(cart.First(x => x.Name == name && x.Price == price));
            }
            catch
            {
                Console.WriteLine("Product not found");
                return cart;
            }

            HttpContext.Session.SetObjectAsJson("cart", cart);

            return cart;
        }
    }
}
