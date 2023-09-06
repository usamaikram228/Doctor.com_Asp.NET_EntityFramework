using Project.Models;

namespace Project.RepositryPattern
{
    static public class DoctorRepository
    {
        static public List<Doctor> GetDoctors()
        {
            DbDoctorContext cx = new DbDoctorContext();
            List<Doctor> list = new List<Doctor>();
            list = cx.Doctors.ToList();
            return list;
        }
        static public Doctor GetDoctorbyId(int id) {
            DbDoctorContext cx = new DbDoctorContext();
            Doctor doctor = cx.Doctors.FirstOrDefault(d => d.Id == id);
            return doctor;
        }
    }
}
