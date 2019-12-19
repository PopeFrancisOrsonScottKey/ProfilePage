using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Profile.Models;
using LinqToWiki.Generated;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Xml.Linq;

namespace Profile.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<ActionResult> Index()
        {
            HomeModel model = new HomeModel();
            var filename = "./IgnoreInfo.xml";
            XElement spotifyInfo = XElement.Load(filename);
            var OAuthToken = spotifyInfo.Attribute("OAUTHToken").Value;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.spotify.com/v1/me/tracks");
                //var urlParameters = "?origin=*&action=query&list=search&srsearch=" + model.InputText + "&format=json";
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));                
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", OAuthToken);
                using (var responseMessage = client.GetAsync("").Result)
                {
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        var jString = await responseMessage.Content.ReadAsStringAsync();
                        model.ResultText = JsonConvert.DeserializeObject<Object>(jString);
                    }
                }
            }            
            return View(model);
        }

        [HttpPost(Name = "/")]
        public ActionResult Index(HomeModel model)
        {



            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
