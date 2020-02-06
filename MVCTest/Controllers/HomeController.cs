using MVCTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCTest.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            Tag_model tagm = new Tag_model();
            var result = tagm.GetTagForView();

            return View(result);
        }
       
    }
}
