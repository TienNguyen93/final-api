# Customer Order 

## Different endpoints that a client can use

  | API                              | Description                        | Resquest Body | Response Body
  | :-----------                     | :-----------                       | :------------ | :------------
  | **GET** /api/customers            | Get all customers                  | None          | <img src="/images/get-all.png" width=100% height=100%>
  | **GET** /api/customers/{id}       | Get a customer by ID               | None          | <img src="/images/get-one.png" width=100% height=100%>
  | **POST** /api/customers           | Add a new customer                 | <img src="/images/post-body.png" width=100% height=100%> | <img src="/images/post-response.png" width=100% height=100%>
  | **PUT** /api/customers/{id}       | Updating an existing customer      | <img src="/images/put-body.png" width=100% height=100%>  | <img src="/images/put-response.png" width=100% height=100%>
  | **DELETE** /api/customers/{id}    | Delete a customer                  | None          | <img src="/images/delete-response.png" width=100% height=100%>
  | **GET** /api/customers/{id}/order | Get customer's order's information | None          | <img src="/images/get-order.png" width=100% height=100%>
  
## Changes to my API idea:
* I reduced my database from four tables to two tables since it is complicated to construct four tables
* I omitted Firstname, Lastname, Phone, EmailAddress columns in Customer table. So the final version has CustomerName, Street, City, State, Zip, Order which I found it was easier to maintain
* I set OrderID as the Foreign Key in the Customer table instead of setting CustomerID as the Foreign Key in Order table 
