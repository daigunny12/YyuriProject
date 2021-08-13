using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Yyuri.Domain.Shop.Model
{
    [Table("Errors")]
    public class Error: IEntity<System.Guid>
    {
        [Key]
        public Guid Id { set; get; }

        public string Message { set; get; }

        public string StackTrace { set; get; }

        public DateTime CreatedDate { set; get; }
    }
}
