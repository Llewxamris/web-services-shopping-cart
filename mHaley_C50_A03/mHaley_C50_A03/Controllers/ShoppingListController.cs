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

        //// GET: ShoppingList/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: ShoppingList/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

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

        // GET: ShoppingList/Edit/apple
        public ActionResult Edit(string name)
        {
            return View(ShoppingList.GetSpecificEntry(name));
        }

        // POST: ShoppingList/Edit/apple
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

        // GET: ShoppingList/Delete/apple
        public ActionResult Delete(string name)
        {
            return View(ShoppingList.GetSpecificEntry(name));
        }

        // POST: ShoppingList/Delete/apple
        [HttpPost]
        public ActionResult Delete(ShoppingListEntry deletedShoppingListEntry, string name)
        {
            try
            {
                ShoppingList.DeleteEntryInList(name);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ShoppingList/DeleteAll
        public ActionResult DeleteAll()
        {
            return View();
        }

        // POST: ShoppingList/DeleteAll
        [HttpPost]
        public ActionResult DeleteAll(byte? _)
        {
            try
            {
                ShoppingList.DeleteAllEntries();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
