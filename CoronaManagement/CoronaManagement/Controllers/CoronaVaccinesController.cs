using BL;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CoronaManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoronaVaccinesController : ControllerBase
    {

        ICoronaVaccineBL _coronaVaccineBL;
        public CoronaVaccinesController(ICoronaVaccineBL coronaVaccineBL)
        {
            _coronaVaccineBL = coronaVaccineBL;
        }
        [HttpGet]
        [Route("GetAll")]
        public ActionResult<List<CoronaVaccineDTO>> GetAllCoronaVaccines()
        {
            List<CoronaVaccineDTO> coronaVaccines = _coronaVaccineBL.GetAllCoronaVaccines();
            if (coronaVaccines == null)
                return NotFound();
            return Ok(coronaVaccines);
        }
        [HttpDelete]
        [Route("Delete/{id}")]
        public ActionResult<bool> DeleteListsOpatient(int id)
        {
            // פונקצית מחיקה
            if (id == null)
                return NotFound();
            var listOpatient = _coronaVaccineBL.DeleteCoronaVaccine(id);
            return Ok(listOpatient);
        }
        [HttpPost]
        [Route("Add")]
        public ActionResult<bool> AddCoronaVaccine([FromBody] CoronaVaccineDTO coronaVaccineDTO)
        {
            if (coronaVaccineDTO.PatientId.Equals(null))
                return StatusCode(400, "חייב להכניס תז");

            return Ok(_coronaVaccineBL.AddCoronaVaccine(coronaVaccineDTO));

        }

        [HttpPut]
        [Route("UpDate/{id}")]
        public ActionResult<bool> UpdateCoronaVaccine(int id, [FromBody] CoronaVaccineDTO coronaVaccineDTO)
        {
            if (coronaVaccineDTO.LineCode != id)
                return StatusCode(400, "יש להכניס את המספר סידורי של החיסון אותו תרצה לעדכן");
            return Ok(_coronaVaccineBL.UpdateCoronaVaccine(id, coronaVaccineDTO));
        }
    }
}
