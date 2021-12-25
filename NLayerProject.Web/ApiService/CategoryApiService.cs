using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NLayerProject.Web.DTOs;

namespace NLayerProject.Web.ApiService
{
    public class CategoryApiService
    {
        private readonly HttpClient _httpClient;

        public CategoryApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            IEnumerable<CategoryDto> categoryDtos;
            var response = await _httpClient.GetAsync("categories");
            if (response.IsSuccessStatusCode)
            {
                categoryDtos =
                    JsonConvert.DeserializeObject<IEnumerable<CategoryDto>>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                categoryDtos = null;
            }

            return categoryDtos;
        }
    }
}
