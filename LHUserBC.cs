using BOL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface ILHUserBC
    {
        IEnumerable<BOL.User> GetAll();
        BOL.User GetById(int Id);
        bool Create(BOL.User user);
        bool Update(BOL.User user);
        bool Delete(int Id);
    }
    public class LHUserBC : ILHUserBC
    {
        IUserDb userDb;
        public LHUserBC(IUserDb _userDb)
        {
            userDb = _userDb;
        }
        public bool Create(User user)
        {
            return userDb.Create(user);
        }

        public bool Delete(int Id)
        {
            return userDb.Delete(Id);
        }

        public IEnumerable<User> GetAll()
        {
            var users = userDb.GetAll();
            return users;
        }

        public User GetById(int Id)
        {
            var user = userDb.GetById(Id);
            return user;
        }

        public bool Update(User user)
        {
            return userDb.Update(user);
        }
    }
}
