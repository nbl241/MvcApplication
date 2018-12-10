using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCApplication.ViewModels
{
    public class StudentViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Nom")]
        public string Name { get; set; }
    }
}