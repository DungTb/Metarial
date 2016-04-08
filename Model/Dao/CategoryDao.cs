using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using Model.ModelView;

namespace Model.Dao
{
    public class CategoryDao {

        private DemoASpDbContext1 db = null;

        public CategoryDao()
        {
            db = new DemoASpDbContext1();
        }
        public IEnumerable<ModelCategory> ListAll()
        {
            IQueryable<ModelCategory> model = from a in db.Categories
                                      
                                         select new ModelCategory
                                         {
                                             Name = a.Name,
                                             Description = a.Description

                                         };

                                         
            return model.ToList();
        }
        }
}
