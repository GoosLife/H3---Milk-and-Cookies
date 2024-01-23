using Microsoft.AspNetCore.Mvc;

namespace H3___Milk_and_Cookies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecretIdentityController : Controller
    {
        [HttpGet]
        public string Set(string secretIdentity)
        {
            CookieOptions options = new CookieOptions();
            options.Expires = System.DateTime.Now.AddMinutes(5);
            Response.Cookies.Append("secretIdentity", secretIdentity, options);
            return "You are " + secretIdentity;
        }

        [HttpGet]
        [Route("[action]")]
        public string Get()
        {
            if (Request.Cookies["secretIdentity"] == null)
            {
                Response.StatusCode = 422;
                return "We don't know who you are.";
            }

            return Request.Cookies["secretIdentity"]!;
        }

        [HttpGet]
        [Route("[action]")]
        public string RevealPersona()
        {
            if (Request.Cookies["heroName"] == null)
            {
                Response.StatusCode = 422;
                return "We don't think you're a super hero.";
            }

            if (Request.Cookies["secretIdentity"] == null)
            {
                return Get();
            }

            return Get() + ", when you put on the mask, you are " + Request.Cookies["heroName"] + ".";
        }
    }
}
