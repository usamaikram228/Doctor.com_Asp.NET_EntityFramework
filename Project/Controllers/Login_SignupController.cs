using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.Models;

namespace Project.Controllers
{
    public class Login_SignupController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Signup()
        {
            return View();
        }
        public IActionResult Signup_Doctor()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Signup_Successful(Patient s)
        {
           
            DbDoctorContext cx = new DbDoctorContext();
            List<Patient> data = cx.Patients.ToList();
            foreach (Patient pat in data)
            {
                if (pat.Email == s.Email)
                {
                    ;
                    ViewBag.Message = "This email already has account";
                    return View("~/Views/Login_Signup/Signup.cshtml");
                }
            }
            cx.Patients.Add(s);
            cx.SaveChanges();
            return View("~/Views/Home/Index.cshtml");
        }
        [HttpPost]
        public IActionResult Signup_Doctor_Succsessful(Doctor s)
        {
            DbDoctorContext cx = new DbDoctorContext();
            List<Doctor> data = cx.Doctors.ToList();
            foreach(Doctor pat in data)
            {
                if(pat.Email == s.Email)
                {
                    ViewBag.Message = "This email already has account";
                    return View("~/Views/Login_Signup/Signup_doctor.cshtml");
                }
            }
            cx.Doctors.Add(s);
            cx.SaveChanges();
            return View("~/Views/Home/Index.cshtml");
           
        }
        public IActionResult Login_Patient()
        {
            return View();
        }
        public IActionResult Login_Doctor()
        {
            return View();
        }
        private readonly SignInManager<IdentityUser> _signInManager;

        public Login_SignupController(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }
        [HttpPost]
        public async Task<IActionResult> Login_Patient_Successful(Patient s)
        {
            //DbDoctorContext cx = new DbDoctorContext();
            //List<Patient> data = cx.Patients.ToList();
            //foreach(Patient pat in data)
            //{
            //    if(pat.Email == s.Email && pat.Password == s.Password)
            //    {
            //        HttpContext.Session.SetString("LoggedInUser", pat.Email);
            //      //  HttpContext.Session.SetString("LoggedInUserName",pat.Name );
            //        HttpContext.Session.SetString("UserType", "Patient");

            //        var cookieOptions = new CookieOptions
            //        {
            //            Expires = DateTime.Now.AddDays(1),
            //            HttpOnly = false
            //        };
            //        HttpContext.Response.Cookies.Append("loggedInUserName", pat.Name, cookieOptions);
            //        HttpContext.Response.Cookies.Append("loggedInUserId", (pat.Id).ToString(), cookieOptions);
            //        ViewBag.ShowLogoutButton = true;
            //        return View("~/Views/Home/Index.cshtml");
            //    }
            //}
            var result = await _signInManager.PasswordSignInAsync(s.Email, s.Password, isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                // Successfully logged in
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Message = "Password or email is incorrect";
            return View("~/Views/Login_Signup/Login_Patient.cshtml");
        }
        [HttpPost]
        public IActionResult Login_Doctor_Successful(Doctor s)
        {
            DbDoctorContext cx = new DbDoctorContext();
            List<Doctor> data = cx.Doctors.ToList();
            foreach (Doctor pat in data)
            {
                if (pat.Email == s.Email && pat.Password == s.Password)
                {
                    return View("~/Views/Home/Index.cshtml");
                }
            }
            ViewBag.Message = "Password or email is incorrect";
            return View("~/Views/Login_Signup/Login_Doctor.cshtml");
        }
        public IActionResult logout_Patient()
        {
            HttpContext.Session.Clear(); // Clear all session data
            return View("~/Views/Login_Signup/Login_Patient.cshtml");
        }
        public IActionResult GetSessionValue()
        {
            var sessionValue = HttpContext.Session.GetString("LoggedInUserName");
            return Json(sessionValue);
        }

    }
}
