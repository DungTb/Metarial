using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;
using Model.EF;
using Model.ModelView;

using PagedList;
using System.Net;
using System.IO;
using System.Web.Helpers;
using System.Data.Entity;

namespace DemoASP.Areas.Admin.Controllers
    
{
    
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        CategoryDao c = new CategoryDao();
        public static string fileimg;
        public DemoASpDbContext1 db = new DemoASpDbContext1();
        // GET: Admin/Category
        public ActionResult Index(string SearchString, int page = 1, int pagesize = 10)
        {
            var dao = new CategoryDao();
            var model = dao.ListAllPaging(SearchString, page, pagesize);
            ViewBag.SearchString1 = SearchString;
            return View(model);
        }

        // GET: Admin/Category/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
       
        public ActionResult Create([Bind(Include = "Id,Name,Code,Image,Description,Alias")] Category category)
        {
            if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
            {
                var pic = System.Web.HttpContext.Current.Request.Files["HelpSectionImages"];
            }

            if (ModelState.IsValid)
            {
                Category savecategory = new Category();
                savecategory.Id = category.Id;
                savecategory.Name = category.Name;
                savecategory.Code = category.Code;
                savecategory.Description = category.Description;
                savecategory.Alias = category.Alias;
                savecategory.Image = fileimg;
                savecategory.CreatedOn = DateTime.Now;
                long Id = new CategoryDao().Isert(savecategory);           
                if (Id > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm danh mục thất bại");
                }
                //db.Categories.Add(savecategory);
                //db.SaveChanges();
                //return RedirectToAction("Index");
            }

            return View(category);
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult UploadFile()
        {
            string _imgname = string.Empty;
            if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
            {
                var pic = System.Web.HttpContext.Current.Request.Files["MyImages"];
                if (pic.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(pic.FileName);
                    var _ext = Path.GetExtension(pic.FileName);

                    _imgname = Guid.NewGuid().ToString();
                    var _comPath = Server.MapPath("/Upload/MVC_") + _imgname + _ext;
                    fileimg = "/Upload/MVC_" + _imgname + _ext;
                    _imgname = "MVC_" + _imgname + _ext;

                    ViewBag.Msg = _comPath;
                    var path = _comPath;

                    // Saving Image in Original Mode
                    pic.SaveAs(path);


                    // resizing image
                    MemoryStream ms = new MemoryStream();
                    WebImage img = new WebImage(_comPath);

                    if (img.Width > 200)
                        img.Resize(200, 200);
                    img.Save(_comPath);
                    // end resize
                }
            }
            return Json(Convert.ToString(_imgname), JsonRequestBehavior.AllowGet);

        }
        // GET: Admin/Category/Edit/5
        public ActionResult Edit(int ? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = new CategoryDao().FillId(id);      
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Admin/Category/Edit/5
        [HttpPost]

        public ActionResult Edit([Bind(Include = "Id,Name,Code,Image,Description,Alias,CreateOn,ModifiedOn,Status")] Category category)
        {
            if (ModelState.IsValid)
            {
               /* Category savecategory = new Category();
                savecategory.Id = category.Id;
                savecategory.Name = category.Name;
                savecategory.Code = category.Code;
                savecategory.Description = category.Description;
                savecategory.Alias = category.Alias;
                savecategory.Image = fileimg;

                savecategory.Status = category.Status;
                savecategory.ModifiedOn = category.ModifiedOn;
                long id = new CategoryDao().Edit(savecategory);*/
               
               long id= c.Edit(category, fileimg);
               // db.Entry(product).State = EntityState.Modified;
               // db.SaveChanges();
                if (id > 0)
                {
                    return RedirectToAction("Index");
                }
               else {
                    ModelState.AddModelError("", "Sửa danh mục thất bại");
                }
                //db.Entry(savecategory).State = EntityState.Modified;
                //db.SaveChanges();
                //return RedirectToAction("Index");
            }
            return View(category);
        }
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult SaveEdit(int id)
        {
            if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
            {
                var pic = System.Web.HttpContext.Current.Request.Files["HelpSectionImages"];
            }

            //Kiểm tra hợp lệ dữ liệu phía server
           // var category = db.Categories.Find(id);
          // var category = new CategoryDao().FillId(id);
            Category category = c.FillId(id);
            if (TryUpdateModel(category, "", new string[] { "Name", "Code", "Image", "Description", "Alias", "CreateOn", "ModifiedOn", "Status" }))
            {
                if (fileimg != category.Image)
                {
                    category.Image = fileimg;
                }
                //Cập nhật thông tin 
                c.SaveEditCategory(category);
                //db.Entry(category).State = System.Data.Entity.EntityState.Modified;


                //db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            new CategoryDao().Delete(id);
            
            return RedirectToAction("Index");
        }      
    }
}
