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
    public class VaccineController : ApiController
    {
        // GET: api/Vaccine

        [HttpGet]
        public List<List<dynamic>> GetVaccinewithManufacturername()
        {
            return VaccineBLL.GetVaccinewithManufacturername().ToList();
        }
        [HttpGet]
        public List<VaccineDTO> Get()
        {
            return VaccineBLL.GetAllVaccine();
        }

        // GET: api/Vaccine/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Vaccine
        [HttpPost]
        public bool AddVaccine([FromBody] VaccineDTO value)
        {
            return VaccineBLL.AddNewVaccine(value.name_vaccine, (int)value.manufacturer_id, (int)value.count_vaccine, value.manufacturing_date, value.expiry_date);
        }

        // PUT: api/Vaccine/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Vaccine/5
        public void Delete(int id)
        {
        }
    }
}
