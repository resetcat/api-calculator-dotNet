using Newtonsoft.Json.Linq;

namespace api_calc_net.Services
{
    public class CountryService
    {
        public async Task<List<string>> GetContriesAsync()
        {
            using HttpClient client = new();
            string url = "https://restcountries.com/v3.1/all";
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string json = await response.Content.ReadAsStringAsync();
            return CreateCountryList(json);
        }

        public List<string> CreateCountryList(string response)
        {
            var jArray = JArray.Parse(response);
            var countryList = new List<string>();
            foreach (var jObject in jArray)
            {
                var countryName = jObject["name"]["common"].ToString();
                countryList.Add(countryName);
            }
            countryList.Sort();
            return countryList;
        }

    }
}
