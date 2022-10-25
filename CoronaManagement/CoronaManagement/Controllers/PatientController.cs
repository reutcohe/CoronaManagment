using BL;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CoronaManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {

        IPatientBL _PatientBL;
        public PatientController(IPatientBL patientBL)
        {
            _PatientBL = patientBL;
        }
        [HttpGet]
        [Route("GetAll")]
        public ActionResult<List<PatientDTO>> GetAllPatients()
        {
            List<PatientDTO> Patients = _PatientBL.GetAllPatients();
            if (Patients == null)
                return NotFound();
            return Ok(Patients);
        }
        [HttpGet]
        [Route("GetByIdFullInfo")]
        public ActionResult<ListDetailsDTO> GetPatientByIdFullInfo(string id)
        {
            ListDetailsDTO Patient = _PatientBL.GetPatientByIdFullInfo(id);
            if (Patient == null)
                return NotFound();
            return Ok(Patient);
        }
        [HttpDelete]
        [Route("Delete/{id}")]
        public ActionResult<bool> DeletePatient(string id)
        {
            // פונקצית מחיקה
            if (id == null)
                return NotFound();
            var Patient = _PatientBL.DeletePatient(id);
            return Ok(Patient);
        }
        [HttpPost]
        [Route("Add")]
        public ActionResult<bool> AddPatient([FromBody] PatientDTO patientDTO)
        {
            if (patientDTO.PatientId .Equals(null))
                return StatusCode(400, "חייב להכניס תז");

            return Ok(_PatientBL.AddPatient(patientDTO));

        }
        [HttpPut]
        [Route("UpDate/{id}")]
        public ActionResult<bool> UpdatePatien(string id, [FromBody] PatientDTO patientDTO)
        {
            if (patientDTO.PatientId != id)
                return StatusCode(400, "יש להכניס את תז של חבר הקופה שאת פרטיו אתה מעונין לעדכן");
            return Ok(_PatientBL.UpdatePatient(id, patientDTO));
        }
        [HttpDelete]
        [Route("DeleteAllInfo/{id}")]
        public ActionResult<bool> DeletePatientAllInfo(string id)
            {
                // פונקצית מחיקה
                if (id == null)
                    return NotFound();
                var Patient = _PatientBL.DeletePatientAllInfo(id);
                return Ok(Patient);
            }
        //public ActionResult<bool> UpdatePatienFullInfo(string id, [FromBody] ListDetailsOfUpdateDTO listDetailsOfUpdateDTO)
        //{
        //    if (listDetailsOfUpdateDTO.PatientId != id)
        //        return StatusCode(400, "יש להכניס את תז של חבר הקופה שאת פרטיו אתה מעונין לעדכן");
        //    return Ok(_PatientBL.UpdatePatienFullInfo(id, listDetailsOfUpdateDTO));
        //}
        [HttpGet]
        [Route("getPatientOfUpDate")]
        public ActionResult<PatientDetailsOfUpdateDTO> getPatientOfUpDate(string id)
        {
            if (id==null)
                return StatusCode(400, "יש להכניס את תז של חבר הקופה שאת פרטיו אתה מעונין לעדכן");
            return Ok(_PatientBL.getPatientOfUpDate(id));
        }
        [HttpPut]
        [Route("UpDateFullInfo/{id}")]
        public ActionResult<bool> UpdatePatienFullInfo(string id, [FromBody] PatientDetailsOfUpdateDTO patientDetailsOfUpdateDTO)
        {
            if (patientDetailsOfUpdateDTO.PatientId != id)
                return StatusCode(400, "יש להכניס את תז של חבר הקופה שאת פרטיו אתה מעונין לעדכן");
            return Ok(_PatientBL.UpdatePatienFullInfo(id, patientDetailsOfUpdateDTO));
        }
        [HttpPost]
        [Route("AddAllInfo")]
        public ActionResult<bool> AddPatientAllInfo([FromBody] PatientDetailsOfUpdateDTO patientDetailsOfUpdateDTO)
        {
            if (patientDetailsOfUpdateDTO.PatientId.Equals(null))
                return StatusCode(400, "חייב להכניס תז");

            return Ok(_PatientBL.AddPatientAllInfo(patientDetailsOfUpdateDTO));

        }
    }
}
