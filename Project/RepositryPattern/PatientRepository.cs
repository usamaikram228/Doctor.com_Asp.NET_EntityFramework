using Project.Models;

namespace Project.RepositryPattern
{
    static  class PatientRepository
    {
        static Patient getPatientbyEmail(string email)
        {
            DbDoctorContext cx = new DbDoctorContext();
            Patient patient = new Patient();
           patient =  cx.Patients.FirstOrDefault(p => p.Email == email);
            return patient;
        }
        static public Patient getPatientbyId(int id)
        {
            DbDoctorContext cx = new DbDoctorContext();
            Patient patient = new Patient();
            patient = cx.Patients.FirstOrDefault(p => p.Id == id);
            return patient;
        }
    }
}
