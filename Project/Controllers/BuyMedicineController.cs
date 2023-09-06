using Microsoft.AspNetCore.Mvc;
using Project.Models;
using Project.RepositryPattern;

namespace Project.Controllers
{
    public class BuyMedicineController : Controller
    {
        List<Medicine> listmed = RepositryClass.getMedicines();
        public IActionResult Medicine()
        {
            List<Medicine> list = new List<Medicine>();
            list = RepositryClass.getMedicines();

            return View(list);
        }

       
        [HttpPost]
        public IActionResult addToCart(int itemId)
        {
           
            //Cookies
            if (HttpContext.Request.Cookies.ContainsKey("c"))
            {
                string a = HttpContext.Request.Cookies["c"];
               
                a = a+ "," + Convert.ToString(itemId);


                HttpContext.Response.Cookies.Append("c", a);
               
            }
            else
            {
               
                CookieOptions option = new CookieOptions();
                option.Expires = DateTime.Now.AddMinutes(1);
                HttpContext.Response.Cookies.Append("c", Convert.ToString(itemId), option);
               
            }

            return View("~/Views/BuyMedicine/Medicine.cshtml", listmed);
        }
        public IActionResult CheckoutList()
        {
            Cart buymedicineList = new Cart();
            buymedicineList.bill = 1;
            string a = HttpContext.Request.Cookies["c"];
            string[] arr = a.Split(",");

            DbDoctorContext cx = new DbDoctorContext();
            Medicine m = new Medicine();
            foreach (string str in arr)
            {
                m = cx.Medicines.Find(int.Parse(str));
                buymedicineList.list.Add(m);
                buymedicineList.bill = (int)(buymedicineList.bill+ m.Price);
            }

            return View(buymedicineList);
        }
        public IActionResult orderPlaced()
        {
            string a = HttpContext.Request.Cookies["c"];
            string[] arr = a.Split(",");
            foreach (string str in arr)
            {
                RepositryClass.quantityDecreament(int.Parse(str));
            }
            Response.Cookies.Delete("c");
            return View("~/Views/Home/Index.cshtml");
        }
    }            
}
