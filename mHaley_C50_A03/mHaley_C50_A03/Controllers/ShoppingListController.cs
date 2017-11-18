using System.Web.Mvc;
using mHaley_C50_A03.Models;

namespace mHaley_C50_A03.Controllers
{
    public class ShoppingListController : Controller
    {
        // GET: ShoppingList
        public ActionResult Index()
        {
            return View(ShoppingList.GetAllEntries());
        }

        // GET: ShoppingList/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ShoppingList/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShoppingList/Create
        [HttpPost]
        public ActionResult Create(ShoppingListEntry newShoppingListEntry)
        {
            try
            {
                ShoppingList.AddEntryToList(newShoppingListEntry);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ShoppingList/Edit/5
        public ActionResult Edit(string name)
        {
            return View(ShoppingList.GetSpecificEntry(name));
        }

        // POST: ShoppingList/Edit/5
        [HttpPost]
        public ActionResult Edit(ShoppingListEntry changeShoppingListEntry)
        {
            try
            {
                ShoppingList.ReplaceEntryInList(changeShoppingListEntry);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ShoppingList/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ShoppingList/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
