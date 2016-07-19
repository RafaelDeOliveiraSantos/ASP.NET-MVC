using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MinhaLocadora.Controllers
{
//    [Authorize]
    public class ValuesController : ApiController
    {
        // GET api/values
        public dynamic Get()
        {
            var dados = new
            {
                Nome = "Fabrica",
                DataAberura = DateTime.Now.AddYears(-30),
                Pecas = new[]
                {
                    new { Nome = "Peça 1" },
                    new { Nome = "Peça 2" },
                    new { Nome = "Peça 3" },
                    new { Nome = "Peça 4" }
                }
            };
            return dados;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
