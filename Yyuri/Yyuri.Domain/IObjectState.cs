using System.ComponentModel.DataAnnotations.Schema;

namespace Yyuri.Domain
{
    public interface IObjectState
    {
        [NotMapped]
        ObjectState State { get; set; }
    }
}