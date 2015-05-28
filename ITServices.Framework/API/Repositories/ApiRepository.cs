using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
//using ITServices.Framework.Configurations;
using ITServices.Framework.Configurations;

namespace ITServices.Framework.API.Repositories
{
    public class ApiRepository : IApiRepository
    {
        public Task<string> GetAsync(string apiEndPoint)
        {
            Task<string> result = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ITServicesConfiguration.BaseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
              //  client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Partner axiomcloud:3n81n3y@rd");
                AuthenticationHeaderValue authHeaderValue;
                AuthenticationHeaderValue.TryParse("Partner axiomcloud:3n81n3y@rd", out authHeaderValue);
                client.DefaultRequestHeaders.Authorization = authHeaderValue;
                HttpResponseMessage response = client.GetAsync(apiEndPoint).Result;
                if (response.IsSuccessStatusCode)
                    result = response.Content.ReadAsStringAsync();
            }
            return result;
        }

        
       
    }
}