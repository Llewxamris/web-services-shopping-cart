using System.Collections.Generic;
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

        // DELETE: api/Rest/5
        [HttpDelete]
        public void Delete(string id)
        {
            ShoppingList.DeleteEntryInList(id);
        }
    }
}
