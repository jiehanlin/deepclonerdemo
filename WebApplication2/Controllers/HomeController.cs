using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppServices;
using Force.DeepCloner;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDictService _dictService;

        public HomeController(IDictService service)
        {
            _dictService = service;
        }
        public ActionResult Index()
        {
            var data= _dictService.GetDictType();
            var result = data.DeepClone();
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
    }
}