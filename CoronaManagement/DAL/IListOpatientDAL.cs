using DAL.Models;
using System;
using System.Collections.Generic;

namespace DAL
{
    public interface IListOpatientDAL
    {
        bool AddPatientToList(ListOpatient patient);
        bool DeletePatientFromList(string id);
        List<ListOpatient> GetAllListsOpatients();
        bool UpdateListOpatients(int id, ListOpatient ListOpatient);
        public DateTime? GetDatePositive(string id);
    }
}