using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Yyuri.Domain
{
    public abstract class AuditBase : IAudit
    {
        public DateTime? AddedStamp { get; set; }
        public String AddedUserId { get; set; }
        public DateTime? ChangedStamp { get; set; }
        public String ChangedUserId { get; set; }

    }
}
