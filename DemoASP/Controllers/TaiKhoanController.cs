using DemoASP.Areas.Admin.Models;
using DemoASP.Areas.Comon;
using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DemoASP.Controllers
{
    public class TaiKhoanController : Controller
    {
        DemoASpDbContext1 db = new DemoASpDbContext1();
        // GET: TaiKhoanController
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Dangky()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LuuDangKy([Bind(Include = "Email, UserLogin, Password")]Customer taikhoan)
        {
            //Kiểm tra hợp lệ dữ liệu
            if (ModelState.IsValid)
            {
                //kiểm tra tên đăng nhập, email có bị đã tồn tại hay chưa?
                var checkUserName = db.Customers.Any(s => s.Name == taikhoan.Name);
                var checkEmail = db.Customers.Any(s => s.Email == taikhoan.Email);

                //Các lỗi nếu có trong quá trình đăng ký tài khoản
                if (checkUserName)
                {
                    ModelState.AddModelError("", "Tên đăng nhập đã tồn tại!");
                }
                if (checkEmail)
                {
                    ModelState.AddModelError("", "Email đã có người sử dụng!");
                }
                if (checkUserName == true || checkEmail == true)
                {
                    //trả về view đăng ký và thông báo các lỗi ở trên
                    return View("DangKy");
                }
                else
                {
                    //Lưu thông tin tài khoản vào CSDL
                    db.Customers.Add(taikhoan);
                    db.SaveChanges();
                    //xác thực tài khoản trong ứng dụng
                    FormsAuthentication.SetAuthCookie(taikhoan.Name, false);
                    //trả về trang chủ đăng ký thành công
                    return Redirect("/");

                }
            }
            else
            {
                //Trang báo lỗi nhập liệu không hợp lệ!
                return View("Error");
            }
        }
        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(DangNhapModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new AdminDao();
                var result = dao.Login(model.UserName, model.Password);
                if (result == 1)
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, false);
                    
                    return RedirectToAction("Index", "Home");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Tai Khoan Khong ton tai");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "mat Khau Khong Dung");
                }
                else
                {
                    ModelState.AddModelError("", "Dang nhap that bai");
                }
            }
            return View("Index");
        }


    }
}