using Yyuri.Commons.Models;
using Yyuri.Data.EntityFramework;
using Yyuri.Data.Repositories;
using Yyuri.Domain.Account.Models;
using Yyuri.Domain.Accounts.Repositories;
using Yyuri.Domain.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Yyuri.Data.Accounts.Repositories
{
    public class UserRepository : Repository<User, Guid>, IUserRepository
    {
        public UserRepository(SCDataContext context) : base(context)
        {
        }

        //public IEnumerable<User> Search()
        //{
        //    //var profile = this.GetAll().Where(x => (!String.IsNullOrEmpty(x.UserId) && x.UserId.Equals(userId, StringComparison.OrdinalIgnoreCase))).FirstOrDefault();
        //    var users = this.GetAll().OrderBy(x => x.FirstName);
        //    return users;
        //}

        //public void SetRoleGroup(Guid userId, Guid groupId)
        //{
        //    var user = this.GetById(userId);

        //    if (!user.UserGroups.Any(x => x.GroupId == groupId))
        //    {
        //        var userGroups = user.UserGroups.ToList();

        //        foreach (var item in userGroups)
        //        {
        //            user.UserGroups.Remove(item);
        //        }

        //        Group rg = this.DataContext.Get<Group>().Where(x => x.Id == groupId).FirstOrDefault();

        //        if (rg != null)
        //        {
        //            user.UserGroups.Add(new UserGroup() { UserId = userId, GroupId = rg.Id });

        //            List<string> roles = new List<string>();
        //            foreach (var g in user.UserGroups)
        //            {
        //                roles.AddRange(g.Group.GroupRoles.Select(x => x.Role.Name));
        //            }

        //            var allRoles = this.DataContext.Get<Role>().Where(x => roles.Contains(x.Name)).Select(x => x.Id).ToList();
        //            var existingRoles = user.UserRoles.Select(x => x.RoleId).ToList();

        //            // added roles
        //            allRoles.Where(x => !existingRoles.Contains(x)).ToList().ForEach(x => user.UserRoles.Add(new UserRole() { UserId = user.Id, RoleId = x }));

        //            // remove
        //            user.UserRoles.Where(x => !allRoles.Contains(x.RoleId)).ToList().ForEach(x => user.UserRoles.Remove(x));

        //        }
        //    }
        //}

        //public Group GetRoleGroup(Guid userId)
        //{
        //    var user = this.GetById(userId);
        //    if(user.UserGroups.Count > 0)
        //    {
        //       return user.UserGroups.FirstOrDefault().Group;
        //    }
        //    return null;
        //}

        //public void UpdateRoles(Guid groupId)
        //{
        //    var group = this.DataContext.Get<Group>().Where(x => x.Id == groupId).FirstOrDefault();
        //    var users = group.UserGroups.Select(x => x.User);

        //    foreach (var user in users)
        //    {
        //        List<string> roles = new List<string>();

        //        foreach (var g in user.UserGroups.Select(x => x.Group))
        //        {
        //            roles.AddRange(g.GroupRoles.Select(x => x.Role.Name));
        //        }

        //        var allRoles = this.DataContext.Get<Role>().Where(x => roles.Contains(x.Name)).Select(x => x.Id).ToList();
        //        var existingRoles = user.UserRoles.Select(x => x.RoleId).ToList();

        //        // added roles
        //        allRoles.Where(x => !existingRoles.Contains(x)).ToList().ForEach(x => user.UserRoles.Add(new UserRole() { UserId = user.Id, RoleId = x }));

        //        // remove
        //        user.UserRoles.Where(x => !allRoles.Contains(x.RoleId)).ToList().ForEach(x => user.UserRoles.Remove(x));
        //    }
        //}
        //public void UpdateRolesVer2(Guid groupId, IEnumerable<string> selectedRoles)
        //{
        //    var User = DataContext.Set<UserGroup>().Where( x => x.GroupId == groupId).Select(x=>x.User.Id);
        //    if (User != null)
        //    {
        //        var UserRoleRemove = DataContext.Set<UserRole>().Where(x => User.Contains(x.UserId));
        //        DataContext.Set<UserRole>().RemoveRange(UserRoleRemove);

        //        var IdRole = DataContext.Set<Role>().Where(x => selectedRoles.Contains(x.Name)).ToList();
        //        List<UserRole> listUserRoleAdd = new List<UserRole>();
        //        foreach (var userid in User.ToList())
        //        {
        //            foreach (var item in IdRole)
        //            {
        //                listUserRoleAdd.Add(new UserRole { UserId = userid, RoleId = item.Id });
        //            }
        //        }

        //        DataContext.Set<UserRole>().AddRange(listUserRoleAdd);
        //    }
        //}


        //public IEnumerable<UserRolesNameViewModel> GetUserRoles(Guid userId)
        //{
        //    //var user = this.GetById(userId);
        //    //var xxx = this.DataContext.Get<UserRole>().Where(x => x.UserId == user.Id).Select(x => x.RoleId);

        //    //var userRoles = user.UserRoles.Select(x => x.RoleId);


        //    var query = (from user in DataContext.User
        //                 join userRole in DataContext.UserRole on user.Id equals userRole.UserId
        //                  join role in DataContext.Role on userRole.RoleId equals role.Id
        //                  where user.Id == userId
        //                  select new UserRolesNameViewModel()
        //                  {
        //                     Name = role.Name
        //                  }).AsEnumerable();
        //    return query;

        //}

        //public EmployeeSearch SearchWithPaging(string searchText, int pageIndex, int pageSize)
        //{
        //    if(!String.IsNullOrEmpty(searchText))
        //        searchText = searchText.ToLower();

        //    var query = (from u in DataContext.User
        //                 join p in DataContext.Profile on u.Id equals p.UserId
        //                 where (u.IsActive && !p.IsDeleted && 
        //                 (String.IsNullOrEmpty(searchText) ||
        //                 (u.FirstName != null && u.FirstName.ToLower().Contains(searchText)) ||
        //                 u.LastName != null && u.LastName.ToLower().Contains(searchText) ||
        //                 u.Email != null && u.Email.ToLower().Contains(searchText)) ||
        //                 u.UserName != null && u.UserName.ToLower().Contains(searchText) ||
        //                 u.PhoneNumber != null && u.PhoneNumber.Contains(searchText))
        //                 select new EmployeeDetail
        //                 {
        //                     UserCode = u.UserCode,
        //                     Id = u.Id,
        //                     UserName = u.UserName,
        //                     FirstName = u.FirstName,
        //                     LastName = u.LastName,
        //                     Email = u.Email,
        //                     PhoneNumber = u.PhoneNumber,
        //                     Title = u.Title,
        //                     PhotoUrl = u.PhotoUrl,
        //                 }).OrderBy(x => x.FirstName).Skip((pageIndex - 1) * pageSize).Take(pageSize);

        //    int totalItem = DataContext.User.Where(x =>
        //                    (String.IsNullOrEmpty(searchText) || (x.FirstName != null && x.FirstName.ToLower().Contains(searchText.ToLower())
        //                        || x.LastName != null && x.LastName.ToLower().Contains(searchText.ToLower())
        //                        || x.Email != null && x.Email.ToLower().Contains(searchText.ToLower()))
        //                    )).Count();

        //    EmployeeSearch model = new EmployeeSearch()
        //    {
        //        UsersProfile = query,
        //        TotalItem = totalItem
        //    };
        //    return model;
        //}
        
        //public DbSet<UserRole> GetUserRoleRepo()
        //{
        //    return DataContext.Set<UserRole>();
        //}

        //public List<Guid> GetUserIds(List<String> deviceId)
        //{
        //    return this.GetAll().Where(x => deviceId.Contains(x.DeviceUserID)).Select(x => x.Id).ToList();
        //}

        //public Guid GetUserId(string deviceCheckinUserId)
        //{
        //    return this.GetAll().Where(x => !String.IsNullOrEmpty(x.DeviceUserID) && String.Equals(x.DeviceUserID, deviceCheckinUserId, StringComparison.OrdinalIgnoreCase)).Select(x => x.Id).FirstOrDefault();
        //}

        //check usser name
        public bool UserNameExists(string userName)
        {
            return DataContext.User.Any(u => u.UserName.ToUpper() == userName.ToUpper());
        }

        public User UserNameExist(string userName)
        {
            return DataContext.User.SingleOrDefault(x => x.UserName == userName);
        }

    }
}
