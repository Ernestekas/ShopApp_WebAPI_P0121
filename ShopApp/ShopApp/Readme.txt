Shop WEB API.

This WEB API contains:
1. Migration file to create required database.
	- To create database and tables: 
		- Open Nuget Package Manager -> Package manager console.
		- In console enter: update-database
		
2. Shops CRUD.
	- Create. Create shop by entering shop name.
	- GetAll. Get all shops from database.
	- GetById. Get shop by id.
	- Update. Change shop name.
	- Remove. Remove selected shop from database

3. Products CRUD.
	- Create. Create product. Input values: Name, Price, shop id (product will be assigned to this shop).
	- GetAll. Get list of all products from database.
	- GetById. Get product by id.
	- Update. Change product name, price or/and shop it is assigned.
	- Remove. Remove selected product.

4. Validation of shops and products data. Using Fluid Validation library.

5. Error handling.

This WEB API designed to work with front end Angular Shop application from here: https://github.com/Ernestekas/ShopApp_Angular.

You can use swagger or postman to check functionality or you can test it with another application I mentioned above.