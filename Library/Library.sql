create database Library
create table Users
(
Id int Identity(1,1) primary key,
Username nvarchar(10) not null unique,
Password nvarchar(10) not null,
CanCreateBook bit ,
CanCreateUser bit,
CanCreateBranch bit,
CanCreateCustomer bit,
CanRent bit,
);
create table Branchs
(
Id int Identity(1,1) primary key  ,
Name nvarchar(20)  not  null,
Address nvarchar(20) not null,
unique(Name,Address),
)
create table Customers
(
Id int Identity(1,1) primary key ,
Name nvarchar(20) not null,
Surname nvarchar(20) not null,
Data Date not null,
)
create table Workers
(
Id int Identity(1,1) primary key ,
Name nvarchar(20) not null,
Surname nvarchar(20) not null,
Phone int  ,
Salary float,
BranchName nvarchar Foreign key references Branchs(Name) ,
)


create table Books
(
Id int Identity(1,1) primary key ,
Name nvarchar(20) not null,
Author nvarchar(20) not null,
BuyPrice float not null,
SalePrice float not null,
Count int not null,
BranchId int foreign key references Branchs(Id) ,
)
create table SaleBooks
(
Id int Identity(1,1) primary key ,
BookId int foreign key references Books(Id) not null,
CustomerId int foreign key references Customers(Id) not null,
SalePrice float not null ,
UserId int foreign key references Users(Id),
Date Date not null,
Note text not null
) 

create table RentBooks
(
Id int Identity(1,1) primary key ,
BookId int foreign key references Books(Id) not null,
CustomerId int foreign key references Customers(Id) not null,
RentDate Date not null,
Deadline Date not null,
RealDate Date ,
DailyRentPrice float not null,
)
insert into Branchs(Name,Address)
values('Xetai','Xetai A74'),
('Yasamal','Yasamal77')

insert into Books(Name,Author,SalePrice,BuyPrice,Count,BranchId)
values('Ag atli Gede','Kele Sair',10,9,100,1)
