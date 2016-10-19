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

        // GET: api/COIDetail/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/COIDetail
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/COIDetail/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/COIDetail/5
        public void Delete(int id)
        {
        }
    }
}
