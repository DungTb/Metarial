using Model.EF;
using Model.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    class OrderDetailDao
    {
        private DemoASpDbContext1 db = null;
        public OrderDetailDao()
        {
            db = new DemoASpDbContext1();
        }
        public decimal ? GetTotal(int OrderId)
        {
            decimal ? total = 0;
            var OrderDetail = from a in db.OrderDetails
                              where a.OrderId == OrderId
                              select new OrderDetailModel
                              {
                                  PriceItem = (a.PriceItem) * (a.Number)
                              };
            foreach (var item in OrderDetail) {
                total += item.PriceItem;
            }
            return total;
        }
    }
}
