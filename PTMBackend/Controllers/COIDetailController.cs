using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using PTMBackend.Models;
using PTMBackend.DAL;

namespace PTMBackend.Controllers
{
    public class COIDetailController : ApiController
    {
        // GET: api/COIDetail
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [Route("api/COIDetail/GetStatus")]
        public IEnumerable<CIStatusView> GetStatus()
        {
            COIDetailDAL coiDetailDAL = new COIDetailDAL();
            return coiDetailDAL.GetCOIStatus();
        }

        [Route("api/COIDetail/GetCOIByStatus/{id}")]
        public IEnumerable<COIDetail> GetCOIByStatus(string id)
        {
            COIDetailDAL coiDetailDAL = new COIDetailDAL();
            return coiDetailDAL.GetCOIByStatus(id);
        }

        [Route("api/COIDetail/GetCOIByNamaStatus/{nama}")]
        public IEnumerable<COIDetail> GetCOIByNamaStatus(string nama)
        {
            COIDetailDAL coiDetailDAL = new COIDetailDAL();
            return coiDetailDAL.GetCOIByNamaStatus(nama);
        }

        // GET: api/COIDetail/5
        public COIDetail Get(string id)
        {
            COIDetailDAL coiDetailDAL = new COIDetailDAL();
            return coiDetailDAL.GetCOIById(id);
        }

        // POST: api/COIDetail
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/COIDetail/5
        public IHttpActionResult Put(string id, COIDetail model)
        {
            COIDetailDAL coiDetailDAL = new COIDetailDAL();
            try
            {
                coiDetailDAL.Update(id, model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/COIDetail/5
        public void Delete(int id)
        {
        }
    }
}
