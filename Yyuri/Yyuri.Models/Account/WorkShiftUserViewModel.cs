
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Yyuri.Models.Account
{
    public class WorkShiftUserViewModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid WorkShiftId { get; set; }
        //public WorkShiftViewModel WorkShift { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateFrom { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DateEnd { get; set; }
    }
}
