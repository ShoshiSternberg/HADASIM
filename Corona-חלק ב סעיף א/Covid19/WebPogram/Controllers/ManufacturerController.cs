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
    public class ManufacturerController : ApiController
    {
        // GET: api/Manufacturer
        [HttpGet]
        public List<ManufacturerDTO> Get()
        {
            return ManutfacturerBLL.GetAllManufacturer();
        }

        // GET: api/Manufacturer/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Manufacturer
        [HttpPost]
        public bool AddManufacturer([FromBody] ManufacturerDTO value)
        {
            return ManutfacturerBLL.AddNewManufacturer(value.manufacturer_name, value.phone_order);
        }

        // PUT: api/Manufacturer/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Manufacturer/5
        public void Delete(int id)
        {
        }
    }
}
