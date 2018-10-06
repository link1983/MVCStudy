using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCStudy.Models;

namespace MVCStudy.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(int pagesall=0,int page=1,string key="")
        {
            ViewBag.Controller = "Home";
            ViewBag.Action = "Index";

            int pagecount = 20;
            DAL.FilesDAL filesDAL = new DAL.FilesDAL();
            string kw = Request.Form["keyword"];
            if (!(kw == "" || kw == null))
            {
                ViewBag.keyword = kw;
                List<Files> lFiles = new List<Files>();
                lFiles = filesDAL.Search(kw,"");
                int count = lFiles.Count;
                int pages = (int)Math.Ceiling((double)count / (double)pagecount);
                ViewBag.count = count;
                ViewBag.pages = pages;
                ViewBag.page = page;
                lFiles = filesDAL.Search(kw, "limit 0,"+ pagecount.ToString());
                ViewBag.ListFiles = lFiles;
                return View("ActionName");

            }
            if (pagesall!=0)
            {
                ViewBag.keyword = key;
                ViewBag.pages = pagesall;
                ViewBag.page = page;
                List<Files> lFiles = new List<Files>();
                lFiles = filesDAL.Search(key, "limit " + (pagecount * (page - 1)).ToString() + "," + pagecount.ToString());
                ViewBag.ListFiles = lFiles;
                return View("ActionName");

            }
            if (pagesall==0)
            {
                List<Files> lFiles = new List<Files>();
                ViewBag.ListFiles = lFiles;
                return View("ActionName");

            }
            return View("ActionName");

        }
    }
}