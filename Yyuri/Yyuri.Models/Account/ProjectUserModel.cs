using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Yyuri.Models.Account
{
    public class ProjectUserModel
    {

        public Guid Id { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Tag { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public double CommitHour { get; set; }
        //public PROJECT_UNIT Unit { get; set; }
        public bool IsChargeable { get; set; }
    }
}
