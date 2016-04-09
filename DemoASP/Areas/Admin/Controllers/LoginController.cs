using DemoASP.Areas.Admin.Models;
using DemoASP.Areas.Comon;
using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DemoASP.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(DangNhapModel model) {
            if (ModelState.IsValid)
            {
                var dao = new AdminDao();
                var result = dao.Login(model.UserName, model.Password);
                if (result == 1)
                {
                    var user = dao.GetById(model.UserName);
                    var userSession = new AdminLogin();
                    userSession.UserName = user.Name;
                    userSession.UserID = user.Id;
                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    return RedirectToAction("Index", "Home");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Tai Khoan Khong ton tai");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "Mat Khau Khong Dung");
                }
                else
                {
                    ModelState.AddModelError("", "Dang nhap that bai");
                }
            }
            return View("Login");
        }
        public ActionResult LogOut()
        {
            //Đăng xuất khỏi ứng dụng
            FormsAuthentication.SignOut();
            //Về trang chủ
            return Redirect("/");
        }
    }
}