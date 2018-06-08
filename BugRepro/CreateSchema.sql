create table Customers(Id int, AddressId1 int, AddressId2 int)
go

create table Addresses(Id int, Label nvarchar(max))
go

insert into Customers(Id, AddressId1, AddressId2)
values (1, NULL, NULL),
       (2, 1, NULL),
       (3, NULL, 2),
       (4, 1, 2)

insert into Addresses(Id, Label)
values (1, 'Address ONE'),
       (2, 'Address TWO')
go