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

    public class OrderDao
    {
        private DemoASpDbContext1 db = null;
        public OrderDao()
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
        public IEnumerable<OrderModel> ListAllPaging(string SearchString, int page = 1, int pagesize = 10)
        {
            IQueryable<OrderModel> model = (from a in db.Orders
                                           join b in db.Customers

                                           on a.UserId equals b.Id
                                           orderby b.CreatedOn descending

                                           select new OrderModel
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

        // function: get top order by customer id (customerId, quantity, orderBy)
        public List<OrderModel> GetTop(int customerId, int quantity)
        {
              var model =
             (from a in db.Orders
              join b in db.Customers
              on a.UserId equals b.Id 
              where b.Id == customerId
              orderby a.CreatedOn descending
              select new OrderModel
              {
                  Id = a.Id,
                  Code = a.Code,
                  Name = b.Name,
                  PaymetStatus = a.PaymetStatus,
                  ShippingStatus = a.ShippingStatus,
                  TotalPrice = a.TotalPrice,
                  CreatedOn = a.CreatedOn
              }).Take(quantity);
            return model.ToList();
        }
        public decimal? GetToTal(int customerId)
        {
            decimal? total = 0;
            var order = from a in db.Orders
                    where a.UserId == customerId
                    select new OrderModel
                    {
                        PaymetStatus = a.PaymetStatus,
                        TotalPrice = a.TotalPrice,
                    };
            foreach(var item in order)
            {
                if (item.PaymetStatus == true)
                {
                    total +=item.TotalPrice;
                }

            }
            return total;
        }

        public List<OrderDetailModel> ListOrderDetail(int id)
        {
            var model = (from a in db.OrderDetails
                         join b in db.Orders
                         on a.OrderId equals b.Id
                         where b.Id == id
                         
                         select new OrderDetailModel
                         {

                            CreatedOn = b.CreatedOn,
                             Name = b.Code,
                             Total = b.TotalPrice,
                             ProductName = a.ProductName,
                             Number = a.Number,
                             PriceItem = ((a.ProductPrice) * (a.Number)),
                             
                         });

            return model.ToList();
        }
    }
}
