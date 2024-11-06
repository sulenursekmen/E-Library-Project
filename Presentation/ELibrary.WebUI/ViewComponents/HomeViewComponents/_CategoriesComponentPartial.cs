using ELibrary.Application.Features.Mediator.Results.CategoryResults;
using ELibrary.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ELibrary.WebUI.ViewComponents.HomeViewComponents
{
    public class _CategoriesComponentPartial : ViewComponent
    {
        private readonly HttpClient _httpClient;

        public _CategoriesComponentPartial(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var responseMessage = await _httpClient.GetAsync("https://localhost:7220/api/Categories");

            if (responseMessage.IsSuccessStatusCode)
            {
                var categories = await responseMessage.Content.ReadFromJsonAsync<List<GetCategoryQueryResult>>();
                return View(categories);
            }
            else
            {
                var errorMessage = await responseMessage.Content.ReadAsStringAsync();
                return View("Error", errorMessage);
            }
        }
    }

}
