using JobPortalUI.Utilitity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobPortalUI.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult SendOtp(string mobile)
        {
            string otp = OtpHelper.SendOtpToMobile(mobile);
            // Save OTP in Session
            Session["OTP"] = otp;
            return Json(new { success = true, message = "OTP sent" }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult VerifyOtp(string otp)
        {
            string sessionOtp = Session["OTP"].ToString();
            if (otp == sessionOtp)
            {
                return Json(new { valid = true }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { valid = false }, JsonRequestBehavior.AllowGet);
            }
        }


    }
}