using Model.EF;
using Model.ModelView;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{


    public class ProductDao
    {

        private DemoASpDbContext1 db = null;

        public ProductDao()
        {
            db = new DemoASpDbContext1();
        }
        public IEnumerable<ModelProduct> ListAllPaging(string SearchString, int page = 1, int pagesize = 10)
        {
            IQueryable<ModelProduct> model = from a in db.Products
                                            join  b in db.Manufacturers
                                            on a.CategoryId equals b.Id

                                              select new ModelProduct
                                              {
                                                  Id = a.Id,
                                                  ProductSpecies = a.ProductSpecies,
                                                  Image = a.Image,
                                                  Name = a.Name,
                                                  NameNCC = b.Name

                                              };
            if (!string.IsNullOrEmpty(SearchString))
            {
                model = model.Where(x => x.Name.Contains(SearchString));
            }



            return model.OrderByDescending(x => x.Name).ToPagedList(page, pagesize);
        }
    }
    }
