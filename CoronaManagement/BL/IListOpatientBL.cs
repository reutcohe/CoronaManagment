using DTO;
using System.Collections.Generic;

namespace BL
{
    public interface IListOpatientBL
    {
        bool AddListOpatient(ListOpatientDTO listOpatientDTO);
        bool DeleteListOpatient(string id);
        List<ListOpatientDTO> GetAllListsOpatient();
        bool UpdateListsOpatient(int id, ListOpatientDTO listOpatientDTO);
    }
}