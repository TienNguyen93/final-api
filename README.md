# Customer Order 

## Different endpoints that a client can use
### Sample response body: 
```json
{
  "statusCode": 200,
  "statusDescription": "Call succeeds because ...",
  "data": "..."
}
```

  | API                              | Description                        | Resquest Body | Response Body
  | :-----------                     | :-----------                       | :------------ | :------------
  | **GET** /api/customers            | Get all customers                  | None          | <img src="/images/get-all.png" width=100% height=100%>
  | **GET** /api/customers/{id}       | Get a customer by ID               | None          | <img src="/images/get-one.png" width=100% height=100%>
  | **POST** /api/customers           | Add a new customer                 | <img src="/images/post-body.png" width=100% height=100%> | <img src="/images/post-response.png" width=100% height=100%>
  | **PUT** /api/customers/{id}       | Updating an existing customer      | <img src="/images/put-body.png" width=100% height=100%>  | <img src="/images/put-response.png" width=100% height=100%>
  | **DELETE** /api/customers/{id}    | Delete a customer                  | None          | <img src="/images/delete-response.png" width=100% height=100%>
  | **GET** /api/customers/{id}/order | Get customer's order's information | None          | <img src="/images/get-order.png" width=100% height=100%>
  

## SQL queries:
### Create database:
  ```sql
  CREATE DATABASE CustomerOrder;
  ```
  
### Create Customer table:
  ```sql
  CREATE TABLE Customers (
      CustomerID int not null auto_increment,
      CustomerName varchar(255) not null,
      Street varchar(255) not null,
      City varchar(255) not null, 
      State varchar(255) not null, 
      Zip varchar(255) not null, 
      Primary Key (CustomerID)
  );
  ```
  
### Create Orders table:
  ```sql
  CREATE TABLE Orders (
      OrderID int not null auto_increment,
      OrderDate varchar(255) not null,
      ShipDate varchar(255) not null,
      IsShipped boolean not null,
      primary key (OrderID)
  );
  ```
  
### Add OrderID column to Customers table:
  ```sql
  ALTER TABLE Customers ADD COLUMN OrderID int;
  ```
  
### Make OrderID column in Customers table as Foreign Key:
  ```sql
  ALTER TABLE Customers ADD CONSTRAINT FK_CustomerOrder FOREIGN KEY (OrderID) REFERENCES Orders(OrderID);
  ```
  
### Get all the customers:
  ```sql
  SELECT * FROM Customers;
  ```
  
### Get single customer:
  ```sql
  SELECT * FROM Customers WHERE CustomerID = id;
  ```
 
### Create a customer:
  ```sql
  INSERT INTO Customers (CustomerName, Street, City, State, Zip, Order) VALUES (Parameter1, Parameter2, Parameter3, Parameter4, Parameter5, Parameter6);
  ```

### Update a customer:
  ```sql
  UPDATE Customers SET column = value WHERE CustomerID = id;
  ```
  
### Delete a customer:
  ```sql
  DELETE FROM Customers WHERE CustomerID = id;
  ```

### Get customer's order:
  ```sql
  SELECT * FROM Orders WHERE id in (SELECT Order FROM Customers WHERE Order.OrderID = id);
  ```
 
