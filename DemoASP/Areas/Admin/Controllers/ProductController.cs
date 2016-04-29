using Model.Dao;
using Model.EF;
using Model.ModelView;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace DemoASP.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        public static string fileimage;
        public static List<string> ListImg = new List<string>();

        Dictionary<string, bool> uploadResult = new Dictionary<string, bool>();
        ProductImage productimage = new ProductImage();
        ProductImageDao dao1 = new ProductImageDao();
        ProductDao dao = new ProductDao();
        public static string fileimg1;
        public static string fileimg2;
        public DemoASpDbContext1 db = new DemoASpDbContext1();
        // GET: Admin/Product
        public ActionResult Index(string SearchString, int page = 1, int pagesize = 10)
        {

            var dao = new ProductDao();
            var model = dao.GetAllPaging(SearchString, page, pagesize);
            ViewBag.SearchString1 = SearchString;
            return View(model);
        }

        // GET: Admin/Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Product/Create
        public ActionResult Create()
        {
            ProductModel productModel = new ProductModel();
            productModel.ListCategories = dao.ListCategory();
            productModel.ListManufacturers = dao.ListMaufacturer();
            productModel.ListAllImg = ListImg;
            /*  ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
              ViewBag.ManufacturerId = new SelectList(db.Manufacturers, "Id", "Name");*/
            return View(productModel);
        }

        // POST: Admin/Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "Id,Code,CategoryId,ManufacturerId,BarCode,Name,ProductSpecies,Size,Unit,Image,Price,SalePrice,StockStatus,AvailableStatus,Alias,CreatedOn,Description,Content1,ModifiedOn")] ProductModel product)
        {
            if (ModelState.IsValid)
            {

                dao.Create(product, fileimage, ListImg);
                return RedirectToAction("Index");
            }
            /*     
                 Product createProduct = new Product();
                 createProduct.Id = product.Id;
                 createProduct.Name = product.Name;
                 createProduct.Code = product.Code;
                 createProduct.Description = product.Description;
                 createProduct.Alias = product.Alias;
                 createProduct.Image = "/Upload/ProductImg/" + fileimage;
                 /* "/UploadedImages/" + images[0].FileName;
                 createProduct.CreatedOn = DateTime.Now;
                 createProduct.Price = product.Price;
                 createProduct.SalePrice = product.SalePrice;
                 createProduct.ManufacturerId = product.ManufacturerId;
                 createProduct.CategoryId = product.CategoryId;

                 createProduct.BarCode = product.BarCode;
                 createProduct.Size = product.Size;
                 createProduct.Unit = product.Unit;
                 createProduct.StockStatus = product.StockStatus;
                 createProduct.AvailableStatus = product.AvailableStatus;
                 createProduct.ProductSpecies = product.ProductSpecies;                         
                 long Id = new ProductDao().Insert(product);
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
             return View(product);*/
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
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", product.CategoryId);
            ViewBag.ManufacturerId = new SelectList(db.Manufacturers, "Id", "Name", product.ManufacturerId);
            return View(product);
        }

        // POST: Admin/Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "Id,Code,CategoryId,ManufacturerId,BarCode,Name,ProductSpCode,CategoryId,ManufacturerId,BarCode,Name,Producecies,Size,Unit,Image,Price,SalePrice,StockStatus,AvailableStatus,Alias,CreatedOn,Description,Content1,ModifiedOn")] Product product)
        {
            if (ModelState.IsValid)
            {
                long id = new ProductDao().Edit(product, fileimg1);

                if (id > 0) {
                    return RedirectToAction("Index");
                }
                else { ModelState.AddModelError("", "Sửa sản phẩm thất bại"); }

            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", product.CategoryId);
            ViewBag.ManufacturerId = new SelectList(db.Manufacturers, "Id", "Name", product.ManufacturerId);
            return View(product);
        }

        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult SaveEdit(int id) {
            if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
            {
                var pic = System.Web.HttpContext.Current.Request.Files["HelpSectionImages"];
            }
            Product product = dao.GetbyId(id);
            if (TryUpdateModel(product, "", new string[] { "Name", "Image", "Code", "Barcode", "Description", "CategorieId", "ManufacturerId", "Price", "SalePrice", "Alias", "AvailableStatus", "Available", "Content1", "Unit", "Size" }))
            {
                if (fileimg1 != product.Image)
                {
                    product.Image = fileimg1;
                }
                //Cập nhật thông tin 
                dao.Insert(product);
                //db.Entry(category).State = System.Data.Entity.EntityState.Modified;


                //db.SaveChanges();
            }
            return RedirectToAction("Index");

        }
        // GET: Admin/Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = new ProductDao().GetbyId(id);

            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
        [HttpPost]
        public ActionResult UploadFiles()
        {
            ListImg = new List<string>();


            if (Request.Files.Count > 0)
            {
                try
                {

                    HttpFileCollectionBase files = Request.Files;
                    for (int i = 0; i < files.Count; i++)
                    {


                        HttpPostedFileBase file = files[i];
                        string filename;


                        if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                        {
                            string[] testfiles = file.FileName.Split(new char[] { '\\' });
                            filename = testfiles[testfiles.Length - 1];
                        }
                        else
                        {
                            filename = file.FileName;

                            fileimage = filename;


                            ListImg.Add(filename);
                        }


                        filename = Path.Combine(Server.MapPath("/Upload/ProductImg/"), filename);
                        file.SaveAs(filename);

                        MemoryStream ms = new MemoryStream();
                        WebImage img = new WebImage(filename);

                        if (img.Width > 200)
                            img.Resize(200, 200);
                        img.Save(filename);
                    }

                    return Json(ListImg);

                }
                catch (Exception ex)
                {
                    return Json("Error occurred. Error details: " + ex.Message);
                }
            }
            else
            {
                return Json("No files selected.");
            }
        }
        [HttpPost]
        [JsonFilter(Param = "widgets", JsonDataType = typeof(List<UploadFileModel>))]
        public JsonResult UploadToServer(List<UploadFileModel> images)
        {
            var uploadResult = new Dictionary<string, bool>();
            if (images != null && images.Count > 0)
            {

                foreach (var imageData in images)
                {
                    try
                    {
                        var base64String = imageData.Content.Substring(imageData.Content.IndexOf(',') + 1);
                        var buffer = Convert.FromBase64String(base64String);
                        Image image;
                        using (Stream sr = new MemoryStream(buffer))
                        {
                            image = Image.FromStream(sr);
                        }

                        image = ResizeImage(image, (int)imageData.ImgWidth, (int)imageData.ImgHeight);
                        image = CropImage(image, new Rectangle((int)imageData.CropX, (int)imageData.CropY, imageData.CropWidth, imageData.CropHeight));
                        if (!Directory.Exists(Server.MapPath("/UploadedImages/")))
                            Directory.CreateDirectory(Server.MapPath("/UploadedImages/"));
                        image.Save(Server.MapPath("/UploadedImages/" + imageData.FileName));

                        uploadResult.Add(imageData.FileName, true);


                    }
                    catch
                    {
                        uploadResult.Add(imageData.FileName, false);
                    }
                }
            }
            return Json(uploadResult);
        }
        private static Image CropImage(Image img, Rectangle cropArea)
        {
            var bmpImage = new Bitmap(img);
            return bmpImage.Clone(cropArea, bmpImage.PixelFormat);
        }
        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }
        public class JsonFilter : ActionFilterAttribute
        {
            public string Param { get; set; }
            public Type JsonDataType { get; set; }

            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                if (filterContext.HttpContext.Request.ContentType.Contains("application/json"))
                {
                    string inputContent;
                    filterContext.HttpContext.Request.InputStream.Position = 0;
                    using (var sr = new StreamReader(filterContext.HttpContext.Request.InputStream))
                    {
                        inputContent = sr.ReadToEnd();
                    }
                    var result = JsonConvert.DeserializeObject(inputContent, JsonDataType);
                    filterContext.ActionParameters[Param] = result;
                }
            }
        }

        // POST: Admin/Product/Delete/5
      // [HttpPost, ActionName("Delete")]
      [ValidateAntiForgeryToken]
      [HttpDelete]
        public ActionResult DeleteConfirmed(int id)
        {
            new ProductDao().Delete(id);
            //Product product = db.Products.Find(id);
            // db.Products.Remove(product);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }
  /*      [HttpDelete]
        public ActionResult Delete(int id)
        {
            new ProductDao().DeleteData(id);
            //Product product = db.Products.Find(id);
            // db.Products.Remove(product);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }
        */
    }
}
