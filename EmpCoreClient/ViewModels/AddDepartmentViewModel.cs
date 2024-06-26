﻿using System.ComponentModel.DataAnnotations;

namespace EmpCoreClient.ViewModels
{
    public class AddDepartmentViewModel
    {
        [Required(ErrorMessage = "Department name is required.")]
        [Display(Name = "Department Name")]
        public string DepartmentName { get; set; }

        [Display(Name = "Department Description")]
        [Required(ErrorMessage = "Department description is required.")]
        public string DepartmentDescription { get; set; }
    }
}
