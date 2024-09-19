using Microsoft.AspNetCore.Mvc;

namespace RealEstateCase.UI.Controllers
{
    public class PropertiesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
