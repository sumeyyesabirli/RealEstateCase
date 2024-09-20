using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstateCase.UI.Models;
using System.Net.Http;
using static System.Net.WebRequestMethods;

namespace RealEstateCase.UI.Controllers
{
    public class AdvertisementController : Controller
    {
        private readonly HttpClient _httpClient;

        public AdvertisementController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync($"https://localhost:7063/api/Property");

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var apiResponse = JsonConvert.DeserializeObject<ApiResponseModel<IEnumerable<PropertyViewModel>>>(jsonString);

                if (apiResponse != null && apiResponse.Success)
                {
                    if (apiResponse.Data != null && apiResponse.Data.Any())
                    {
                        var activeProperties = apiResponse.Data.Where(p => p.IsActive == true).ToList();
                        return View(activeProperties);
                    }
                    else
                    {
                        // Data null veya boşsa
                        return View("Error");
                    }
                }

            }
            return View("Error");
        }
    }
}
