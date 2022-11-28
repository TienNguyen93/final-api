create database CustomerOrder;
use customerorder;

create table customers (
	CustomerID int not null auto_increment,
	CustomerName varchar(255) not null,
	Street varchar(255) not null,
    City varchar(255) not null, 
    State varchar(255) not null, 
    Zip varchar(255) not null, 
    Primary Key (CustomerID)
);

create table orders (
	OrderID int not null auto_increment,
    OrderDate varchar(255) not null,
    ShipDate varchar(255) not null,
    IsShipped boolean not null,
    primary key (OrderID)
);

alter table customers add column OrderID int;

alter table customers add constraint FK_CustomerOrder foreign key (OrderID)
references orders(OrderID);

-- get all the customers
select * from customers;

-- get single customer
select * from customers where CustomerID = id;

-- create a customer
insert into customers (CustomerName, Street, City, State, Zip, Order) values (Parameter1, 
Parameter2, Parameter3, Parameter4, Parameter5, Parameter6);

-- update a customer
update customers set columnn = value where CustomerID = id;

-- delete a customer
delete from customers where CustomerID = id;

-- get customer's order
select * from orders where id in (select Order from customers where Order.OrderID = id);





