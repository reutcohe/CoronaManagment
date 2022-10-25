using BL;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CoronaManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListOpatientController : ControllerBase
    {
        IListOpatientBL _ListOpatientBL;
        public ListOpatientController(IListOpatientBL listOpatientBL)
        {
            _ListOpatientBL = listOpatientBL;
        }
        [HttpGet]
        [Route("GetAll")]
        public ActionResult<List<ListOpatientDTO>> GetAllListsOpatient()
        {
            List<ListOpatientDTO> listsOpatient = _ListOpatientBL.GetAllListsOpatient();
            if (listsOpatient == null)
                return NotFound();
            return Ok(listsOpatient);
        }
        [HttpDelete]
        [Route("Delete/{id}")]
        public ActionResult<bool> DeleteListsOpatient(string id)
        {
            // פונקצית מחיקה
            if (id == null)
                return NotFound();
            var listOpatient = _ListOpatientBL.DeleteListOpatient(id);
            return Ok(listOpatient);
        }
        [HttpPost]
        [Route("Add")]
        public ActionResult<bool> AddlistOpatient([FromBody] ListOpatientDTO listOpatientDTO)
        {
            if (listOpatientDTO.PatientId.Equals(null))
                return StatusCode(400, "חייב להכניס תז");

            return Ok(_ListOpatientBL.AddListOpatient(listOpatientDTO));

        }
        [HttpPut]
        [Route("UpDate/{id}")]
        public ActionResult<bool> UpdatelistOpatient(int id, [FromBody] ListOpatientDTO listOpatientDTO)
        {
            if (listOpatientDTO.LineCode != id)
                return StatusCode(400, "יש להכניס את המספר סידורי של מקרה המחלה אותו תרצה לעדכן");
            return Ok(_ListOpatientBL.UpdateListsOpatient(id, listOpatientDTO));
        }
    }
}

