using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcApplication.ViewModels
{
    public class StudentAttendanceViewModel
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public bool IsPresent { get; set; }
        public int IdStudent { get; set; }
        [Display(Name ="Student")]
        public string NameStudent { get; set; }
        public int IdClassRoom { get; set; }
        [Display(Name = "ClassRoom")]
        public string NameClassRoom { get; set; }
    }
}