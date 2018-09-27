using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    [RoutePrefix("ecommerce")]
    public class TesteController : ApiController
    {
        // GET http://<servidor>:<porta>/api/Teste
        // GET: api/Teste
        [HttpGet]
        [Route("Obter/Cesta")]
        public IEnumerable<string> Obter()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Teste/5
        [Route("Obter/{id}/Cesta")]
        public string Get(int id)
        {
            return "value " + id;
        }
        // POST http://<servidor>:<porta>/api/Teste
        // POST: api/Teste
        public Resposta Post([FromBody]Resposta value)
        {
            return new Resposta { Resp = value.Resp };
        }
        // PUT: api/Teste/5
        public Resposta Put(int id, [FromBody]Resposta value)
        {
            return new Resposta { Resp = value.Resp };
        }

        // DELETE: api/Teste/5
        public void Delete(int id)
        {
        }
    }
    public class Resposta
    {
        public string Resp { get; set; }
    }
}
