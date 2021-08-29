using Yyuri.Domain;
using Yyuri.Domain.Accounts.Models;
using Yyuri.Domain.Address;
using Yyuri.Domain.Address.Models;
using Yyuri.Domain.Identity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Yyuri.Domain.Shop.Model;
using Yyuri.Domain.Account.Models;

namespace Yyuri.Data.EntityFramework
{
    public class SCDataContext : IdentityDbContext<User, Role, Guid, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>//, ISCDataContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        #region Contructor

        public SCDataContext(DbContextOptions<SCDataContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //IMPORTANT: must to declare key for table. use HasKey() or [Key] in each table

            modelBuilder.Entity<User>().ToTable("Users").HasKey(x=>x.Id);
            modelBuilder.Entity<Role>().ToTable("Roles").HasKey(x=>x.Id);
            modelBuilder.Entity<RoleClaim>().ToTable("RoleClaims").HasKey(x => x.Id);
            modelBuilder.Entity<UserClaim>().ToTable("UserClaims").HasKey(x => x.Id);
            modelBuilder.Entity<UserLogin>().ToTable("UserLogins").HasKey(x => x.UserId);
            modelBuilder.Entity<UserRole>().ToTable("UserRoles").HasKey(x => new { x.UserId, x.RoleId });
            modelBuilder.Entity<UserToken>().ToTable("UserTokens").HasKey(x => x.UserId);

            modelBuilder.Entity<UserGroup>()
                 .ToTable("UserGroups")
                 .HasKey(c => new { c.GroupId, c.UserId });
            modelBuilder.Entity<UserGroup>()
                .HasOne(ug => ug.User)
                .WithMany(u => u.UserGroups)
                .HasForeignKey(ug => ug.UserId);
            modelBuilder.Entity<UserGroup>()
                .HasOne(ug => ug.Group)
                .WithMany(u => u.UserGroups)
                .HasForeignKey(ug => ug.GroupId);

            modelBuilder.Entity<GroupRole>()
                .ToTable("GroupRoles")
                .HasKey(c => new { c.GroupId, c.RoleId });
            modelBuilder.Entity<GroupRole>()
                .HasOne(gr => gr.Group)
                .WithMany(a => a.GroupRoles)
                .HasForeignKey(gr => gr.GroupId);
            modelBuilder.Entity<GroupRole>()
                .HasOne(gr => gr.Role)
                .WithMany(a => a.GroupRoles)
                .HasForeignKey(gr => gr.RoleId);

            modelBuilder.Entity<OrderDetail>()
                .ToTable("OrderDetails")
                .HasKey(c => new { c.OrderID, c.ProductID });
            modelBuilder.Entity<OrderDetail>()
                .HasOne(ug => ug.Order)
                .WithMany(u => u.OrderDetails)
                .HasForeignKey(ug => ug.OrderID);
            modelBuilder.Entity<OrderDetail>()
                .HasOne(ug => ug.ProductCategory)
                .WithMany(u => u.OrderDetails)
                .HasForeignKey(ug => ug.ProductID);

            modelBuilder.Entity<PostTag>()
                .ToTable("PostTags")
                .HasKey(c => new { c.PostID, c.TagID });
            modelBuilder.Entity<PostTag>()
                .HasOne(ug => ug.Post)
                .WithMany(u => u.PostTags)
                .HasForeignKey(ug => ug.PostID);
            modelBuilder.Entity<PostTag>()
                .HasOne(ug => ug.Tag)
                .WithMany(u => u.PostTags)
                .HasForeignKey(ug => ug.TagID);

            modelBuilder.Entity<ProductTag>()
                .ToTable("ProductTags")
                .HasKey(c => new { c.ProductID, c.TagID });
            modelBuilder.Entity<ProductTag>()
                .HasOne(ug => ug.Product)
                .WithMany(u => u.ProductTags)
                .HasForeignKey(ug => ug.ProductID);
            modelBuilder.Entity<ProductTag>()
                .HasOne(ug => ug.Tag)
                .WithMany(u => u.ProductTags)
                .HasForeignKey(ug => ug.TagID);


        }

        #endregion Contructor

        #region DECLARE TABLES        
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Province> Province { get; set; }
        public virtual DbSet<District> District { get; set; }
        public virtual DbSet<Address> Address { get; set; }

