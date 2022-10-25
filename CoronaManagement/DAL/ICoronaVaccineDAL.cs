using DAL.Models;
using System.Collections.Generic;

namespace DAL
{
    public interface ICoronaVaccineDAL
    {
        bool AddcoronaVaccine(CoronaVaccine coronaVaccine);
        bool DeletecoronaVaccines(int id);
        List<CoronaVaccine> GetAllCoronaVaccines();
        bool UpdateCoronaVaccine(int id, CoronaVaccine coronaVaccines);
    }
}