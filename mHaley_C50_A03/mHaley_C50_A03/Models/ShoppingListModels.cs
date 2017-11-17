using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mHaley_C50_A03.Models
{
    public class ShoppingList
    {
        /* Mimics a shopping list. Contains a list of ShoppingListEntries.
         * Also contains a singleton pattern that stores all this list into
         * memory. */
        public List<ShoppingListEntry> Entries { get; set; }
        // TODO: Singleton Pattern
    }

    public class ShoppingListEntry
    {
        public int Quantity { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductCategory { get; set; }

        public ShoppingListEntry() { }

        public ShoppingListEntry(int quantiy, string productName,
            decimal productPrice, string productCategory)
        {
            Quantity = quantiy;
            ProductName = productName;
            ProductPrice = productPrice;
            ProductCategory = productCategory;
        }
    }
}