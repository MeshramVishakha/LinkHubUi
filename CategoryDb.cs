using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface ICategoryDb
    {
        IEnumerable<BOL.Category> GetAll();
        Category GetById(int Id);

        bool Create(Category category);
        bool Update(Category category);
        bool Delete(int Id);
    }
    public class CategoryDb : ICategoryDb
    {
        LinkHubDbContext linkHubDbContext;
        public CategoryDb(LinkHubDbContext _linkHubDbContext)
        {
            linkHubDbContext= _linkHubDbContext;
        }
        public bool Create(Category category)
        {
             linkHubDbContext.Add(category);
            linkHubDbContext.SaveChanges();
            return true;
        }

        public bool Delete(int Id)
        {
            var category = linkHubDbContext.Categories.Find(Id);
            if (category != null)
            {
                linkHubDbContext.Categories.Remove(category);
                linkHubDbContext.SaveChanges();
                
            }
            return true;
        }

        public IEnumerable<Category> GetAll()
        {
            return linkHubDbContext.Categories.ToList();
        }

        public Category GetById(int Id)
        {
           var category= linkHubDbContext.Categories.Find(Id);
            return category;
        }

        public bool Update(Category category)
        {
           linkHubDbContext.Update(category);
            linkHubDbContext.SaveChanges();
            return true;
        }
    }
}
