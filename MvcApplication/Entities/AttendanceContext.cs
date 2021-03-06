﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcApplication.Entities
{
    public class AttendanceContext : DbContext
    {
        public AttendanceContext(): base("AttendancedbContextConnexion")
        {

        }

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<ClassRoom> ClassRooms { get; set; }
        public virtual DbSet<Attendance> Attendances { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }

        public System.Data.Entity.DbSet<ViewModels.StudentViewModel> StudentViewModels { get; set; }
    }
}