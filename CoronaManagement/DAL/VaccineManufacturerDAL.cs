using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class VaccineManufacturerDAL : IVaccineManufacturerDAL
    {
        ManagementHMOContext managementHMOContext = new ManagementHMOContext();
        public List<VaccineManufacturer> GetAllVaccineManufacturers()
        {
            //select * from Users; 
            try
            {
                var VaccineManufacturers = managementHMOContext.VaccineManufacturers.ToList();
                return VaccineManufacturers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool UpdateVaccineManufacturer(string id, VaccineManufacturer vaccineManufacturer)
        {
            try
            {// שליפת הרשומה שנדרשת לעדכון
                VaccineManufacturer currentVaccineManufacturerToUpdate = managementHMOContext.VaccineManufacturers.SingleOrDefault(x => x.CompanyId == id);
                managementHMOContext.Entry(currentVaccineManufacturerToUpdate).CurrentValues.SetValues(currentVaccineManufacturerToUpdate);
                // travelAgentContext.Flights.Update(flight);
                managementHMOContext.SaveChanges();
                return true;


            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public bool DeleteVaccineManufacturer(string id)
        {
            // פונקצית מחיקה
            try
            {
                VaccineManufacturer currentVaccineManufacturer = managementHMOContext.VaccineManufacturers.SingleOrDefault(x => x.CompanyId == id);
                managementHMOContext.VaccineManufacturers.Remove(currentVaccineManufacturer);
                managementHMOContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public bool AddVaccineManufacturer(VaccineManufacturer vaccineManufacturer)
        {
            //פונקצית הוספה
            try
            {

                managementHMOContext.VaccineManufacturers.Add(vaccineManufacturer);
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

