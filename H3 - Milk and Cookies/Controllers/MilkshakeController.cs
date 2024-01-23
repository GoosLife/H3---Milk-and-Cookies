using Microsoft.AspNetCore.Mvc;

namespace H3___Milk_and_Cookies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MilkshakeController : Controller
    {
        [HttpGet]
        public string Get(string favoriteMilkshake)
        {
            CookieOptions options = new CookieOptions();
            options.Expires = System.DateTime.Now.AddMinutes(5);
            Response.Cookies.Append("favoriteMilkshake", favoriteMilkshake, options);
            return favoriteMilkshake;
        }

        [HttpGet]
        [Route("[action]")]
        public string GetFromCookie()
        {
            if (Request.Cookies["favoriteMilkshake"] == null)
            {
                Response.StatusCode = 422;
                return "Ya haven't set a favorite milkshake ya oaf";
            }

            return Request.Cookies["favoriteMilkshake"]!;
        }
    }
}
