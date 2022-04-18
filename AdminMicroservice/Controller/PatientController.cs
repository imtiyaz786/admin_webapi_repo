using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace AdminMicroservice.Controller
{
    public class PatientController
    {
        [HttpGet]
        public async Task<string> GetPatients()
        {
            var URL = "http://localhost:56369/api/Retrieve/GetPatients";
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(URL);
            return await response.Content.ReadAsStringAsync();
        }
    }
}
