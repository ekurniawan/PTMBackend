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
    public class PenggunaController : ApiController
    {
        // GET: api/Pengguna
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Pengguna/5
        [HttpPost]
        [Route("api/Pengguna/GetLogin")]
        public Pengguna GetLogin(Pengguna pengguna)
        {
            PenggunaDAL penggunaDAL = new PenggunaDAL();
            return penggunaDAL.GetLogin(pengguna);
        }

        // POST: api/Pengguna
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Pengguna/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Pengguna/5
        public void Delete(int id)
        {
        }
    }
}
