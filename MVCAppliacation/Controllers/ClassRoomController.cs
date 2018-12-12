using MVCApplication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCAppliacation.Controllers
{
    public class ClassRoomController : Controller
    {
        AttendanceContext db = new AttendanceContext();

        // GET: ClassRoom
        [HttpGet]
        public ActionResult AddClassRoom()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddClassRoom(ClassRoom classRoom)
        {
            if (ModelState.IsValid)
            {
                db.ClassRooms.Add(classRoom);
                db.SaveChanges();
            }
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}