using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using Model.ModelView;
using PagedList;

namespace Model.Dao
{
    
    public class CategoryDao {

        private DemoASpDbContext1 db = null;

        public CategoryDao()
        {
            db = new DemoASpDbContext1();
        }
        public long Isert(Category entity)
        {
            db.Categories.Add(entity);
            db.SaveChanges();
            return entity.Id;
        }
        public bool Delete(int id)
        {
            try
            {
                var user = db.Categories.Find(id);
                db.Categories.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public IEnumerable<ModelCategory> ListAllPaging(string SearchString, int page = 1, int pagesize = 10)
        {
            IQueryable<ModelCategory> model = from a in db.Categories
                                      
                                         select new  ModelCategory
                                         {
                                            Id = a.Id,
                                            Image= a.Image,
                                             Name = a.Name,
                                             Description = a.Description

                                         };
            if (!string.IsNullOrEmpty(SearchString))
            {
                model = model.Where(x => x.Name.Contains(SearchString));
            }


                                         
            return model.OrderByDescending(x => x.Name).ToPagedList(page, pagesize);
        }
        }
}
