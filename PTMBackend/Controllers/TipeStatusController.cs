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
    public class TipeStatusController : ApiController
    {
        // GET: api/TipeStatus
        public IEnumerable<TipeStatus> Get()
        {
            TipeStatusDAL tipeStatusDAL = new TipeStatusDAL();
            return tipeStatusDAL.GetAll();
        }

        // GET: api/TipeStatus/5
        public TipeStatus Get(string id)
        {
            TipeStatusDAL tipeStatusDAL = new TipeStatusDAL();

            return tipeStatusDAL.GetById(id);
        }

        // POST: api/TipeStatus
        public IHttpActionResult Post(TipeStatus tipestatus)
        {
            TipeStatusDAL tipeStatusDAL = new TipeStatusDAL();
            try
            {
                tipeStatusDAL.Insert(tipestatus);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/TipeStatus/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/TipeStatus/5
        public void Delete(int id)
        {
        }
    }
}
