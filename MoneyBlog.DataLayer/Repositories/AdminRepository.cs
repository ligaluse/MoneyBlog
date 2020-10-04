using MoneyBlog.DataLayer.IRepositories;
using MoneyBlog.DataLayer.Models;
using System.Collections.Generic;
using System.Linq;

namespace MoneyBlog.DataLayer.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        ApplicationDbContext context = new ApplicationDbContext();
        DefaultConnection db = new DefaultConnection();
        public List<AspNetUser> AspNetUsers()
        {
            List<AspNetUser> AspNetUsers = db.AspNetUsers.ToList();
            return AspNetUsers;
        }
        public AspNetUser GetUser(string id)
        {
            var user = db.AspNetUsers.FirstOrDefault(i => i.Id == id);
            return user;
        }
        public IEnumerable<UsersInRolesModel> UsersWithRoles()
        {
            //šis ir jāsadala datalayer + service
            //foreach
            //atgriezt no context visus userus. service- foreach user..... 

            var usersWithRoles = (from user in context.Users
                                  select new
                                  {
                                      UserId = user.Id,
                                      Email = user.Email,
                                      RoleNames = (from userRole in user.Roles
                                                   join role in context.Roles on userRole.RoleId
                                                   equals role.Id
                                                   select role.Name).ToList()
                                  }).ToList()
                                     .Select(p => new UsersInRolesModel()

                                     {
                                         UserId = p.UserId,
                                         Email = p.Email,
                                         Role = string.Join(",", p.RoleNames)
                                     });
            return usersWithRoles;
            //var usersWithRolesData = (from user in context.Users
            //                          select new
            //                          {
            //                              UserId = user.Id,
            //                              Email = user.Email,
            //                              RoleNames = (from userRole in user.Roles
            //                                           join role in context.Roles on userRole.RoleId
            //                                           equals role.Id
            //                                           select role.Name).ToList()
            //                          }).ToList();

            //return usersWithRolesData;
        }
    }
}
