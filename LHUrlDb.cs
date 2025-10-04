using BOL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface ILHUrlDb
    {
        // Define methods for LHUrl operations
        IEnumerable<LHUrl> GetAll();
        IEnumerable<LHUrl> GetAll(bool IsApproved);
        LHUrl GetById(int id);
        bool Create(LHUrl LHUrl);
        bool Update(LHUrl LHUrl);
        bool Delete(int id);
    }
    public class LHUrlDb : ILHUrlDb
    {
        LinkHubDbContext LHDbContext;

        public LHUrlDb(LinkHubDbContext _LHDbContext)
        {
            LHDbContext = _LHDbContext;
        }

        public bool Create(LHUrl LHUrl)
        {
            LHDbContext.Add(LHUrl);
            LHDbContext.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var LHUrl = LHDbContext.LHUrls.Find(id);
            LHDbContext.Remove<LHUrl>(LHUrl);
            LHDbContext.SaveChanges();
            return true;
        }

        public IEnumerable<LHUrl> GetAll()
        {
            return LHDbContext.LHUrls;
        }

        public IEnumerable<LHUrl> GetAll(bool IsApproved)
        {
            return LHDbContext.LHUrls.Where(x => x.IsApproved == IsApproved)
                                     .Include(x => x.Category)
                                     .Include(x => x.User);

        }

        public LHUrl GetById(int id)
        {
            var LHUrl = LHDbContext.LHUrls.Find(id);
            return LHUrl;
        }

        public bool Update(LHUrl LHUrl)
        {
            LHDbContext.Update<LHUrl>(LHUrl);
            LHDbContext.SaveChanges();
            return true;
        }
    }
}
