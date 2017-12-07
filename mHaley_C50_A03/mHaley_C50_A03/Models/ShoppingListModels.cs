using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Web.Hosting;
using System.Xml.Linq;
using System.Xml.Schema;
using WebGrease.Css.Extensions;

namespace mHaley_C50_A03.Models
{
    public class ShoppingList
    {
        /* Mimics a shopping list. Contains a list of ShoppingListEntries.
         * Also contains a singleton pattern that stores all this list into
         * memory. */
        private static List<ShoppingListEntry> _instance;

        private static List<ShoppingListEntry> Entries => _instance ??
            (_instance = GetShoppingListFromXml());

        public static void AddEntryToList(ShoppingListEntry newShoppingListEntry)
        {
            Entries.Add(newShoppingListEntry);
            WriteToXmlFile();
        }// AddEntryToList(...)

        public static void ReplaceEntryInList(ShoppingListEntry changedShoppingListEntry)
        {
            ShoppingListEntry oldShoppingListEntry = GetSpecificEntry(changedShoppingListEntry.ProductName);

            if (oldShoppingListEntry == null)
            {
                AddEntryToList(changedShoppingListEntry);
            }
            else
            {
                oldShoppingListEntry.ProductName = changedShoppingListEntry.ProductName;
                oldShoppingListEntry.ProductCategory = changedShoppingListEntry.ProductCategory;
                oldShoppingListEntry.ProductPrice = changedShoppingListEntry.ProductPrice;
                oldShoppingListEntry.Quantity = changedShoppingListEntry.Quantity;
                WriteToXmlFile();
            }
        }// ReplaceEntryInList(...)

        public static void DeleteEntryInList(string name)
        {
            Entries.RemoveAll(entry => entry.ProductName == name);
            WriteToXmlFile();
        }// DeleteEntryInList(...)

        public static void DeleteAllEntries()
        {
            Entries.Clear();
            WriteToXmlFile();
        }// DeleteAllEntries()

        public static ShoppingListEntry GetSpecificEntry(string name)
        {
            return Entries.Find(entry => entry.ProductName == name);
        }// GetSpecificEntry(...)

        public static List<ShoppingListEntry> GetAllEntries()
        {
            return Entries;
        }// GetAllEntries()

        [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
        private static void WriteToXmlFile()
        {
            // HACK: Forgive me father, for I have sinned
            try { 
            XElement shoppingListXmlElement = XElement.Load(HostingEnvironment.MapPath("~/App_Data/ShoppingList.xml"));
            XNamespace ns = "http://tempuri.org/ShoppingList.xsd";
            shoppingListXmlElement.RemoveAll();

            Entries.ForEach(entry =>
            {
                shoppingListXmlElement.Add(new XElement(ns + "shoppingEntry", 
                    new XElement(ns + "quantity", entry.Quantity),
                    new XElement(ns + "product", 
                        new XAttribute("category", entry.ProductCategory),
                        new XElement(ns + "name", entry.ProductName),
                        new XElement(ns + "price", entry.ProductPrice))));
            });

                shoppingListXmlElement.Save(HostingEnvironment.MapPath("~/App_Data/ShoppingList.xml"));
            }
            catch (IOException)
            {
                WriteToXmlFile();
            }
        }

        [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
        private static List<ShoppingListEntry> GetShoppingListFromXml()
        {
            /* Read the ShoppingList.xml file, and convert each entry to an
             * object of ShoppingListEntry. Returns each object in a list. */
            try
            {
                var entries = new List<ShoppingListEntry>();
                // ReSharper disable once AssignNullToNotNullAttribute
                if (!XmlIsValid())
                {
                    return null;
                }

                // ReSharper disable once AssignNullToNotNullAttribute
                XElement shoppingListXmlElement = XElement.Load(HostingEnvironment.MapPath("~/App_Data/ShoppingList.xml"));
                XNamespace ns = "http://tempuri.org/ShoppingList.xsd";
                IEnumerable<XElement> entryElements =
                    from x in shoppingListXmlElement.Elements()
                    select x;

                entryElements.ForEach(entry =>
                {
                    entries.Add(new ShoppingListEntry
                    {
                        Quantity = int.Parse(entry.Element(ns + "quantity").Value),
                        ProductCategory = entry.Element(ns + "product").Attribute("category").Value,
                        ProductName = entry.Element(ns + "product").Element(ns + "name").Value,
                        ProductPrice = decimal.Parse(entry.Element(ns + "product").Element(ns + "price").Value)
                    });
                });

                return entries;
            }
            catch (IOException)
            {
                return null;
            }
        }// GetShoppingListFromXml()

        [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
        private static bool XmlIsValid()
        {
            var isValid = true;
            XDocument document = XDocument.Load(HostingEnvironment.MapPath("~/App_Data/ShoppingList.xml"));
            var schemaSet = new XmlSchemaSet();

            schemaSet.Add("http://tempuri.org/ShoppingList.xsd",
                HostingEnvironment.MapPath("~/App_Data/ShoppingList.xsd"));

            document.Validate(schemaSet, (o, e) =>
            {
                isValid = false;
            });

            return isValid;
        }
    }// ShoppingList

    public class ShoppingListEntry
    {
        /* Mimics an entry in a shopping list. Is stored in a list by the
         * ShoppingList class.*/
        [Required(ErrorMessage = "Quantity is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least one.")]
        [DisplayName("Quantity")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Product Name is required.")]
        [DisplayName("Product Name")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [DisplayName("Price")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        [DataType(DataType.Currency)]
        public decimal ProductPrice { get; set; }

        [Required(ErrorMessage = "Category is required.")]
        [DisplayName("Category")]
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