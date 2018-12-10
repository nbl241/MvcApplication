using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCApplication.Entities
{
    public class Attendance
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public bool IsPresent { get; set; }
        [ForeignKey("Student")]
        public int IdStudent { get; set; }
        public virtual Student Student { get; set; }
        [ForeignKey("ClassRoom")]
        public int IdClassRoom { get; set; }
        public virtual ClassRoom ClassRoom { get; set; }
    }
}