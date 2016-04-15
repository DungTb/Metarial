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
 public class AdminDao
    {
        private DemoASpDbContext1 db = null;

        public AdminDao()
        {
            db = new DemoASpDbContext1();
        }
        public long Isert(Customer entity)
        {
            db.Customers.Add(entity);
            db.SaveChanges();
            return entity.Id;
        }
        public Customer GetById(string customer)
        {
            return db.Customers.SingleOrDefault(x => x.Name == customer);
        }
        public long Edit(Customer product)
        {
            db.Entry(product).State = EntityState.Modified;
            db.SaveChanges();
            return product.Id;

        }
        public bool Delete(int id)
        {
            try
            {
                var user = db.Customers.Find(id);
                db.Customers.Remove(user);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public Customer GetbyId(int? id)
        {
            return db.Customers.Find(id);
        }
        public int Login(string userName, string passWord) {
            var result = db.Customers.SingleOrDefault(x => x.Name == userName);
                if (result == null)
            {
                return 0;
            }
            else {                          
                    if (result.PasswordHash == passWord)
                        return 1;
                    else
                        return -2;

                }
            }
        public IEnumerable<ModelAdmin> ListAllPaging(string SearchString, int page = 1, int pagesize = 10)
        {
            // trocvao db tra ra danh sach n account
            
            


            IQueryable<ModelAdmin> model = (from a in db.Customers
                                            join b in db.Orders
                                            on a.Id equals b.UserId
                                            orderby b.CreatedOn descending
                                            select new ModelAdmin
                                            {  
                                                Id = a.Id,
                                                Name = a.Name,
                                                EmailCustomer = a.Email,
                                                Code = b.Code,
                                                CreatedOn = b.CreatedOn,
                                                CountOders = a.Orders.Count,
                                                Status = b.PaymetStatus,
                                                Total =  a.Orders.Sum(o => o.TotalPrice)
                                            });
           
           
            //var itemsIncart = from y in model where (y => y.S     select (y => y.T)
            if (!string.IsNullOrEmpty(SearchString))
            {
                model = model.Where(x => x.Name.Contains(SearchString));
            }



            return model.OrderByDescending(x => x.Name).ToPagedList(page, pagesize);
        }
    }
}
