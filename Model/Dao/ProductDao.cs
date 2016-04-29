using Model.EF;
using Model.ModelView;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Linq;
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
        public void Create(ProductModel product , string fileimg, List<String> ListImg) {
            Product createproduct = new Product();
            createproduct.Id = product.Id;
            createproduct.Name = product.Name;
            createproduct.Code = product.Code;
            createproduct.Description = product.Description;
            createproduct.Content1 = product.Content1;
            createproduct.Image = "/Upload/ProductImg/" + fileimg;
            createproduct.ManufacturerId = product.ManufacturerId;
            createproduct.CategoryId = product.CategoryId;
         
            db.Products.Add(createproduct);
            var idproduct = db.Products.Find(product.Id);
            for (int i = 0; i < ListImg.Count; i++)
            {
                ProductImage productImg = new ProductImage();
                productImg.ProductId = idproduct.Id;
                productImg.Image = "/Upload/ProductImg/" + ListImg[i];
                db.ProductImages.Add(productImg);
                db.SaveChanges();


            }
             db.SaveChanges();

        }
        public long Edit(Product product, string img) {
            Product createProduct = new Product();
            createProduct.Id = product.Id;
            createProduct.Name = product.Name;
            createProduct.Code = product.Code;
            createProduct.Description = product.Description;
            createProduct.Alias = product.Alias;
            createProduct.Image = img;
            createProduct.CreatedOn = DateTime.Now;
            createProduct.Price = product.Price;
            createProduct.SalePrice = product.SalePrice;
            createProduct.BarCode = product.BarCode;
            createProduct.Size = product.Size;
            createProduct.Unit = product.Unit;
            createProduct.StockStatus = product.StockStatus;
            createProduct.AvailableStatus = product.AvailableStatus;
            createProduct.ProductSpecies = product.ProductSpecies;


            db.Entry(product).State = EntityState.Modified;
            db.SaveChanges();
            return product.Id;

        }
        public List<ManufacturerModel> ListMaufacturer() {
            var manu = from a in db.Manufacturers
                       select new ManufacturerModel {
                           Id = a.Id,
                           Name = a.Name,
                           Code = a.Code
        };
            return manu.ToList();
        }
        public List<CategoryModel> ListCategory() {
            var category = from a in db.Categories
                           select new CategoryModel
                           {
                               Id = a.Id,
                               Name = a.Name


                           };
            return category.ToList();
        }
        
        public bool DeleteData(int id) {
            try
            {
                var model = new List<ProductModel>();
                var product = from a in db.Products
                              join b in db.Categories
                              on a.CategoryId equals b.Id
                              select new ProductModel
                              {
                                  CategoryId= a.CategoryId,
                                  Name = a.Name,
                                  VendorName = b.Name
                              };

                var productcategory = product.FirstOrDefault(c => c.CategoryId == id);
                model = product.ToList();
                if (productcategory == null)
                {
                    return false;
                }
                model.Remove(productcategory);
                db.SaveChanges();

                return true;

            }
            catch (Exception ex)
            {
                return false;
            }


        }
        public bool Delete(int id)
        {
            try
            {
              
                var product = db.Products.Find(id);
                var produccategory = db.ProductImages.Where(x => x.ProductId == id);
                foreach (var a in produccategory) {
                    db.ProductImages.Remove(a);
                }
                db.Products.Remove(product);
                db.SaveChanges();
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
                                           on a.CategoryId equals c.Id

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
