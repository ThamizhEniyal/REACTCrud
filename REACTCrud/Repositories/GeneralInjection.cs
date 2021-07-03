using Microsoft.AspNetCore.Mvc;
using REACTCrud.Interface;
using REACTCrud.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using REACTCrud.Authentication;

namespace REACTCrud.Repositories
{
    public class GeneralInjection : IGeneralnjection
    {
        public async Task<List<string>> GetCountryData()
        {
            CountryListVM countryListVM = new CountryListVM();
            HttpResponseMessage responseMessage = new HttpResponseMessage();
            List<string> Countries = new List<string>();
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://covid-193.p.rapidapi.com/countries"),
                Headers =
    {
        { "x-rapidapi-key", "5e7040b64dmsh06da7fab75f455ep10e631jsn88bef09f7087" },
        { "x-rapidapi-host", "covid-193.p.rapidapi.com" },
    },
            };
            using (responseMessage = await client.SendAsync(request))
            {
                responseMessage.EnsureSuccessStatusCode();
                var body = await responseMessage.Content.ReadAsStringAsync();
                CountryResponseVM responseVM = JsonConvert.DeserializeObject<CountryResponseVM>(body);
                Countries = responseVM.Response;


            }
         
            return Countries;
        }


        public async Task<List<StatisticsVM>> GetStatistics()
        {
            CountryListVM countryListVM = new CountryListVM();
            HttpResponseMessage responseMessage = new HttpResponseMessage();
            StatisticsResponseVM statisticsResponseVM = new StatisticsResponseVM();
            List<string> Countries = new List<string>();
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://covid-193.p.rapidapi.com/statistics"),
                Headers =
    {
        { "x-rapidapi-key", "5e7040b64dmsh06da7fab75f455ep10e631jsn88bef09f7087" },
        { "x-rapidapi-host", "covid-193.p.rapidapi.com" },
    },
            };
            using (responseMessage = await client.SendAsync(request))
            {
                responseMessage.EnsureSuccessStatusCode();
                var body = await responseMessage.Content.ReadAsStringAsync();
                 statisticsResponseVM = JsonConvert.DeserializeObject<StatisticsResponseVM>(body);
              


            }

            return statisticsResponseVM.Response;
        }
    }
}
