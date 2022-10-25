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
    public class ListOpatientBL : IListOpatientBL
    {
        IListOpatientDAL _ListOpatientDal;
        IMapper mapper;
        public ListOpatientBL(IListOpatientDAL listOpatientDAL)
        {
            _ListOpatientDal = listOpatientDAL;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();

            });
            mapper = config.CreateMapper();
        }
        public List<ListOpatientDTO> GetAllListsOpatient()
        {
            List<ListOpatient> allListPatients = _ListOpatientDal.GetAllListsOpatients();

            return mapper.Map<List<ListOpatientDTO>>(allListPatients);
        }
        public bool UpdateListsOpatient(int id, ListOpatientDTO listOpatientDTO)
        {

            ListOpatient listOpatient = mapper.Map<ListOpatient>(listOpatientDTO);
            return _ListOpatientDal.UpdateListOpatients(id, listOpatient);
        }
        public bool DeleteListOpatient(string id)
        {
            // פונקצית מחיקה
            try
            {

                return _ListOpatientDal.DeletePatientFromList(id);
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public bool AddListOpatient(ListOpatientDTO listOpatientDTO)
        {
            //פונקצית הוספה
            try
            {
                ListOpatient listOpatient = mapper.Map<ListOpatient>(listOpatientDTO);
                return _ListOpatientDal.AddPatientToList(listOpatient);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        
    }
}
