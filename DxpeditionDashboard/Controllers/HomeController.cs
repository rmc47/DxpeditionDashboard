using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tweetinvi;
using Tweetinvi.Parameters;

namespace DxpeditionDashboard.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Auth.SetUserCredentials("YMasAbJ8gdOkLawehHUHrZIZX", "0Kmqnn5C0ZdTjAIClsX1vuAQsyboYuzoCDZxACoZvpwakCAj0j", "16551001-F3QsCYU7AqgNGdrcUqPIdfpoCcSOgJLS1f2nuJU3F", "6TOWUjx5ghFWPxXhk6eIXSeOY2o2w9MrpPjqqj28w69GV");
            Tweetinvi.Tweet.PublishTweet("Hello world");
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