using System;

namespace Yyuri.Domain
{
    public interface IEntityTrackingModified
    {
        DateTime DateModified { set; }
    }
}
