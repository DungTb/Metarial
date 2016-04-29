using Model.Dao;
using Model.EF;
using Model.ModelView;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoASP.Areas.Admin.Controllers
{
    public class User1Controller : Controller
    {
        private DemoASpDbContext1 db = new DemoASpDbContext1();
        UserDao dao = new UserDao();
        OrderDao orderDao = new OrderDao();

        // GET: Admin/User1
        public ActionResult Index(string SearchString, int page = 1, int pagesize = 10)
        {
            // 1. Tao CustomerModel ok
            // 2. Khai bao model la list cac CustomerModel List<CustomerModel>ok
            // 3. Lay danh sach Customers co phan trang ok
            // 4. Chay vong lap qua danh sach customers nhan dc o buoc 3 ok
            // 5. Lay order moi nhat cho tung customer trong vong lap o buoc 4 ok
            // 6. Them CustomerModel theo cac data da co (customer, order moi nhat)
            
                        List<CustomerModel> model = new List<CustomerModel>();
                        var customers = dao.ListAllPaging(SearchString, page, pagesize);



                        foreach (var customer in customers)
                        {
                            var orders = new OrderDao().GetTop(customer.Id, 1);
                            OrderModel firstOrder = null;
                            if (orders != null && orders.Any())
                            {
                                firstOrder = orders.FirstOrDefault();
                            }
                            model.Add(new CustomerModel()
                            {
                                Name = customer.Name,
                                Id = customer.Id,
                                EmailCustomer = customer.EmailCustomer,
                                Code = firstOrder != null ? firstOrder.Code : "",
                                CountOders = customer.CountOders,
                                Total = orderDao.GetToTal(customer.Id)
                            });
                        }




                        // 1. lay danh sach user moi nhat (10 user/ page)
                        // 2. Chay vong lap qua tung 10 users nay
                        // 3. Get tong so don hang, tong tien, don hang moi nhat cho tung user           
                        // var model = dao.ListAllPaging(SearchString, page, pagesize);*/
            //var model = dao.ListAllPaging(SearchString, page, pagesize);
            ViewBag.SearchString1 = SearchString;
            return View(model.OrderBy(x => x.Name).ToPagedList(page, pagesize));
        }

        // GET: Admin/User1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/User1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/User1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
     public ActionResult Create([Bind(Include = "Id,Name,Email,Address,Phonenumber,PasswordHash,CreatedOn,ModifiedOn")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                long Id = dao.Insert(customer);
                if (Id > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm sản phẩm thất bại");
                }
            }

            return View(customer);
        }

        // GET: Admin/User1/Edit/5
        public ActionResult Edit(int  id)
        {
            return View();
        }
        public ActionResult EditName(int id)
        {
            return View(dao.ListOrder(id));
        }
        // POST: Admin/User1/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/User1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/User1/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
