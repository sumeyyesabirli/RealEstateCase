using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstateCase.UI.Models;
using System.Text;

public class AdminController : Controller
{
    private readonly HttpClient _httpClient;
    private readonly string _propertyUrl;

    public AdminController(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _propertyUrl = configuration["ApiSettings:PropertyUrl"];
    }

    public async Task<IActionResult> Index()
    {
        var response = await _httpClient.GetAsync($"{_propertyUrl}");

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var apiResponse = JsonConvert.DeserializeObject<ApiResponseModel<IEnumerable<PropertyViewModel>>>(jsonString);

            if (apiResponse != null && apiResponse.Success)
            {
                var activeProperties = apiResponse.Data.Where(p => p.IsActive == true);
                return View(apiResponse.Data);
            }
        }
        return View("Error");
    }

    [HttpPost]
    public async Task<IActionResult> DeleteProperty(int PropertyId)
    {
        var response = await _httpClient.DeleteAsync($"{_propertyUrl}/{PropertyId}");

        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View("Error");
    }

    [HttpPost]
    public async Task<IActionResult> SetAdvertisementStatus(int PropertyId, int status)
    {
        try
        {
            var requestModel = new SetAdvertisementStatusViewModel
            {
                PropertyId = PropertyId,
                Status = (AdvertisementStatusEnumViewModel)status
            };

            var content = new StringContent(JsonConvert.SerializeObject(requestModel), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"{_propertyUrl}/SetAdvertisementStatus", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            var errorMessage = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Error: {errorMessage}");

            return View("Error");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception: {ex.Message}");
            return View("Error");
        }
    }
}
