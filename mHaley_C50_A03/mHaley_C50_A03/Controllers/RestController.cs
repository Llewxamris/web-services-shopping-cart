using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using mHaley_C50_A03.Models;

namespace mHaley_C50_A03.Controllers
{
    public class RestController : ApiController
    {
        // GET: api/Rest
        public List<ShoppingListEntry> Get()
        {
            return ShoppingList.GetAllEntries();
        }

        // GET: api/Rest/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Rest
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Rest/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Rest/5
        public void Delete(int id)
        {
        }
    }
}
