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







