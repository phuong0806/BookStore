using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        BookDAO bookDao = new BookDAO();

        // GET: Home
        public ActionResult Index()
        {
            ViewBag.ListBook = bookDao.GetBook();
            ViewBag.ListBookPre = bookDao.GetBookPre();
            return View();
        }



    }
}