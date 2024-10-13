using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
//using AppMgr.DataAccess.Models.RBACModels;

namespace materTestCore2.Models.EGovModels
{
    public class UserModel
    {
        public UserModel()
        {

        }
    }
    public class UserViewModel : UserModel
    {
        public UserViewModel()
        {
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "لا يمكن أن يكون اسم المستخدم فارغاً.")]
        [Display(Name = "اسم المستخدم")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "لا يمكن أن تكون كلمة المرور فارغة.")]
        [Display(Name = "كلمة المرور")]
        [StringLength(100, ErrorMessage = "طول " + "{0} " + " يجب أن يكون " + " {2} " + " محارف على الأقل.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "تأكيد كلمة المرور")]
        [Compare("Password", ErrorMessage = "كلمة المرور وتأكيد كلمة المرور غير متطابقتين.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "لا يمكن أن يكون الاسم الأول فارغاً.")]
        [Display(Name = "الاسم الأول")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "لا يمكن أن تكون الكنية فارغة.")]
        [Display(Name = "الكنية")]
        public string LastName { get; set; }

        [Display(Name = "الحساب فعّال؟")]
        public bool IsActive { get; set; }

    }


    public class LoginViewModel
    {
        [Required(ErrorMessage = "اسم المستخدم إجباري")]
        [Display(Name = "اسم المستخدم")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "كلمة المرور مطلوبة")]
        [DataType(DataType.Password)]
        [Display(Name = "كلمة المرور")]
        public string Password { get; set; }

        [Display(Name = "تذكرني؟")]
        public bool RememberMe { get; set; }
    }

    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "يجب تحديد المستخدم.")]
        public int UserId { get; set; }


        [Display(Name = "الاسم الكامل")]
        public string Name { get; set; }


        [Display(Name = "اسم المستخدم")]
        public string Username { get; set; }


        [Required(ErrorMessage = "يجب إدخال كلمة المرور القديمة.")]
        [Display(Name = "كلمة المرور القديمة")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }


        [Required(ErrorMessage = "لا يمكن أن تكون كلمة المرور الجديدة فارغة.")]
        [Display(Name = "كلمة المرور الجديدة")]
        [StringLength(100, ErrorMessage = "طول " + "{0} " + " يجب أن يكون " + " {2} " + " محارف على الأقل.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [DataType(DataType.Password)]
        [Display(Name = "تأكيد كلمة المرور الجديدة")]
        [Compare("Password", ErrorMessage = "كلمة المرور الجديدة وتأكيد كلمة المرور الجديدة غير متطابقتين.")]
        public string ConfirmPassword { get; set; }
    }
}
