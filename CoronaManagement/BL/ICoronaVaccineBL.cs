using DTO;
using System.Collections.Generic;

namespace BL
{
    public interface ICoronaVaccineBL
    {
        bool AddCoronaVaccine(CoronaVaccineDTO coronaVaccineDTO);
        bool DeleteCoronaVaccine(int id);
        List<CoronaVaccineDTO> GetAllCoronaVaccines();
        bool UpdateCoronaVaccine(int id, CoronaVaccineDTO coronaVaccineDTO);
    }
}