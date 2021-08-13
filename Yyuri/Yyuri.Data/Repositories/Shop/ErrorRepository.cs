using Yyuri.Data.EntityFramework;
using Yyuri.Domain.Shop;
using Yyuri.Domain.Shop.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Yyuri.Data.Repositories.Shop
{
    public class ErrorRepository : Repository<Error, System.Guid>, IErrorRepository
    {
        public ErrorRepository(SCDataContext context) : base(context)
        {

        }
    }
}
