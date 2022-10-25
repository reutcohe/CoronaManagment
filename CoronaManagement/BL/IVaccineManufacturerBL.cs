using DTO;
using System.Collections.Generic;

namespace BL
{
    public interface IVaccineManufacturerBL
    {
        bool AddVaccineManufacturer(VaccineManufacturerDTO vaccineManufacturerDTO);
        bool DeleteVaccineManufacturer(string id);
        List<VaccineManufacturerDTO> GetAllVaccineManufacturers();
        bool UpdateVaccineManufacturer(string id, VaccineManufacturerDTO vaccineManufacturerDTO);
    }
}