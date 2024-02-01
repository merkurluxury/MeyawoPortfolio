using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MeyawoPortfolio.Models;

namespace MeyawoPortfolio.Controllers
{
    public class StatisticController : Controller
    {
        DbMyPortfolioEntities db = new DbMyPortfolioEntities();
        // GET: Statistic
        public ActionResult Index()
        {
            ViewBag.categoryCount = db.TblCategory.Count();
            ViewBag.projectCount = db.TblProject.Count();
            ViewBag.messageCount = db.TblContact.Count();
            ViewBag.flutterProjectCount = db.TblProject.Where(x => x.ProjectCategory == 1).Count();
            ViewBag.isNotReadMessageCount = db.TblContact.Where(x => x.IsRead == false).Count();
            ViewBag.lastProjectName = db.LastProjectName().FirstOrDefault();
            ViewBag.sosyalMedyaCount = db.TblSocialMedia.Count();

             var lastServiceTitle = db.TblService.OrderByDescending(s => s.ServiceID).Select(s => s.Title).FirstOrDefault();

            ViewBag.LastServiceTitle = lastServiceTitle;

            var namesSurnames = db.TblReferences.Select(r => r.NameSurname).ToList();
            ViewBag.NamesSurnames = namesSurnames;


            // TblContact tablosundaki son kaydı al
            var lastContact = db.TblContact.OrderByDescending(c => c.ContactID).FirstOrDefault();

            ViewBag.LastContact = lastContact ?? new TblContact { NameSurname = "Bilgi Yok", Message = "Mesaj içeriği bulunamadı." };


            return View();
        }
    }
}