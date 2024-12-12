using System;
using RestSharp;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Text;

namespace APICall
{
    class APICall
    {
        const string ORCHESTRATOR_URL = "http://cloud.uipath.com/rosscowie/DefaultTenant/orchestrator_";
        public static string myText = "";
        public static  void start(WeatherReportRequest wrr)
        {
            string bearerToken = "Bearer rt_17DC5C7C0E4D2E3996AD9B7ECD4225CDFE958835F67AFFB15B7B7E9FE6D9A3C7-1";
            string berarer2 = "Bearer rt_9D689B912DF2D9E0F5F5F7BACE12C36F7C0F6367DA44B070BD3EAFF197CE90D3-1";

            startJob(berarer2, wrr);
        }
        public class WeatherReportRequest
        {
            public WeatherReportRequest (string address,string postcode,string city,string country,string email,string business,string name,bool weekly, bool genuine){
                Weekly = weekly;
                Genuine = genuine;
                Address = address;
                PostCode = postcode;
                City = city;
                Country = country;
                Email = email;
                Name = name;
                Business = business;
                }

           public bool Weekly, Genuine;
            public string Address;
            public string PostCode;
            public string City;
            public string Country;
            public string Email;
            public string Business;
            public string Name;
        }

        private static async Task startJob(string bearerToken, WeatherReportRequest report)
        {
            var client = new RestClient();
            var request = new RestRequest("https://cloud.uipath.com/rosscowie/DefaultTenant/orchestrator_/t/1efae47c-61bf-4e5d-be11-4ae15d440dc7/SendWeatherReport", Method.Post);
            request.AddHeader("Authorization", bearerToken);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Access-Control-Allow-Origin", "*");
            var json = JsonConvert.SerializeObject(new
            {
                report.Weekly,
                Address2 = report.PostCode,
                Address1 = report.Address,
                Address3 = report.City,
                Address4 = report.Country,
                report.Name,
                BuisnessName = report.Business,
                report.Email,
                report.Genuine
            });

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            request.AddJsonBody(content);

            RestResponse response = await client.ExecuteAsync(request);
            myText =(response.Content);
        }
    }

}