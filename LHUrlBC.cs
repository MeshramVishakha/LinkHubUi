using BOL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface ILHUrlBc
    {
        IEnumerable<LHUrl> GetAll();
        IEnumerable<LHUrl> GetAll(bool IsApproved);
        LHUrl GetById(int id);
        bool Create(LHUrl LHUrl);
        bool Update(LHUrl LHUrl);
        bool Delete(int id);
    }
    public class LHUrlBC : ILHUrlBc
    {
        ILHUrlDb LHUrlDb;

        public LHUrlBC(ILHUrlDb _LHUrlDb)
        {
            LHUrlDb = _LHUrlDb;
        }

        public bool Create(LHUrl LHUrl)
        {
            return LHUrlDb.Create(LHUrl);
        }

        public bool Delete(int id)
        {
            return LHUrlDb.Delete(id);
        }

        public IEnumerable<LHUrl> GetAll()
        {
            var lHUrls = LHUrlDb.GetAll();
            return lHUrls;
        }

        public IEnumerable<LHUrl> GetAll(bool IsApproved)
        {
            var lHUrls = LHUrlDb.GetAll(IsApproved);
            return lHUrls;
        }

        public LHUrl GetById(int id)
        {
            var LHUrl = LHUrlDb.GetById(id);
            return LHUrl;
        }

        public bool Update(LHUrl LHUrl)
        {
            return LHUrlDb.Update(LHUrl);
        }
    }
}

