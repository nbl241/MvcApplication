using MVCApplication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCAppliacation.Controllers
{
    public class AttendanceController : Controller
    {
        protected AttendanceContext db = new AttendanceContext();

        // GET: Attendance
        public ActionResult Index()
        {
            return View();
        }

        // GET
        public ActionResult CreateStudentAttendance()
        {
            return View();
        }

        // POST
        //public ActionResult CreateStudentAttendance()
        //{

        //}
    }
}