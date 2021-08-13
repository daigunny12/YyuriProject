using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Yyuri.Domain
{
    public interface IAudit
    {
        DateTime? AddedStamp { get; set; }
        String AddedUserId { get; set; }
        DateTime? ChangedStamp { get; set; }
        String ChangedUserId { get; set; }
    }
}
