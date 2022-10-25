using AutoMapper;
using DAL;
using DAL.Models;
using DTO;
using System;
using System.Collections.Generic;

namespace BL
{
    public class PatientBL : IPatientBL
    {
        IPatientDAL _patientDal;
        IMapper mapper;
        public PatientBL(IPatientDAL patientDAL)
        {
            _patientDal = patientDAL;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();

            });
            mapper = config.CreateMapper();
        }
        public List<PatientDTO> GetAllPatients()
        {
            List<Patient> listPatients = _patientDal.GetAllPatients();

            return mapper.Map<List<PatientDTO>>(listPatients);
        }
        public bool UpdatePatient(string id, PatientDTO patientDTO)
        {

            Patient patient = mapper.Map<Patient>(patientDTO);
            return _patientDal.UpdatePatient(id, patient);
        }
        public bool DeletePatient(string id)
        {
            // פונקצית מחיקה
            try
            {

                return _patientDal.DeletePatient(id);
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public bool AddPatient(PatientDTO patientDTO)
        {
            //פונקצית הוספה
            try
            {
                Patient patient = mapper.Map<Patient>(patientDTO);
                return _patientDal.Addpatient(patient);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public ListDetailsDTO GetPatientByIdFullInfo(string id)
        {
            return mapper.Map < ListDetailsDTO > (_patientDal.GetPatientByIdFullInfo(id));

        }
        public bool DeletePatientAllInfo(string id)
        {
            try
            {

                return _patientDal.DeletePatientAllInfo(id);
            }
            catch (Exception ex)
            {
                return false;
            }

        }
       public PatientDetailsOfUpdateDTO getPatientOfUpDate(string id)
        {
            Patient PatientOfUpDate = _patientDal.getPatientOfUpDate(id);
           
            return mapper.Map<PatientDetailsOfUpdateDTO>(PatientOfUpDate);
        }
       public bool UpdatePatienFullInfo(string id, PatientDetailsOfUpdateDTO patientDetailsOfUpdateDTO)
        {
            Patient patient = mapper.Map<Patient>(patientDetailsOfUpdateDTO);
            return _patientDal.UpdatePatienFullInfo(id, patient);
           

        }
        public bool AddPatientAllInfo(PatientDetailsOfUpdateDTO patientDetailsOfUpdateDTO)
        {
            //פונקצית הוספה
            try
            {
                Patient patient = mapper.Map<Patient>(patientDetailsOfUpdateDTO);
                return _patientDal.AddPatientAllInfo(patient);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