        public virtual DbSet<Group> Group { get; set; }
        public virtual DbSet<GroupRole> GroupRole { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<RoleClaim> RoleClaim { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserClaim> UserClaim { get; set; }
        public virtual DbSet<UserGroup> UserGroup { get; set; }
        public virtual DbSet<UserLogin> UserLogin { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
        public virtual DbSet<UserToken> UserToken { get; set; }

        public virtual DbSet<Profile> Profile { get; set; }
        public virtual DbSet<VerificationEmail> VerificationEmail { get; set; }

        public virtual DbSet<ContactDetail> ContactDetail { get; set; }
        public virtual DbSet<Error> Error { get; set; }
        public virtual DbSet<Feedback> Feedback { get; set; }
        public virtual DbSet<Footer> Footer { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<MenuGroup> MenuGroup { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderDetail> OrderDetail { get; set; }
        public virtual DbSet<Page> Page { get; set; }
        public virtual DbSet<Post> Post { get; set; }
        public virtual DbSet<PostCategory> PostCategorie { get; set; }
        public virtual DbSet<PostTag> PostTag { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductCategory> ProductCategorie { get; set; }
        public virtual DbSet<ProductTag> ProductTag { get; set; }
        public virtual DbSet<Slide> Slide { get; set; }
        public virtual DbSet<SupportOnline> SupportOnline { get; set; }
        public virtual DbSet<SystemConfig> SystemConfig { get; set; }
        public virtual DbSet<Tag> Tag { get; set; } 

        #endregion

        #region Extension
        public TEntity FindById<TEntity>(params object[] ids) where TEntity : class
        {
            return base.Set<TEntity>().Find(ids);
        }
        public IQueryable<TEntity> Get<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        public new DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        public TEntity Insert<TEntity>(TEntity entity) where TEntity : class
        {
            var result = base.Set<TEntity>().Add(entity).Entity;

            var creationTrackingEntity = entity as IEntityTrackingCreation;
            if (creationTrackingEntity != null)
            {
                creationTrackingEntity.DateCreated = DateTime.UtcNow;
            }

            //((IObjectState)entity).State = ObjectState.Added;
            return result;
        }

        public void Update<TEntity>(TEntity entity) where TEntity : class
        {
            base.Set<TEntity>().Attach(entity);

            var modifyTrackingEntity = entity as IEntityTrackingModified;
            if (modifyTrackingEntity != null)
            {
                modifyTrackingEntity.DateModified = DateTime.UtcNow;
            }

            //((IObjectState)entity).State = ObjectState.Modified;
        }

        public void Update<TEntity, TKey>(TEntity entity, params Expression<Func<TEntity, object>>[] properties) where TEntity : class, IEntity<TKey>
        {
            //base.Set<TEntity>().Attach(entity);
            //DbEntityEntry<TEntity> entry = base.Entry(entity);

            //foreach (var selector in properties)
            //{
            //    entry.Property(selector).IsModified = true;
            //}

            Dictionary<object, object> originalValues = new Dictionary<object, object>();
            TEntity entityToUpdate = base.Set<TEntity>().Find(entity.Id);

            foreach (var property in properties)
            {
                var val = base.Entry(entityToUpdate).Property(property).OriginalValue;
                originalValues.Add(property, val);
            }

            //base.Entry(entityToUpdate).State = EntityState.Detached;

            //base.Entry(entity).State = EntityState.Unchanged;
            foreach (var property in properties)
            {
                base.Entry(entity).Property(property).OriginalValue = originalValues[property];
                base.Entry(entity).Property(property).IsModified = true;
            }
        }

        public void Delete<TEntity>(params object[] ids) where TEntity : class
        {
            var entity = FindById<TEntity>(ids);
            //((IObjectState)entity).State = ObjectState.Deleted;
            Delete(entity);
        }

        public void Delete<TEntity>(TEntity entity) where TEntity : class
        {
            base.Set<TEntity>().Attach(entity);
            base.Set<TEntity>().Remove(entity);
        }
        public void Delete<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            base.Set<TEntity>().RemoveRange(entities);
        }

        public int Execute(string sqlCommand)
        {
            return Database.ExecuteSqlCommand(sqlCommand);
        }

        public int Execute(string sqlCommand, params object[] args)
        {
            var result = Database.ExecuteSqlCommand(sqlCommand, args);
            return result;
        }
        public override int SaveChanges()
        {
            OnBeforeSaving();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            OnBeforeSaving();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void OnBeforeSaving()
        {
            var entries = ChangeTracker.Entries();
            foreach (var entry in entries)
            {
                if (!(entry.Entity is IAudit audit)) continue;
                var authenticatedUserId = _httpContextAccessor?.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (String.IsNullOrEmpty(authenticatedUserId))
                {
                    authenticatedUserId = _httpContextAccessor?.HttpContext?.User?.Identity.Name; 
                }

                var now = DateTime.UtcNow;
                switch (entry.State)
                {
                    case EntityState.Modified:
                        audit.ChangedStamp = now;
                        audit.ChangedUserId = authenticatedUserId;
                        break;

                    case EntityState.Added:
                        audit.AddedStamp = now;
                        audit.AddedUserId = authenticatedUserId;
                        break;
                }
            }
        }

        #endregion

        #region Dispose
        private bool _disposed;

        public override void Dispose()
        {
            if (!_disposed)
            {
                _disposed = true;
            }
        }

        // This is overridden to prevent someone from calling SaveChanges without specifying the user making the change
        #endregion Dispose

    }
}