using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCApplication.ViewModels.Mapping
{
    public class Mapping
    {
        public static StudentViewModel MapStudentToStudentViewModel(Entities.Student student)
        {
            return new StudentViewModel()
            {
                Id = student.Id,
                Name = student.Name
            };
        }

        public static Entities.Student MapStudentViewModelToStudent(StudentViewModel studentViewModel)
        {
            return new Entities.Student()
            {
                Id = studentViewModel.Id,
                Name = studentViewModel.Name
            };
        }

        public static StudentAttendanceViewModel MapAttendanceToStudentAttendanceViewModel(Entities.Attendance attendance)
        {
            return new StudentAttendanceViewModel()
            {
                Id = attendance.Id,
                Date = attendance.Date,
                IsPresent = attendance.IsPresent,
                IdStudent = attendance.IdStudent,
                StudentName = attendance.Student.Name,
                IdClassRoom = attendance.IdClassRoom,
                ClassRoomName = attendance.ClassRoom.Name,
            };
        }

        public static Entities.Attendance MapStudentAttendanceViewModelToAttendance(StudentAttendanceViewModel studentAttendanceViewModel)
        {
            return new Entities.Attendance()
            {
                Id = studentAttendanceViewModel.Id,
                Date = studentAttendanceViewModel.Date,
                IsPresent = studentAttendanceViewModel.IsPresent,
                IdStudent = studentAttendanceViewModel.IdStudent,
                IdClassRoom = studentAttendanceViewModel.IdClassRoom
            };
        }
    }
}