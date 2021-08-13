using System;
using Yyuri.Data.EntityFramework;
using Yyuri.Domain;
using System.Threading.Tasks;
using Yyuri.Domain.Accounts.Repositories;
using Yyuri.Domain.Address;
using Yyuri.Data.Repositories.Address;
using Yyuri.Data.Accounts.Repositories;
using Ats.Data.Accounts.Repositories;
using Yyuri.Domain.Shop;
using Yyuri.Data.Repositories.Shop;

namespace Yyuri.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private Guid _userId;
        private IDbFactory _dbFactory;
        private SCDataContext _dbContext;
       
        public UnitOfWork(SCDataContext context)
        {
            _dbContext = context;
        }

        #region declare IRepository

        private IGroupRepository _groupRepo;
        private IRoleRepository _roleRepo;

        private IProfileRepository _profileRepo;
        private IUserRepository _userRepo;

        private IAddressRepository _addressRepo;
        private ICountryRepository _countryRepo;
        private IProvinceRepository _provinceRepo;
        private IDistrictRepository _districtRepo;

        private IContactDetailRepository _contactDetailRepo;
        private IErrorRepository _errorRepo;
        private IFeedbackRepository _feedbackRepo;
        private IFooterRepository _footerRepo;
        private IMenuGroupRepository _menuGroupRepo;
        private IMenuRepository _menuRepo;
        private IOrderRepository _orderRepo;
        private IPageRepository _pageRepo;
        private IPostRepository _postRepo;
        private IPostCategoryRepository _postCategoryRepo;
        private IProductRepository _productRepo;
        private IProductCategoryRepository _productCategoryRepo;
        private ISlideRepository _slideRepo;
        private ISupportOnlineRepository _supportOnlineRepo;
        private ISystemConfigRepository _systemConfigRepo;
        private ITagRepository _tagRepo;
        private IVisitorStatisticRepository _visitorStatisticRepo;


        public void SetUser(Guid userId)
        {
            this._userId = userId;
        }

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }
        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }


        #region init repos

        public ICountryRepository CountryRepo => _countryRepo ?? (_countryRepo = new CountryRepository(_dbContext));
        public IAddressRepository AddressRepo => _addressRepo ?? (_addressRepo = new AddressRepository(_dbContext));
        public IProvinceRepository ProvinceRepo => _provinceRepo ?? (_provinceRepo = new ProvinceRepository(_dbContext));
        public IDistrictRepository DistrictRepo => _districtRepo ?? (_districtRepo = new DistrictRepository(_dbContext));

        public IGroupRepository GroupRepo => _groupRepo ?? (_groupRepo = new GroupRepository(_dbContext));
        public IRoleRepository RoleRepo => _roleRepo ?? (_roleRepo = new RoleRepository(_dbContext));
        public IProfileRepository ProfileRepo => _profileRepo ?? (_profileRepo = new ProfileRepository(_dbContext));
        public IUserRepository UserRepo => _userRepo ?? (_userRepo = new UserRepository(_dbContext));

        public IContactDetailRepository ContactRepo => _contactDetailRepo ?? (_contactDetailRepo = new ContactDetailRepository(_dbContext));
        public IErrorRepository ErrorRepo => _errorRepo ?? (_errorRepo = new ErrorRepository(_dbContext));
        public IFeedbackRepository FeedbackRepo => _feedbackRepo ?? (_feedbackRepo = new FeedbackRepository(_dbContext));
        public IFooterRepository FooterRepo => _footerRepo ?? (_footerRepo = new FooterRepository(_dbContext));
        public IMenuGroupRepository MenuGroupRepo => _menuGroupRepo ?? (_menuGroupRepo = new MenuGroupRepository(_dbContext));
        public IMenuRepository MenuRepo => _menuRepo ?? (_menuRepo = new MenuRepository(_dbContext));
        public IOrderRepository OrderRepo => _orderRepo ?? (_orderRepo = new OrderRepository(_dbContext));
        public IPageRepository PageRepo => _pageRepo ?? (_pageRepo = new PageRepository(_dbContext));
        public IPostCategoryRepository PostCategoryRepo => _postCategoryRepo ?? (_postCategoryRepo = new PostCategoryRepository(_dbContext));
        public IPostRepository PostRepo => _postRepo ?? (_postRepo = new PostRepository(_dbContext));
        public IProductCategoryRepository ProductCategoryRepo => _productCategoryRepo ?? (_productCategoryRepo = new ProductCategoryRepository(_dbContext));
        public IProductRepository ProductRepo => _productRepo ?? (_productRepo = new ProductRepository(_dbContext));
        public ISlideRepository SlideRepo => _slideRepo ?? (_slideRepo = new SlideRepository(_dbContext));
        public ISupportOnlineRepository SupportOnlineRepo => _supportOnlineRepo ?? (_supportOnlineRepo = new SupportOnlineRepository(_dbContext));
        public ISystemConfigRepository SystemConfigRepo => _systemConfigRepo ?? (_systemConfigRepo = new SystemConfigRepository(_dbContext));
        public ITagRepository TagRepo => _tagRepo ?? (_tagRepo = new TagRepository(_dbContext));
        public IVisitorStatisticRepository VisitorStatisticRepo => _visitorStatisticRepo ?? (_visitorStatisticRepo = new VisitorStatisticRepository(_dbContext));

        #endregion

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!disposing) return;
            if (_dbContext == null) return;
            _dbContext.Dispose();
            _dbContext = null;

            _profileRepo = null;
        }
    }
}

#endregion