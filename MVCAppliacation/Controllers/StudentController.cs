using MVCApplication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCAppliacation.Controllers
{
    public class StudentController : Controller
    {
        protected AttendanceContext db = new AttendanceContext();

        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateStudent()
        {
            return View();
        }

        // POST
        //public ActionResult CreateStudent()
        //{

        //}
    }
}