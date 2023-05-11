using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using DTO;
using BLL;

namespace WebPogram.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PatientsController : ApiController
    {
        // GET: api/Patients
        [HttpGet]
        public List<PatientsDTO> Get()
        {
            return PatientsBLL.GetAllPatients();
        }

        // GET: api/Patients/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Patients
        [HttpPost]
        public bool AddPatients([FromBody] PatientsDTO value)
        {
            return PatientsBLL.AddNewPatients((int)value.entity_id, value.positve_date, value.recovery_date);
        }

        // PUT: api/Patients/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Patients/5
        public void Delete(int id)
        {
        }
    }
}
