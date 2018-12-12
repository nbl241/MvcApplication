using MVCApplication.Entities;
using MVCApplication.ViewModels;
using MVCApplication.ViewModels.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCAppliacation.Controllers
{
    public class AttendanceController : Controller
    {
        AttendanceContext db = new AttendanceContext();

        // GET: Attendance
        public ActionResult ListStudentAttendance()
        {
            List<StudentAttendanceViewModel> liste = new List<StudentAttendanceViewModel>();

            foreach(var a in db.Attendances.Include("Student").Include("ClassRoom"))
            {
                var temp = Mapping.MapAttendanceToStudentAttendanceViewModel(a);
                liste.Add(temp);
            }
            return View("ListStudentAttendance", liste.AsEnumerable());
        }

        [HttpGet]
        public ActionResult AddStudentAttendance()
        {
            var students = db.Students.ToList();
            var listStudents = new List<SelectListItem>();
            foreach(var student in students)
            {
                listStudents.Add(new SelectListItem()
                {
                    Text = student.Name,
                    Value = student.Id.ToString()
                });
            }
            ViewBag.Students = listStudents;

            var classRooms = db.ClassRooms.ToList();
            var listClassRooms = new List<SelectListItem>();
            foreach(var classRoom in classRooms)
            {
                listClassRooms.Add(new SelectListItem()
                {
                    Text = classRoom.Name,
                    Value = classRoom.Id.ToString()
                });
            }
            ViewBag.ClassRooms = listClassRooms;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddStudentAttendance(StudentAttendanceViewModel studentAttendanceViewModel)
        {
            if (ModelState.IsValid)
            {
                var attendance = Mapping.MapStudentAttendanceViewModelToAttendance(studentAttendanceViewModel);
                db.Attendances.Add(attendance);
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