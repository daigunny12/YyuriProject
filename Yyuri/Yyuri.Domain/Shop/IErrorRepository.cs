using Yyuri.Domain.Shop.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Yyuri.Domain.Shop
{
    public interface IErrorRepository  : IRepository<Error, System.Guid>
    {
    }
}
