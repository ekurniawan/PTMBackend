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
        public IHttpActionResult Put(string id,TipeStatus tipestatus)
        {
            TipeStatusDAL tipeStatusDAL = new TipeStatusDAL();

            var result = tipeStatusDAL.GetById(id);

            if(result!=null)
            {
                try
                {
                    result.NamaTipe = tipestatus.NamaTipe;
                    tipeStatusDAL.Update(result);
                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            else
            {
                return BadRequest("Data not found !");
            }
        }

        // DELETE: api/TipeStatus/5
        public IHttpActionResult Delete(string id)
        {
            TipeStatusDAL tipeStatusDAL = new TipeStatusDAL();

            var result = tipeStatusDAL.GetById(id);

            if (result != null)
            {
                try
                {
                    tipeStatusDAL.Delete(id);
                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            else
            {
                return BadRequest("Data not found !");
            }
        }
    }
}
