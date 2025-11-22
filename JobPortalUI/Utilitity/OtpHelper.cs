using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace JobPortalUI.Utilitity
{
    public class OtpHelper
    {
        public static string SendOtpToMobile(string mobileNumber)
        {
            string otp = GenerateOtp();   // call generate otp method
            string apiKey = "YOUR_MSG91_API_KEY";
            string senderId = "YOUR_SENDER_ID";   // e.g., MSGIND
            string route = "4";

            string url = "https://api.msg91.com/api/sendhttp.php?" +
                         "mobiles=" + mobileNumber +
                         "&authkey=" + apiKey +
                         "&route=" + route +
                         "&sender=" + senderId +
                         "&message=Your+OTP+is+" + otp;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            return otp;     // return OTP so you can store it in session
        }
        public static string GenerateOtp()
        {
            Random rnd = new Random();
            return rnd.Next(100000, 999999).ToString();
        }

    }

}