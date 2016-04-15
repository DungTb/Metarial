using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using Model.Dao;

namespace DemoASP.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        private DemoASpDbContext1 db = new DemoASpDbContext1();

        // GET: Admin/Order
        public ActionResult Index(string SearchString, int page = 1, int pagesize = 10)
        {
            var dao = new OderDao();
            var model = dao.ListAllPaging(SearchString, page, pagesize);
            ViewBag.SearchString1 = SearchString;
            return View(model);
        }

        // GET: Admin/Order/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = new OderDao().GetbyId(id);   
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Admin/Order/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Customers, "Id", "Name");
            return View();
        }

        // POST: Admin/Order/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserId,Code,CustomerName,CustomerAddress,CustomerPhoneNumber,CreatedOn,ModifiedOn,ShippingStatus,PaymetStatus,TotalPrice")] Order order)
        {
            if (ModelState.IsValid)
            {
                long Id = new OderDao().Isert(order);
               
                if (Id > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm đơn hàng thất bại");
                }
            }

            ViewBag.UserId = new SelectList(db.Customers, "Id", "Name", order.UserId);
            return View(order);
        }

        // GET: Admin/Order/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = new OderDao().GetbyId(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Customers, "Id", "Name", order.UserId);
            return View(order);
        }

        // POST: Admin/Order/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserId,Code,CustomerName,CustomerAddress,CustomerPhoneNumber,CreatedOn,ModifiedOn,ShippingStatus,PaymetStatus,TotalPrice")] Order order)
        {
            if (ModelState.IsValid)
            {
                long id = new OderDao().Edit(order);
               
                if (id > 0)
                {
                    return RedirectToAction("Index");
                }
                else { ModelState.AddModelError("", "Sửa Hóa đơn thất bại"); }
            }
            ViewBag.UserId = new SelectList(db.Customers, "Id", "Name", order.UserId);
            return View(order);
        }

        // GET: Admin/Order/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Admin/Order/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            new OderDao().Delete(id);
            
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
