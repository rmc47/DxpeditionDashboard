using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Tweetinvi;

namespace DxpeditionDashboard.Server.Controllers
{
    public class TwitterController : Controller
    {
        // GET: Twitter
        public ActionResult Index()
        {
            return Content("Hello");
        }

        public ActionResult SendTweet()
        {
            InitTwitter();
            string tweetText = Request["tweetText"];
            string providedApiKey = Request["apiKey"];
            if (providedApiKey != ConfigurationManager.AppSettings["ApiKey"])
                throw new UnauthorizedAccessException();

            var tweet = Tweet.PublishTweet(tweetText);

            return Content(tweet.Url);
        }

        public ActionResult GetMentions()
        {
            string providedApiKey = Request["apiKey"];
            if (providedApiKey != ConfigurationManager.AppSettings["ApiKey"])
                throw new UnauthorizedAccessException();
            InitTwitter();
            var mentions = Timeline.GetMentionsTimeline();
            StringBuilder outputBuilder = new StringBuilder();
            foreach (var mention in mentions)
            {
                outputBuilder.AppendFormat("{0} @ {1}: {2}\r\n", mention.CreatedBy.Name, mention.CreatedAt, mention.FullText);
            }
            return Content(outputBuilder.ToString());
        }


        private void InitTwitter()
        {
            string consumerKey = ConfigurationManager.AppSettings["TwitterConsumerKey"];
            string consumerSecret = ConfigurationManager.AppSettings["TwitterConsumerSecret"];
            string accessKey = ConfigurationManager.AppSettings["TwitterAccessKey"];
            string accessSecret = ConfigurationManager.AppSettings["TwitterAccessSecret"];

            Auth.SetUserCredentials(consumerKey, consumerSecret, accessKey, accessSecret);
        }
    }
}