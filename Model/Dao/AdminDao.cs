using Model.EF;
using System;
using System.Collections.Generic;
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
        public Customer ViewDetail(int? id)
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
    }
}
