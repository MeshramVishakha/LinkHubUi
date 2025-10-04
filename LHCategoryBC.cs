using BOL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface ILHCategoryBC
    {
        IEnumerable<BOL.Category> GetAll();
        BOL.Category GetById(int Id);
        bool Create(BOL.Category category);
        bool Update(BOL.Category category);
        bool Delete(int Id);
    }
    public class LHCategoryBC : ILHCategoryBC
    {
        ICategoryDb categoryDb;
        public LHCategoryBC(ICategoryDb _categoryDb)
        {
            categoryDb = _categoryDb;

        }
        public bool Create(Category category)
        {
            return categoryDb.Create(category);
            
        }

        public bool Delete(int Id)
        {
           return categoryDb.Delete(Id);
        }

        public IEnumerable<Category> GetAll()
        {
            var categories= categoryDb.GetAll();
            return categories;
        }

        public Category GetById(int Id)
        {
            var category = categoryDb.GetById(Id);
            return category;
        }

        public bool Update(Category category)
        {
            return categoryDb.Update(category);
        }
    }
}
