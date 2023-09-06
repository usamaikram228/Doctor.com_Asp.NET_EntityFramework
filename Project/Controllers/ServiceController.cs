using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Models;
using Project.RepositryPattern;

namespace Project.Controllers
{
    public class ServiceController : Controller
    {
        public IActionResult Service()
        {
            return View();
        }
        //public IActionResult Medicine()
        //{
        //    return View();
        //}
        public IActionResult Doctor()
        {
            List<Doctor> data= new List<Doctor>();
            data = DoctorRepository.GetDoctors();
            var loggedInUser = HttpContext.Session.GetString("LoggedInUserName");
            Console.WriteLine(loggedInUser);
            return View(data);
        }
        public IActionResult FeedBack(int id)
        {
            List<FeedBack> data = FeedBackRepository.getfeedBackbyid(id);
            int count = 0;
            foreach (FeedBack feedback in data)
            {
                if (feedback.Doctor == null && count == 0)
                {
                    count++;
                    feedback.Doctor = new Doctor();
                    feedback.Doctor = DoctorRepository.GetDoctorbyId(feedback.DoctorId);
                   
                }
                if(feedback.Patient == null)
                {
                    feedback.Patient = new Patient();
                    feedback.Patient = PatientRepository.getPatientbyId(feedback.PatientId);
                   
                }
            }
            //var loggedInUser = HttpContext.Session.GetString("LoggedInUserName");
            //Console.WriteLine(loggedInUser);
            //ViewBag.SessionValue = loggedInUser;
            string a = HttpContext.Request.Cookies["loggedInUserName"];
            string b = HttpContext.Request.Cookies["loggedInUserId"];

            return View(data);
        }
        [HttpPost]
        public IActionResult SubmitFeedback(int doctorId,int patientId, int rating, string comments, DateTime timestamp)
        {
            // Save the feedback to the database
            // Implement your database logic here
            FeedBack f = new FeedBack();
            f.DoctorId = doctorId; f.PatientId = patientId;
            f.Rating = rating; f.Comments = comments;
            f.TimeStamp = timestamp;
            FeedBackRepository.insertFeedback(f);
            // Return a response (e.g., a success message or redirect to a confirmation page)
            return Ok();
        }

        public IActionResult Hospital()
        {
            return View();
        }
        public IActionResult Blogs()
        {
            return View();
        }
        public IActionResult Labs()
        {
            return View();
        }
    }
    
}
