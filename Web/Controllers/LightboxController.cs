using Microsoft.AspNetCore.Mvc;
using Web.Models.Lightbox;

namespace Web.Controllers
{
    public class LightboxController : Controller
    {
        [HttpGet]
        public IActionResult Index(string type, int id)
        {
            var lightbox = new LightboxModel(type, id);
            return View(lightbox);
        }
    }
}