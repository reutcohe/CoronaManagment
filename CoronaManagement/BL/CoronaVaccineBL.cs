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
    public class CoronaVaccineBL : ICoronaVaccineBL
    {

        ICoronaVaccineDAL _coronaVaccineDAL;
        IMapper mapper;
        public CoronaVaccineBL(ICoronaVaccineDAL coronaVaccineDAL)
        {
            _coronaVaccineDAL = coronaVaccineDAL;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();

            });
            mapper = config.CreateMapper();
        }
        public List<CoronaVaccineDTO> GetAllCoronaVaccines()
        {
            List<CoronaVaccine> allCoronaVaccines = _coronaVaccineDAL.GetAllCoronaVaccines();

            return mapper.Map<List<CoronaVaccineDTO>>(allCoronaVaccines);
        }
        public bool UpdateCoronaVaccine(int id, CoronaVaccineDTO coronaVaccineDTO)
        {

            CoronaVaccine coronaVaccine = mapper.Map<CoronaVaccine>(coronaVaccineDTO);
            return _coronaVaccineDAL.UpdateCoronaVaccine(id, coronaVaccine);
        }
        public bool DeleteCoronaVaccine(int id)
        {
            // פונקצית מחיקה
            try
            {

                return _coronaVaccineDAL.DeletecoronaVaccines(id);
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public bool AddCoronaVaccine(CoronaVaccineDTO coronaVaccineDTO)
        {
            //פונקצית הוספה
            try
            {
                CoronaVaccine coronaVaccine = mapper.Map<CoronaVaccine>(coronaVaccineDTO);
                return _coronaVaccineDAL.AddcoronaVaccine(coronaVaccine);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


    }
}

