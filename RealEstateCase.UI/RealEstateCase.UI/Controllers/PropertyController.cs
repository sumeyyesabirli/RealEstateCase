using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace RealEstateCase.UI.Controllers
{
    public class PropertyController : Controller
    {         
        private readonly HttpClient _httpClient;

        public PropertyController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> AddProperty(PropertyViewModel property)
        {
            if (ModelState.IsValid)
            {
    
                var jsonContent = JsonConvert.SerializeObject(property);
                var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("https://localhost:7063/api/Property", httpContent);

                if (response.IsSuccessStatusCode)
                {
           
                    return RedirectToAction("Index"); 
                }
            }

     
            return View(property);
        }

    }
}
