using MVCApplication.Entities;
using MVCApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCAppliacation.Controllers
{
    public class StudentController : Controller
    {
        AttendanceContext db = new AttendanceContext();

        // GET: Student
        public ActionResult DetailsStudent(StudentViewModel studentViewModel)
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddStudent()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddStudent(Student student)
        {
            if(ModelState.IsValid)
            {
                db.Students.Add(student);
                db.SaveChanges();
            }
            return View();
        }
    }
}