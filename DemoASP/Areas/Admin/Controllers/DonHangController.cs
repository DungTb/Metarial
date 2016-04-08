using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using Model.Dao;
using Model.ViewModel;
namespace DemoASP.Areas.Admin.Controllers
{
    public class DonHangController : Controller
    {
        // GET: Admin/DonHang
        public ActionResult Index()
        {
            var dao = new DonHangDao();
            var model = dao.ListAll();
            
            return View(model);

           
        }

        // GET: Admin/DonHang/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/DonHang/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/DonHang/Create
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

        // GET: Admin/DonHang/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/DonHang/Edit/5
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

        // GET: Admin/DonHang/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/DonHang/Delete/5
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
