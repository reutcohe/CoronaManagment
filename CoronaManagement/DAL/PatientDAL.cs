using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class PatientDAL : IPatientDAL
    {
        ManagementHMOContext managementHMOContext = new ManagementHMOContext();

        public List<Patient> GetAllPatients()
        {
            //select * from Users; 
            try
            {
                var patients = managementHMOContext.Patients.ToList();
                return patients;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Patient> GetAllPatientsFullInfo()
        {
            //select * from Users; 
            try
            {
                var patients = managementHMOContext.Patients.Include(x => x.CoronaVaccines)
                                .Include(x => x.ListOpatients)
                                .AsSplitQuery()
                            .ToList();
                return patients;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Patient GetPatientByIdFullInfo(string id)
        {
            //select * from Users; 
            try
            {
                //return managementHMOContext.Patients.Where(x=>x.PatientId==id).
                //    Include(x => x.CoronaVaccines).
                //    Where(x=>x.PatientId==id)
                //                .Include(x => x.ListOpatients).
                //                Where(x=>x.PatientId==id)
                //                .AsSplitQuery()
                //            .First();
                return managementHMOContext.Patients.Include(x => x.ListOpatients).Include(x => x.CoronaVaccines).First(x => x.PatientId == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //public bool UpdatePatientFullInfo(string id, Patient patient)
        //{
        //    try
        //    {// שליפת הרשומה שנדרשת לעדכון
        //        Patient currentPatientToUpdate = managementHMOContext.Patients.SingleOrDefault(x => x.PatientId == id);
        //        managementHMOContext.Entry(currentPatientToUpdate).CurrentValues.SetValues(patient);
        //        // travelAgentContext.Flights.Update(flight);
        //        managementHMOContext.SaveChanges();
        //        return true;


        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }

        //}
        public bool UpdatePatient(string id, Patient patient)
        {
            try
            {// שליפת הרשומה שנדרשת לעדכון
                Patient currentPatientToUpdate = managementHMOContext.Patients.Include(x => x.ListOpatients).Include(x => x.CoronaVaccines).SingleOrDefault(x => x.PatientId == id);
                managementHMOContext.Entry(currentPatientToUpdate).CurrentValues.SetValues(patient);
                // travelAgentContext.Flights.Update(flight);
                managementHMOContext.SaveChanges();
                return true;


            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public bool DeletePatientAllInfo(string id)
        {
            // פונקצית מחיקה
            try
            {
                Patient currentPatient = managementHMOContext.Patients.Include(x => x.ListOpatients).Include(x => x.CoronaVaccines).First(x => x.PatientId == id);
                //managementHMOContext.Patients.SingleOrDefault(x => x.PatientId == id);
                managementHMOContext.Patients.Remove(currentPatient);
                managementHMOContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
       
        public bool DeletePatient(string id)
        {
            // פונקצית מחיקה
            try
            {
                Patient currentPatient = managementHMOContext.Patients.SingleOrDefault(x => x.PatientId == id);
                managementHMOContext.Patients.Remove(currentPatient);
                managementHMOContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public bool Addpatient(Patient patient)
        {
            //פונקצית הוספה
            try
            {
                var p = managementHMOContext.Patients.Include(x => x.ListOpatients)
                    .Include(x => x.CoronaVaccines);
                //managementHMOContext.Patients.Include(x=>x.ListOpatients)
                
                managementHMOContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public Patient getPatientOfUpDate(string id)
        {
           

            return managementHMOContext.Patients.Include(x => x.ListOpatients).Include(x => x.CoronaVaccines).First(x => x.PatientId == id);

            

            
        }
        //public bool UpDatePatientFullInfo(Patient patient,string id)
        //{


        
        public bool UpdatePatienFullInfo(string id, Patient patient)
        {
            try
            {// שליפת הרשומה שנדרשת לעדכון
                Patient currentPatientToUpdate = managementHMOContext.Patients.Include(x => x.ListOpatients).Include(x => x.CoronaVaccines).SingleOrDefault(x => x.PatientId == id);
                managementHMOContext.Entry(currentPatientToUpdate).CurrentValues.SetValues(patient);
                // travelAgentContext.Flights.Update(flight);
                managementHMOContext.SaveChanges();
                return true;


            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool AddPatientAllInfo(Patient patient)
        {
            //פונקצית הוספה
            try
            {
                managementHMOContext.Patients.Add(patient);
                managementHMOContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}


