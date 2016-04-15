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
   
   public class OderDao
    {
        private DemoASpDbContext1 db = null;
        public OderDao()
        {
            db = new DemoASpDbContext1();
        }
        public Order GetbyId(int? id)
        {
            return db.Orders.Find(id);
        }
        public long Edit(Order product)
        {
            db.Entry(product).State = EntityState.Modified;
            db.SaveChanges();
            return product.Id;

        }
        public bool Delete(int id)
        {
            try
            {
                var user = db.Orders.Find(id);
                db.Orders.Remove(user);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public long Isert(Order order)
        {
            db.Orders.Add(order);
            db.SaveChanges();
            return order.Id;
        }
        public IEnumerable<ModelOder> ListAllPaging(string SearchString, int page = 1, int pagesize = 10)
        {

           


            IQueryable<ModelOder> model = (from a in db.Orders
                                            join b in db.Customers
                                            on a.UserId equals b.Id
                                           
                                            select new ModelOder
                                            {   
                                                
                                                Id = a.Id,
                                                Code = a.Code,
                                                Name = b.Name,
                                                PaymetStatus = a.PaymetStatus,
                                                ShippingStatus = a.ShippingStatus,
                                                TotalPrice = a.TotalPrice,
                                                CreatedOn = a.CreatedOn
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
