using DTO;
using System.Collections.Generic;

namespace BL
{
    public interface IPatientBL
    {
        bool AddPatient(PatientDTO patientDTO);
        bool DeletePatient(string id);
        List<PatientDTO> GetAllPatients();
        bool UpdatePatient(string id, PatientDTO patientDTO);
       ListDetailsDTO GetPatientByIdFullInfo(string id);
        bool DeletePatientAllInfo(string id);
        PatientDetailsOfUpdateDTO getPatientOfUpDate(string id);
        //public bool UpdatePatienFullInfo(string id, ListDetailsOfUpdateDTO listDetailsOfUpdateDTO);
        bool UpdatePatienFullInfo(string id, PatientDetailsOfUpdateDTO patientDetailsOfUpdateDTO);

        bool AddPatientAllInfo(PatientDetailsOfUpdateDTO patientDetailsOfUpdateDTO);
    }
}