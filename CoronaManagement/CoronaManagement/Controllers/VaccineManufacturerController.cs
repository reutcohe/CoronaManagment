using BL;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CoronaManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VaccineManufacturerController : ControllerBase
    {
        [Route("api/[controller]")]
        [ApiController]
        public class ListOpatientController : ControllerBase
        {
            IVaccineManufacturerBL _VaccineManufacturerBL;
            public ListOpatientController(IVaccineManufacturerBL vaccineManufacturerBL)
            {
                _VaccineManufacturerBL = vaccineManufacturerBL;
            }
            [HttpGet]
            [Route("GetAll")]
            public ActionResult<List<VaccineManufacturerDTO>> GetAllVaccineManufacturers()
            {
                List<VaccineManufacturerDTO> vaccineManufacturers = _VaccineManufacturerBL.GetAllVaccineManufacturers();
                if (vaccineManufacturers == null)
                    return NotFound();
                return Ok(vaccineManufacturers);
            }
            [HttpDelete]
            [Route("Delete/{id}")]
            public ActionResult<bool> DeleteVaccineManufacturer(string id)
            {
                // פונקצית מחיקה
                if (id == null)
                    return NotFound();
                var vaccineManufacturer = _VaccineManufacturerBL.DeleteVaccineManufacturer(id);
                return Ok(vaccineManufacturer);
            }
            [HttpPost]
            [Route("Add")]
            public ActionResult<bool> AddVaccineManufacturer([FromBody] VaccineManufacturerDTO vaccineManufacturerDTO)
            {
                if (vaccineManufacturerDTO.CompanyId.Equals(null))
                    return StatusCode(400, "חייב להכניס קוד חברה");

                return Ok(_VaccineManufacturerBL.AddVaccineManufacturer(vaccineManufacturerDTO));

            }
            [HttpPut]
            [Route("UpDate/{id}")]
            public ActionResult<bool> UpdaVaccineManufacturer(string id, [FromBody] VaccineManufacturerDTO vaccineManufacturerDTO)
            {
                if (vaccineManufacturerDTO.CompanyId.Equals(id))
                    return StatusCode(400, "יש להכניס את קוד החברה שאת פרטיה תרצה לעדכן");
                return Ok(_VaccineManufacturerBL.UpdateVaccineManufacturer(id, vaccineManufacturerDTO));
            }
        }
    }
}
