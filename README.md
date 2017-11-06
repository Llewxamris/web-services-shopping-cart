# Shopping List Web Application

## Description
An online application to manage a shopping list. The shopping list is stored inside
an XML file.

The user must be able to:
- View the shopping list, showing all items and the total cost of the items
- Add a new entry to the shopping list
- Delete single entry or all entries from the shopping list
- Modify an entry on the shopping list
    
Each entry in the shopping list includes:
- Quantity – i.e. how many of the product to buy
- Product Name – i.e what to buy
- Product Price – i.e. what’s it is going to cost
- Product Category – i.e. Beverages, Bread/Bakery, Canned/Jarred Goods, Dairy, …

The Product Category is a fixed list, that the user will select with a pull 
down option (or some other scheme where they don’t have to enter it by hand). 
The default category is *Other*.

## Technical Constraints
- Server side is implemented in C#/.NET using the MVC design pattern
- Client side code is any combination of  { HTML,CSS,JavaScript, 
    jQuery,Bootstrap} you like (provided the other constraints are met).
- Shopping list is stored as an XML file, all modifications will update
    the file so that if the application is restarted, the shopping list survives.  
- Your solution must produce a valid XML file.  Your solution will validate
    itself against your XSD schema file.
- The Controller method will return either full, partial views, or JSON.
    Do **not** expose any XML back to the client side.
- Respect the MVC pattern.  All CRUD of the shopping list belongs in the Model.
- CRUD is typically on the list entries.  Do not gratuitously pass around 
    the whole shopping list if it can be avoided.
- Assume the Product Name of an entry is unique in the list (i.e. you cannot
    have multiple entries of the same Product Name)
- You don’t need to scale to a list bigger than can fit on a standard desktop browser.
- The client side code, doesn’t know the Product Categories (i.e. **don’t hard code these**,
    you load it up from the server at run time).
- Your solution will be tested with the Firefox browser
- Your schema will respect:
    - XML document root is ShoppingList
    - ShoppingList contains 0 or more ShoppingEntry
    - ShoppingEntry has elements Product, Quantity
    - Product has mandatory attribute: Category, elements: Name, Price
    - Category is an enum (see Appendix A)
    - Name is a string no more than 20 characters
    - Price is $9999.99 format (i.e. 2 decimals of precision, positive value)
    - Quantity is a positive integer
    
## License
These documents are licensed under the GENERAL PUBLIC LICENSE 3.0. Please see
the LICENSE file for more information.
