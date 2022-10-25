using AutoMapper;
using DAL;
using DAL.Models;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class VaccineManufacturerBL : IVaccineManufacturerBL
    {
        IVaccineManufacturerDAL _vaccineManufacturerDAL;
        IMapper mapper;
        public VaccineManufacturerBL(IVaccineManufacturerDAL vaccineManufacturerDAL)
        {
            _vaccineManufacturerDAL = vaccineManufacturerDAL;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();

            });
            mapper = config.CreateMapper();
        }
        public List<VaccineManufacturerDTO> GetAllVaccineManufacturers()
        {
            List<VaccineManufacturer> allVaccineManufacturers = _vaccineManufacturerDAL.GetAllVaccineManufacturers();

            return mapper.Map<List<VaccineManufacturerDTO>>(allVaccineManufacturers);
        }
        public bool UpdateVaccineManufacturer(string id, VaccineManufacturerDTO vaccineManufacturerDTO)
        {

            VaccineManufacturer vaccineManufacturer = mapper.Map<VaccineManufacturer>(vaccineManufacturerDTO);
            return _vaccineManufacturerDAL.UpdateVaccineManufacturer(id, vaccineManufacturer);
        }
        public bool DeleteVaccineManufacturer(string id)
        {
            // פונקצית מחיקה
            try
            {

                return _vaccineManufacturerDAL.DeleteVaccineManufacturer(id);
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public bool AddVaccineManufacturer(VaccineManufacturerDTO vaccineManufacturerDTO)
        {
            //פונקצית הוספה
            try
            {
                VaccineManufacturer vaccineManufacturer = mapper.Map<VaccineManufacturer>(vaccineManufacturerDTO);
                return _vaccineManufacturerDAL.AddVaccineManufacturer(vaccineManufacturer);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}

