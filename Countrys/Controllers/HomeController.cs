
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Countrys.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //getCountires();
             



            ViewBag.TotalStudents = getCountires();

            /*ViewData["Countries"] = getCountires();*/
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }




        public ActionResult getCountires()
        {
            ArrayList countries = new ArrayList();
            var httpWebRequest = (System.Net.HttpWebRequest)System.Net.WebRequest.Create("https://restcountries.com/v3.1/all");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";
            httpWebRequest.Accept = "application/json";

            var httpResponse = (System.Net.HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();

                var serializer = new JavaScriptSerializer();

                countries = new JavaScriptSerializer().Deserialize<ArrayList>(result);
                
            }
            return Json(countries, JsonRequestBehavior.AllowGet);
        }


        

        public class Response
        {
            public ArrayList countries { get; set; }
        }
       



    }
}