using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoASP.Areas.Admin.Controllers
{
    public class OrderDetialController : Controller
    {
        OrderDao dao = new OrderDao();
        // GET: Admin/OrderDetial
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/OrderDetial/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/OrderDetial/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/OrderDetial/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/OrderDetial/Edit/5
        public ActionResult Edit(int id)
        {
            return View(dao.ListOrderDetail(id));
        }

        // POST: Admin/OrderDetial/Edit/5
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

        // GET: Admin/OrderDetial/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/OrderDetial/Delete/5
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
