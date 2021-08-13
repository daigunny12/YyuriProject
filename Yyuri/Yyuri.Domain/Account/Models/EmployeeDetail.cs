using System;
using System.Collections.Generic;
using System.Text;

namespace Yyuri.Domain.Account.Models
{
    public class EmployeeDetail
    {        
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string UserName { get; set; }
        public string LastName { get; set; }
       
        public string Email { get; set; }

        public string UserCode { get; set; }
        public string Title { get; set; }
        public string PhotoUrl { set; get; }
        public string PhoneNumber { get; set; }

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

        public string Project { get; set; }     
    }

    public class EmployeeSearch
    {
        public EmployeeSearch()
        {
            UsersProfile = new HashSet<EmployeeDetail>();
        }
        public IEnumerable<EmployeeDetail> UsersProfile { set; get; }

        public string SearchText { get; set; }
        public int PageIndex { get; set; }
        public int TotalItem { get; set; }
        public int PageSize { get; set; }
    }

    public class EmployeeDetailMB
    {
        public EmployeeDetailMB()
        {
            UserId = Guid.Empty;
            FirstName = "";
            LastName = "";
            Email = "";

            Address = "";
            UserCode = "";
            Phone = "";
            Skype = "";
            AttachmentLink = "";
            GroupName = "";
            DateOfBirth = default;
            Project = default;
            Mobile = "(029)555-0104";
        }
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string UserCode { get; set; }
        public string Phone { get; set; }
        public string Skype { get; set; }
        public string AttachmentLink { get; set; }
        public string GroupName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Array Project { get; set; }
        public string Mobile { get; set; }
    }
}
