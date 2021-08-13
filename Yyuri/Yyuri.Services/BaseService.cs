using System;
using Microsoft.AspNetCore.Identity;
using Yyuri.Domain.Identity.Models;
using Yyuri.Commons;
using Yyuri.Domain;

namespace Yyuri.Services
{
    public abstract class BaseService : DisposableObject, IBaseService
    {
        //public ILog Logger { get; set; }
        protected UserManager<User> _userManager;
        protected SignInManager<User> _signInManager;

        protected IUnitOfWork UnitOfWork { get; set; }

        private BaseService()
        {

        }

        protected BaseService(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork; 
        }

        #region Dispose
        private bool _disposed;

        protected override void Dispose(bool isDisposing)
        {
            if (!this._disposed)
            {
                if (isDisposing)
                {
                    UnitOfWork = null;
                }
                _disposed = true;
            }            
        }
        #endregion
    }
}
