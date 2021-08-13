using Ats.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Yyuri.Models.Account
{
    public class EmployeeViewModel
    {
        public EmployeeViewModel()
        {
            Projects = new HashSet<DisplayItem>();
            Departments = new HashSet<DisplayItem>();
        }
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UserCode { get; set; }
        public string Title { get; set; }
        public string PhotoUrl { set; get; }
        public string Address { get; set; }
        public string Skype { get; set; }
        public IFormFile File { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DateOfBirth { get; set; }

        public IEnumerable<DisplayItem> Projects { get; set; }
        public IEnumerable<DisplayItem> Departments { get; set; }
        public string FullName
        {
            get
            {
                string fullname = this.FirstName;
                if (!String.IsNullOrEmpty(this.LastName))
                {
                    return String.Format("{0}, {1}", this.FirstName, this.LastName);
                }
                return fullname;
            }
        }
    }
}
