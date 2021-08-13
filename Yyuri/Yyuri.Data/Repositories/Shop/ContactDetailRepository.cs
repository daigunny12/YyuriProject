using Yyuri.Data.EntityFramework;
using Yyuri.Domain.Shop;
using Yyuri.Domain.Shop.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Yyuri.Data.Repositories.Shop
{
    public class ContactDetailRepository : Repository<ContactDetail, System.Guid>, IContactDetailRepository
    {
        public ContactDetailRepository(SCDataContext context) : base(context)
        {

        }
    }
}
