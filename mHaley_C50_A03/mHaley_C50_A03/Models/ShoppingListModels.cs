using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Web;
using System.Web.Hosting;
using System.Xml.Linq;
using WebGrease.Css.Extensions;

namespace mHaley_C50_A03.Models
{
    public class ShoppingList
    {
        /* Mimics a shopping list. Contains a list of ShoppingListEntries.
         * Also contains a singleton pattern that stores all this list into
         * memory. */
        private static List<ShoppingListEntry> _instance;

        public static List<ShoppingListEntry> Entries => _instance ??
            (_instance = GetShoppingListFromXml());

        [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
        private static List<ShoppingListEntry> GetShoppingListFromXml()
        {
            /* Read the ShoppingList.xml file, and convert each entry to an
             * object of ShoppingListEntry. Returns each object in a list. */
            try
            {
                var entries = new List<ShoppingListEntry>();
                // ReSharper disable once AssignNullToNotNullAttribute
                XElement shoppingListXmlElement = XElement.Load(HostingEnvironment.MapPath("~/App_Data/ShoppingList.xml"));
                IEnumerable<XElement> entryElements =
                    from x in shoppingListXmlElement.Elements()
                    select x;

                entryElements.ForEach(entry =>
                {
                    entries.Add(new ShoppingListEntry(int.Parse(entry.Element("quantity").Value),
                        entry.Element("productName").Value, 
                        decimal.Parse(entry.Element("productPrice").Value),
                        entry.Element("productCategory").Value));
                });

                return entries;
            }
            catch (IOException)
            {
                return null;
            }
        }// GetShoppingListFromXml()
    }// ShoppingList

    public class ShoppingListEntry
    {
        /* Mimics an entry in a shopping list. Is stored in a list by the
         * ShoppingList class.*/

        public int Quantity { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductCategory { get; set; }

        public ShoppingListEntry() { } // ShoppingListEntry()

        public ShoppingListEntry(int quantiy, string productName,
            decimal productPrice, string productCategory)
        {
            Quantity = quantiy;
            ProductName = productName;
            ProductPrice = productPrice;
            ProductCategory = productCategory;
        }// ShoppingListEntry(...)
    }// ShoppingListEntry
}