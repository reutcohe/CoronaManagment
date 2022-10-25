using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ListOpatientDAL : IListOpatientDAL
    {
        ManagementHMOContext managementHMOContext = new ManagementHMOContext();

        public List<ListOpatient> GetAllListsOpatients()
        {
            //select * from Users; 
            try
            {
                var listOpatient = managementHMOContext.ListOpatients.ToList();
                return listOpatient;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool UpdateListOpatients(int id, ListOpatient ListOpatient)
        {
            try
            {// שליפת הרשומה שנדרשת לעדכון
                ListOpatient currentListOpatientToUpdate = managementHMOContext.ListOpatients.SingleOrDefault(x => x.LineCode == id);
                managementHMOContext.Entry(currentListOpatientToUpdate).CurrentValues.SetValues(ListOpatient);
                // travelAgentContext.Flights.Update(flight);
                managementHMOContext.SaveChanges();
                return true;


            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public bool DeletePatientFromList(string id)
        {
            // פונקצית מחיקה
            try
            {
                ListOpatient currentVcurrentListOpatient = managementHMOContext.ListOpatients.SingleOrDefault(x => x.PatientId == id);
                managementHMOContext.ListOpatients.Remove(currentVcurrentListOpatient);
                managementHMOContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public bool AddPatientToList(ListOpatient patient)
        {
            //פונקצית הוספה
            try
            {

                managementHMOContext.ListOpatients.Add(patient);
                managementHMOContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
      public DateTime? GetDatePositive(string id)
      {
           var p = managementHMOContext.ListOpatients.SingleOrDefault(x => x.PatientId.Equals(id));
           return p.DatePositive;
      }


    }
}

