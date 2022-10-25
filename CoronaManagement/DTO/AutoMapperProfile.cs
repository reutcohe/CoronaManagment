using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class AutoMapperProfile : AutoMapper.Profile
    {
        //IListOpatientDAL _ListOpatientDal;

        public AutoMapperProfile()
        {

            //_ListOpatientDal = listOpatientDAL;
            CreateMap<VaccineManufacturerDTO, VaccineManufacturer>();
            CreateMap<VaccineManufacturer, VaccineManufacturerDTO>();//.ForMember("AirlineCode", c=>c.MapFrom(x=>x.AirlineCodeNavigation.Description));
            CreateMap<PatientDTO, Patient>();
            CreateMap<Patient, PatientDTO>();
            CreateMap<ListOpatientDTO, ListOpatient>();
            CreateMap<ListOpatient, ListOpatientDTO>();
            CreateMap<CoronaVaccineDTO, CoronaVaccine>();
            CreateMap<CoronaVaccine, CoronaVaccineDTO>();
            //שולף את הכתובת בשורה אחת
            CreateMap<Patient, ListDetailsDTO>()
                .ForMember(x => x.Adress, a => a.MapFrom(t => $"{t.City} {t.Street} {t.NumStreet}"))
                .ForMember(x => x.LastPositive, a => a.MapFrom(v => v.LastPositive)).
               ForMember(x => x.AllVaccineDates, a => a.MapFrom(v => v.CoronaVaccines.Select(l => l.DateV)));
            //CreateMap<PatientDetailsOfUpdateDTO, Patient>().ForMember(x => x.LastPositive, a => a.MapFrom(v => v.LastPositive)).
            // ForMember(x => x.AllVaccineDates, a => a.MapFrom(v => v.CoronaVaccines.Select(l => l.DateV)));
            CreateMap<Patient, PatientDetailsOfUpdateDTO>().ForMember(x => x.LastPositive, a => a.MapFrom(v => v.LastPositive));
            CreateMap<PatientDetailsOfUpdateDTO, Patient > ().ForMember(x => x.LastPositive, a => a.MapFrom(v => v.LastPositive));//.ForMember(x => x.LastPositive, a => a.MapFrom(v => v.LastPositive));//.ForMember(x => x.LastPositive, a => a.MapFrom(v => v.LastPositive));
            //  ForMember(x => x.AllVaccineDates, a => a.MapFrom(v => v.CoronaVaccines.Select(l => l.DateV)));
            //CreateMap<ListDetailsDTO, Patient>()
            //// .ForMember(t => $"{t.City} {t.Street} {t.NumStreet}", a => a.MapFrom(x => x.Adress))
            // .ForMember(x => x.LastPositive, a => a.MapFrom(v => v.LastPositive)).
            //ForMember(x => x.AllVaccineDates, a => a.MapFrom(v => v.CoronaVaccines.Select(l => l.DateV)));
            //Include<Patient, ListDetailsDTO>().ForMember(a => a.DatePositive, async v => await _ListOpatientDal.GetDatePositive(v.MapFrom(a => a.PatientId));

        }

    }
}
