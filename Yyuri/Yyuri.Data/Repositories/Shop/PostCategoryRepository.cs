using Yyuri.Data.EntityFramework;
using Yyuri.Domain.Shop;
using Yyuri.Domain.Shop.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Yyuri.Data.Repositories.Shop
{
    public class PostCategoryRepository : Repository<PostCategory, System.Guid>, IPostCategoryRepository
    {
        public PostCategoryRepository(SCDataContext context) : base(context)
        {

        }
    }
}
