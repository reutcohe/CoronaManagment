using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CoronaVaccineDAL : ICoronaVaccineDAL
    {



        ManagementHMOContext managementHMOContext = new ManagementHMOContext();

        public List<CoronaVaccine> GetAllCoronaVaccines()
        {
            //select * from Users; 
            try
            {
                var CoronaVaccines = managementHMOContext.CoronaVaccines.ToList();
                return CoronaVaccines;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool UpdateCoronaVaccine(int id, CoronaVaccine coronaVaccines)
        {
            try
            {// שליפת הרשומה שנדרשת לעדכון
                CoronaVaccine currentCoronaVaccinesToUpdate = managementHMOContext.CoronaVaccines.SingleOrDefault(x => x.LineCode == id);
                managementHMOContext.Entry(currentCoronaVaccinesToUpdate).CurrentValues.SetValues(coronaVaccines);
                // travelAgentContext.Flights.Update(flight);
                managementHMOContext.SaveChanges();
                return true;


            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public bool DeletecoronaVaccines(int id)
        {
            // פונקצית מחיקה
            try
            {
                CoronaVaccine currentcoronaVaccine = managementHMOContext.CoronaVaccines.SingleOrDefault(x => x.LineCode == id);
                managementHMOContext.CoronaVaccines.Remove(currentcoronaVaccine);
                managementHMOContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public bool AddcoronaVaccine(CoronaVaccine coronaVaccine)
        {
            //פונקצית הוספה
            try
            {

                managementHMOContext.CoronaVaccines.Add(coronaVaccine);
                managementHMOContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        //יש בעיה בפונקציה אמורה להחזיר רשימה של תאריכים על פי תז
        private List<DateTime?> GetListDates(string id)
        {
            try
            {
                List<DateTime?> l = managementHMOContext.CoronaVaccines.
                    Where(x => x.PatientId.Equals(id)).Select(x => x.DateV).ToList();
               
                return l;
            }
            catch
            {
                return new List<DateTime?>();

            }
           
        }


    }
}

