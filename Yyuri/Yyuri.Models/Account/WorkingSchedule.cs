using Yyuri.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Yyuri.Models.Account
{    
    public class WorkingScheduleViewModel
    {
        public WorkingScheduleViewModel()
        {
        }

        [Key]
        public Guid Id { get; set; }

        public float Mon { get; set; }
        public float Tue { get; set; }
        public float Wed { get; set; }
        public float Thu { get; set; }
        public float Fri { get; set; }
        public float Sat { get; set; }
        public float Sun { get; set; }

        public string userId { get; set; }

        public System.DateTime? DateFrom { get; set; }
        public System.DateTime? DateEnd { get; set; }

        public bool IsExcludeHoliday { get; set; }
    }
}
