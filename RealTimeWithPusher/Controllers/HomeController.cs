using PusherServer;
using RealTimeWithPusher.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace RealTimeWithPusher.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Index(RealtimeTable data)
        {
            try
            {
                RealtimeTable setdata = new RealtimeTable();
                setdata.Title = data.Title;
                setdata.year = data.year;
                db.RealtimeTables.Add(setdata);
                db.SaveChanges();
                var options = new PusherOptions();
                options.Cluster = "ap1";
                var pusher = new Pusher("533072", "f97bd79dcb03556375d5", "223990abc48c2bab1b34", options);
                ITriggerResult result = await pusher.TriggerAsync("channel1", "add", data);
            }
            catch (Exception ex)
            {
                throw;
            }
            return RedirectToAction("view", "Home");
        }
        public ActionResult seen()
        {
            return Json(db.RealtimeTables.ToArray(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult view()
        {
            return View();
        }
    }
}