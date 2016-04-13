using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoASP.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        public DemoASpDbContext1 db = new DemoASpDbContext1();
        // GET: Admin/Product
        public ActionResult Index(string SearchString, int page = 1, int pagesize = 10)
        {
            var dao = new ProductDao();
            var model = dao.ListAllPaging(SearchString, page, pagesize);
            ViewBag.SearchString1 = SearchString;
            return View(model);
        }
        public void SetViewBag()
        {
            ViewBag.Pro
        }
        // GET: Admin/Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Code,CategoryId,ManufacturerId,BarCode,Name,ProductSpecies,Size,Unit,Image,Price,SalePrice,StockStatus,AvailableStatus,Alias,CreatedOn,Description,Content1,ModifiedOn")] Product product)
        {
            if (ModelState.IsValid)
            {
                Product saveproduct = new Product();
                saveproduct.Id = product.Id;
                saveproduct.Code = product.Code;
                saveproduct.CategoryId = product.CategoryId;
                saveproduct.ManufacturerId = product.ManufacturerId;
                saveproduct.Name = product.Name;
                saveproduct.BarCode = product.BarCode;
                saveproduct.ProductSpecies = product.ProductSpecies;
                saveproduct.SalePrice = product.SalePrice;
                saveproduct.Size = product.Size;
                saveproduct.Price = product.Price;
                saveproduct.CreatedOn = product.CreatedOn;
                saveproduct.Unit = product.Unit;
                saveproduct.Content1 = product.Content1;
                saveproduct.Description = product.Description;                
                saveproduct.Image = product.Image;
                saveproduct.SalePrice = product.SalePrice;
                saveproduct.AvailableStatus = product.AvailableStatus;
                saveproduct.Alias = product.Alias;
                saveproduct.StockStatus = product.StockStatus;
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ManufacturerId = new SelectList(db.Manufacturers, "Id", "Code", product.ManufacturerId);
            return View(product);
        }

        // GET: Admin/Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Product/Edit/5
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

        // GET: Admin/Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Product/Delete/5
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
