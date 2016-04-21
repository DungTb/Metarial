using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using Model.ModelView;
using PagedList;
using System.Data.Entity;

namespace Model.Dao
{
    
    public class CategoryDao {

        private DemoASpDbContext1 db = null;

        public CategoryDao()
        {
            db = new DemoASpDbContext1();
        }
        public long Isert(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
            return category.Id;
        }
        public Category FillId(int ? id)
        {
            return db.Categories.Find(id);
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
        public long Edit(Category category,string img)
        {
            Category savecategory = new Category();
            savecategory.Id = category.Id;
            savecategory.Name = category.Name;
            savecategory.Code = category.Code;
            savecategory.Description = category.Description;
            savecategory.Alias = category.Alias;
            savecategory.Image = img;

            savecategory.Status = category.Status;
            savecategory.ModifiedOn = category.ModifiedOn;


            db.Entry(category).State = EntityState.Modified;
            db.SaveChanges();
            return category.Id;

        }
        public void SaveEditCategory(Category category)
        {

            db.Entry(category).State = System.Data.Entity.EntityState.Modified;


            db.SaveChanges();
        }
        public IEnumerable<CategoryModel> ListAllPaging(string SearchString, int page = 1, int pagesize = 10)
        {
            IQueryable<CategoryModel> model = from a in db.Categories
                                      
                                         select new  CategoryModel
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


                                         
            return model.OrderByDescending(x => x.Name).ToPagedList( page, pagesize);
        }
        }
}
