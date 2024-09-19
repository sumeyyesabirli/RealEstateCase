using Microsoft.AspNetCore.Mvc;

namespace RealEstateCase.UI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
