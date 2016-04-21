using Model.EF;
using Model.ModelView;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{


    public class ProductDao
    {

        private DemoASpDbContext1 db = null;
        public Product GetbyId(int? id)
        {
            return db.Products.Find(id);
        }
        public ProductDao()
        {
            db = new DemoASpDbContext1();
        }
        public long Insert(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
            return product.Id;
        }
        public long Edit(Product product) {
            db.Entry(product).State = EntityState.Modified;
            db.SaveChanges();
            return product.Id;

        }
        public bool Delete(int id)
        {
            try
            {
                var user = db.Products.Find(id);
                db.Products.Remove(user);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public List<Product> GetAll() {
            return db.Products.ToList();
        }
        public IEnumerable<ProductModel> GetAllPaging(string SearchString, int page = 1, int pagesize = 10)
        {
            IQueryable<ProductModel> model = from a in db.Products
                                            join  b in db.Manufacturers
                                            
                                            on a.ManufacturerId equals b.Id 
                                            join c in db.Categories
                                            on b.Id equals c.Id

                                              select new ProductModel
                                              {
                                                  Id = a.Id,
                                                  NameCategory = c.Name,
                                                  ProductSpecies = a.ProductSpecies,
                                                  Image = a.Image,
                                                  Name = a.Name,
                                                  VendorName = b.Name

                                              };
            if (!string.IsNullOrEmpty(SearchString))
            {
                model = model.Where(x => x.Name.Contains(SearchString));
            }



            return model.OrderByDescending(x => x.Name).ToPagedList(page, pagesize);
        }
    }
    }
