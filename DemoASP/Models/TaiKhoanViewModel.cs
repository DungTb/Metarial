using Model.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace DemoASP.Areas.Admin.Models
{
    public class DangNhapModel
    {
        [Required(ErrorMessage = "Moi nhap user name")]
        public string UserName { set; get; }
        [Required(ErrorMessage = "Moi nhap password")]
        [DataType(DataType.Password)]
        public string Password { set; get; }
        public bool RememberMe { set; get; }
    }
    public class DangKyModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "UserLogin")]
        public string UserLogin { get; set; }



        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "ConfirmPassword")]
        [Compare("Password", ErrorMessage = "Mật khẩu không trùng khớp")]
        public string ConfirmPassword { get; set; }
    }
    public class PhanQuyenprovider : RoleProvider
    {
        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string adminlogin)
        {
            using (DemoASpDbContext1 db = new DemoASpDbContext1())
            {
                var account = db.Customers.FirstOrDefault(x => x.Name == adminlogin);
                if (account == null)
                {
                    return null;
                }
                else
                {
                    string[] listQuyen = account.Roles.Select(x => x.RoleName).ToArray();
                    return listQuyen;
                }
            }
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}