create database Library
create table Users
(
Id int Identity(1,1) primary key,
Username nvarchar(10) not null unique,
Password nvarchar(30) not null,
CanCreateBook bit ,
CanCreateUser bit,
CanCreateBranch bit,
CanCreateCustomer bit,
Presently bit,
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
Phone nvarchar(20) 
)
create table Workers
(
Id int Identity(1,1) primary key ,
Name nvarchar(20) not null,
Surname nvarchar(20) not null,
Phone int  ,
Salary float,
BranchId int Foreign key references Branchs(Id) ,
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
UserId int foreign key references Users(Id),
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
insert into Users(Username,Password,CanCreateBook,CanCreateBranch,CanCreateCustomer,CanCreateUser,CanRent,Presently)
values('Admin','Admin',0,1,0,1,1,0);
insert into Customers(Name,Surname,Data,Phone)
values('Nurullah','Mustafayev','06/15/2019','0559771567')

insert into Workers(Name,Surname,Salary,Phone,BranchId)
values('Nurullah','Mustafayev',10,'0559771567',1)
insert into SaleBooks(BookId,CustomerId,SalePrice,UserId,Date,Note)
values(1,1,10,1,'12/11/2019','ndjansdjas')

insert into RentBooks(BookId,CustomerId,DailyRentPrice,Deadline,RealDate,RentDate,UserId)
values(1,1,100,'06/10/2019','06/10/2019','06/10/2019',1);
