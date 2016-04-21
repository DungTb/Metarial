using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DemoASP.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        public DemoASpDbContext1 db = new DemoASpDbContext1();
        // GET: Admin/Product
        public ActionResult Index(string SearchString, int page = 1, int pagesize = 10)
        {
            var dao = new ProductDao();
            var model = dao.GetAllPaging(SearchString, page, pagesize);
            ViewBag.SearchString1 = SearchString;
            return View(model);
        }
        public void SetViewBag( long ? selectedId = null)
        {
            var dao = new ProductDao();
            ViewBag.ProductSpecies = new SelectList(dao.GetAll(), "Name", "ProductSpecies", selectedId);
        }
        // GET: Admin/Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Product/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
            ViewBag.ManufacturerId = new SelectList(db.Manufacturers, "Id", "Name");
            return View();
        }

        // POST: Admin/Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "Id,Code,CategoryId,ManufacturerId,BarCode,Name,ProductSpecies,Size,Unit,Image,Price,SalePrice,StockStatus,AvailableStatus,Alias,CreatedOn,Description,Content1,ModifiedOn")] Product product)
        {
            if (ModelState.IsValid)
            {
                long Id = new ProductDao().Insert(product);
                // db.Products.Add(product);
                // db.SaveChanges();
                if (Id > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm sản phẩm thất bại");
                }
                
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", product.CategoryId);
            ViewBag.ManufacturerId = new SelectList(db.Manufacturers, "Id", "Name", product.ManufacturerId);
            return View(product);
        }

        // GET: Admin/Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = new ProductDao().GetbyId(id);
          // Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name",product.CategoryId);
            ViewBag.ManufacturerId = new SelectList(db.Manufacturers, "Id", "Name", product.ManufacturerId);
            return View(product);
        }

        // POST: Admin/Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "Id,Code,CategoryId,ManufacturerId,BarCode,Name,ProductSpecies,Size,Unit,Image,Price,SalePrice,StockStatus,AvailableStatus,Alias,CreatedOn,Description,Content1,ModifiedOn")] Product product)
        {
            if (ModelState.IsValid)
            {
                long id = new ProductDao().Edit(product);
                //db.Entry(product).State = EntityState.Modified;
                //db.SaveChanges();
                if (id > 0) {
                    return RedirectToAction("Index");
                }
                else { ModelState.AddModelError("", "Sửa sản phẩm thất bại"); }
                
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", product.CategoryId);
            ViewBag.ManufacturerId = new SelectList(db.Manufacturers, "Id", "Name", product.ManufacturerId);
            return View(product);
        }

        // GET: Admin/Product/Delete/5
        public ActionResult Delete(int ? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = new ProductDao().GetbyId(id);
           // Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Admin/Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            new ProductDao().Delete(id);
            //Product product = db.Products.Find(id);
           // db.Products.Remove(product);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
