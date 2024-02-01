﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MeyawoPortfolio.Models;


namespace MeyawoPortfolio.Controllers
{
    public class DashboardController : Controller
    {
        DbMyPortfolioEntities db = new DbMyPortfolioEntities();

        // GET: Dashboard
        public ActionResult Index()
        {
            ViewBag.categoryCount = db.TblCategory.Count();
            ViewBag.projectCount = db.TblProject.Count();
            ViewBag.messageCount = db.TblContact.Count();
            ViewBag.flutterProjectCount = db.TblProject.Where(x => x.ProjectCategory == 1).Count();
            ViewBag.isNotReadMessageCount = db.TblContact.Where(x => x.IsRead == false).Count();
            ViewBag.lastProjectName = db.LastProjectName().FirstOrDefault();


            return View();
        }
    }
}