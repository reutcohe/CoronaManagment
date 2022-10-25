using DAL.Models;
using System.Collections.Generic;

namespace DAL
{
    public interface IVaccineManufacturerDAL
    {
        bool AddVaccineManufacturer(VaccineManufacturer vaccineManufacturer);
        bool DeleteVaccineManufacturer(string id);
        List<VaccineManufacturer> GetAllVaccineManufacturers();
        bool UpdateVaccineManufacturer(string id, VaccineManufacturer vaccineManufacturer);
    }
}