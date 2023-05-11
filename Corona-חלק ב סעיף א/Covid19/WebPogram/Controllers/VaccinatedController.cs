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
    public class VaccinatedController : ApiController
    {
        // GET: api/Vaccinated
        [HttpGet]
        public List<VaccinatedDTO> Get()
        {
            return VaccinatedBLL.GetAllVaccinated();
        }
        [HttpGet]
        public List<List<dynamic>> GetVaccinatedwithManufacturername()
        {
            return VaccinatedBLL.GetVaccinatedwithManufacturername().ToList();
        }


        // GET: api/Vaccinated/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Vaccinated
        [HttpPost]
        public bool AddVaccinated([FromBody] VaccinatedDTO value)
        {
            return VaccinatedBLL.AddNewVaccinated((int)value.entity_id, (int)value.vaccine_id, value.receiving_date);
        }

        // PUT: api/Vaccinated/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Vaccinated/5
        public void Delete(int id)
        {
        }
    }
}
