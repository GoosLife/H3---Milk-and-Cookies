using Microsoft.AspNetCore.Mvc;

namespace H3___Milk_and_Cookies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : Controller
    {
        [HttpGet]
        public string Set(string heroName)
        {
            CookieOptions options = new CookieOptions();
            options.Expires = System.DateTime.Now.AddMinutes(5);
            Response.Cookies.Append("heroName", heroName, options);
            return "You are " + heroName;
        }

        [HttpGet]
        [Route("[action]")]
        public string Get()
        {
            if (Request.Cookies["heroName"] == null)
            {
                return "We don't think you're a super hero.";
            }

            return Request.Cookies["heroName"]!;
        }

        [HttpGet]
        [Route("[action]")]
        public string RevealIdentity()
        {
            if (Request.Cookies["secretIdentity"] == null)
            {
                Response.StatusCode = 422;
                return "Drat! We haven't found your secret identity yet.";
            }

            if (Request.Cookies["heroName"] == null)
            {
                return Get();
            }

            return Get() + ", behind the mask, you are " + Request.Cookies["secretIdentity"] + ".";
        }
    }
}
