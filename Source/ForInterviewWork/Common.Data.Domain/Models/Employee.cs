﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Data.Domain.Models
{
    public partial class Employee
    {
        [Key]
        public int EmpId { get; set; }
        [Required]
        [StringLength(20)]
        public string EmpAccount { get; set; }
        [Required]
        [StringLength(128)]
        public string EmpPassword { get; set; }
        [StringLength(50)]
        public string EmpName { get; set; }
        [StringLength(100)]
        public string Email { get; set; }
        [StringLength(200)]
        public string Remarks { get; set; }
        public int? DeptId { get; set; }
        public int? RoleId { get; set; }
        public bool IsAccessDenied { get; set; }
        [StringLength(20)]
        public string PostAccount { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? PostDate { get; set; }
        [StringLength(20)]
        public string MdfAccount { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? MdfDate { get; set; }

        [ForeignKey(nameof(DeptId))]
        [InverseProperty(nameof(Department.Employee))]
        public virtual Department Dept { get; set; }
        [ForeignKey(nameof(RoleId))]
        [InverseProperty(nameof(EmployeeRole.Employee))]
        public virtual EmployeeRole Role { get; set; }
    }
}