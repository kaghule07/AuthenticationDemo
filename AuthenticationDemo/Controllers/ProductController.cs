using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationDemo.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        //[Authorize]
        [AllowAnonymous]
        public IActionResult List()
        {

            return View();
        }
        public IActionResult Create()
        {

            return View();
        }
    }
}
