using DAL.Models;
using System.Collections.Generic;

namespace DAL
{
    public interface IPatientDAL
    {
        bool Addpatient(Patient patient);
        bool DeletePatient(string id);
        List<Patient> GetAllPatients();
        bool UpdatePatient(string id, Patient patient);
         Patient GetPatientByIdFullInfo(string id);
         bool DeletePatientAllInfo(string id);
         Patient getPatientOfUpDate(string id);
        bool UpdatePatienFullInfo(string id, Patient patient);
        public bool AddPatientAllInfo(Patient patient);
    }
}