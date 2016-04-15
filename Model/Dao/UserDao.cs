using Model.EF;
using Model.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class UserDao
    {
        private DemoASpDbContext1 db = null;

        public UserDao()
        {
            db = new DemoASpDbContext1();
        }
        public Customer ViewDetail(int ? id)
        {
            return db.Customers.Find(id);
        }
        public List<Customer> ListAll() {
            var model = from p in db.Customers select p;
            return model.OrderBy(x => x.Name).ToList();
        }
        public long Create(Customer customer)
        {
            db.Customers.Add(customer);
            db.SaveChanges();
            return customer.Id;
        }
        public bool Delete(int id)
        {
            try {
                var user = db.Customers.Find(id);
                db.Customers.Remove(user);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
