using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ApiTest.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using ApiTest.Helper;

namespace ApiTest.Controllers
{
    public class HomeController : Controller
    {
        CostumerApi _api = new CostumerApi();



        public async Task<IActionResult> Index()
        {
            List<Costumer> list = new List<Costumer>();
            HttpClient client = _api.Inıtal();
            HttpResponseMessage res = await client.GetAsync("/api/costumer/");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                list = JsonConvert.DeserializeObject<List<Costumer>>(result);


            }
            return View(list);


        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Costumer obj)
        {
            HttpClient client = _api.Inıtal();
            string stringData = JsonConvert.SerializeObject(obj);
            var contentData = new StringContent
        (stringData, System.Text.Encoding.UTF8,
        "application/json");
            HttpResponseMessage response = client.PostAsync
        ("/api/costumer", contentData).Result;
            ViewBag.Message = response.Content.
        ReadAsStringAsync().Result;



            return View(obj);

        }


        public IActionResult Update(string id)
        {
            
          

            HttpClient client = _api.Inıtal();
            HttpResponseMessage response =
           client.GetAsync("/api/costumer/" + id).Result;
            string stringData = response.Content.
        ReadAsStringAsync().Result;
            Costumer data = JsonConvert.
        DeserializeObject<Costumer>(stringData);
            return View(data);
        }


        [HttpPost]
        public IActionResult Update(Costumer obj)
        {

            HttpClient client = _api.Inıtal();
            string stringData = JsonConvert.SerializeObject(obj);
            var contentData = new StringContent(stringData,
        System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync
        ("/api/costumer/" + obj.Id,
        contentData).Result;
            ViewBag.Message = response.Content.
        ReadAsStringAsync().Result;
            return View(obj);
        }


     
        [HttpPost]
        public IActionResult Delete(string id)
        {
            HttpClient client = _api.Inıtal();
            HttpResponseMessage response = client.DeleteAsync("/api/costumer/" + id).Result;
            TempData["Message"] =
        response.Content.ReadAsStringAsync().Result;
            return RedirectToAction("Index");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

}