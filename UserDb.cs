using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IUserDb
    {
        // Define methods for user operations
        IEnumerable<BOL.User> GetAll();
        BOL.User GetById(int Id);
        bool Create(BOL.User user);
        bool Update(BOL.User user);
        bool Delete(int Id);
    }
    public class UserDb:IUserDb
    {
        LinkHubDbContext linkHubDbContext;
        public UserDb(LinkHubDbContext _linkHubDbContext)
        {
            linkHubDbContext = _linkHubDbContext;

        }

        public bool Create(User user)
        {
            linkHubDbContext.Add(user);
            linkHubDbContext.SaveChanges();
            return true;
        }

        public bool Delete(int Id)
        {
            var user = linkHubDbContext.Users.Find(Id);
            if (user != null)
            {
                linkHubDbContext.Users.Remove(user);
                linkHubDbContext.SaveChanges();
            }
            return true;
        }

        public IEnumerable<User> GetAll()
        {
           return linkHubDbContext.Users.ToList();
        }

        public User GetById(int Id)
        {
            var user=linkHubDbContext.Users.Find(Id);
            return user;
        }

        public bool Update(User user)
        {
            linkHubDbContext.Users.Update(user);
            linkHubDbContext.SaveChanges();
            return true;
        }
    }
}
