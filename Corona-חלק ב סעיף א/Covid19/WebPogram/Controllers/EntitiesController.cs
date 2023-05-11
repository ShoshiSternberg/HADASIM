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
    public class EntitiesController : ApiController
    {    [HttpGet]
        // GET: api/Entities
        public List<EntitiesDTO> Get()
        {
            return EntitiesBLL.GetAllPackages();
        }

        // GET: api/Entities/5
        public string Get(int id)
        {
            return "value";
        }

      
        // POST: api/Entities
        [HttpPost]
        public bool addEntities([FromBody] EntitiesDTO value)
        {
            return EntitiesBLL.AddNewentity((int)value.entity_id,value.first_name,value.last_name,value.birth_date,value.phone,value.cell_phone,(bool)value.employee,value.city,value.street,(int)value.street_num);
        }

        // PUT: api/Entities/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Entities/5
        public void Delete(int id)
        {
        }
    }
}
