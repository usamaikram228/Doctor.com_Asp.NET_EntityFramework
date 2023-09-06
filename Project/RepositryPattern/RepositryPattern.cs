using Project.Models;

namespace Project.RepositryPattern
{
    static public class RepositryClass
    {
       static public List<Medicine> getMedicines()
        {
            DbDoctorContext cx = new DbDoctorContext();
            List<Medicine> list = new List<Medicine>();
            list = cx.Medicines.ToList();
            return list;
        }
        static public void quantityDecreament(int id)
        {
            DbDoctorContext cx = new DbDoctorContext();
            Medicine m = cx.Medicines.Find(id);
            int intValue = int.Parse(m.Quantity);
            intValue -= 1;
            m.Quantity = intValue.ToString();
            cx.SaveChanges();
        }
    }
}
