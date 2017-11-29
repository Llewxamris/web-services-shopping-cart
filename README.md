# Web Services - SOAP, REST Shopping List
## Part A: REST/JSON based ShoppingCart function
Based on the Shopping list site built in A03, with additional services. 

### Black box requirements
    1. Create a new page called ShoppingCart, available from the Navigation bar 
		at the top.
    2. The Shopping Cart page will show the Shopping List and start off with an 
		empty shopping cart.
    3. User can drag/drop Shopping List items into the Shopping Cart.
    4. User can remove things from the Shopping Cart and return them to the 
		Shopping List.
    5. On Checkout:
        a. On success: A pop-up shows the # Items and Total cost and lets the 
			user know the checkout was successful.  Once the pop-up is
			dismissed, the user is returned to the Shopping list.  All the items
			that were in the Shopping Cart at checkout time have been removed 
			from the Shopping List.
        b. On Failure: a pop-up indicates which items failed to checkout.  
			(Items no longer in Shopping List, not found).  Once the pop-up is 
			dismissed, the updated Shopping Cart page is shown with updates to 
			the shopping list and the shopping cart.
			
### Implementation notes:
    1. The server side will have a REST/JSON interface to manipulate the
		Shopping List (get list, delete list)
    2. The client side code will be in the new ShoppingCart view
    3. The Shopping Cart UI interactions are completely on the Client side, 
		with the exception of transitioning into the page and out of the 
		Shopping Cart page.  In other words, the ShoppingCart page must fetch 
		the Shopping List, manage the movement of items to/from the Shopping 
		Cart, update the Server on checkout and deal with checkout failure.
    4. Shopping cart is a client-side only construct, it doesn’t exist on the 
		server
    5. The shopping cart shows per item: (Description, cost, quantity), totals: 
		( #items, total cost).  These are updated as items move in/out the cart.
    6. If the checkout fails, a useful error message is displayed and no portion
		of the checkout goes through.
    7. A checkout of an item may fail it is not in the original shopping list 
		any more.  (Consider two people using the site simultaneously).  Don’t 
		worry about checking price and other attributes, we’ll keep it simple 
		and just consider the existence of items.
    8. Make it look nice. Something that you would not be embarrassed to show 
		your peers.

### Sample work flow:
    1. Create shopping list
    2. Put some of the things on the shopping list into your cart
    3. In another browser window/tab modify the price of an item that was in the
		shopping cart on the server.
    4. Attempt checkout.  It fails and tells you which item(s) cause the failed 
		checkout because they are no longer in the shopping list.
    5. User is shown updated Shopping Cart (failed items are indicated showing 
		as not part of the checkout)
    6. Attempt checkout.  It succeeds.
    7. A detailed receipt is shown.  (not tax, just simple total, # items)

## Part B: Service References in C# .NET
### Black box requirements:
    1. Create a page where User selects a 2 digit country code (i.e from a pull 
		down.)
    2. Given that Country, a list of cities from that country appear.
    3. If the user selects one of the cities, the latitude, longitude and 
		weather for that city appears

### Implementation notes:
    1. Use the same project at Part A, just put this in a new Controller/view.  
		Have a “Cities” link in the shared Nav bar.  (We are doing this to 
		reduce the project overhead so that you can submit both parts and it 
		fits in Moodle).
    2. GUI, client/server design and page load decisions are up to you.  The key 
		thing is for me to see that you know how to invoke a remote service via 
		Service Reference.  Your server code will use the Service Reference to 
		interact with the Cities service on CSDEV.
    3. Make it look nice.  
