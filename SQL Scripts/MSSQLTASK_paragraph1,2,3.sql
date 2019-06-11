
use SystemTechnologies
go 

create table Clients
(
	Id int identity(1,1) primary key,
	Name varchar(50) not null,
	Address varchar(100)
)

create table Accounts 
(
	Id int identity(1,1) primary key,
	Number varchar(50) NOT NULL,
	Currency varchar(50) NOT NULL,
	CreatedOn datetime,
	ClosedOn datetime,
	CurrentBalance decimal,
	ClientId int,
	constraint FK_AccountClient foreign key(ClientId)
	references Clients(Id),
)


use SystemTechnologies
go

	create trigger Accounts_INSERT
	on Accounts
	after insert 
	as 
	update Accounts
	set CreatedOn = getdate()
	from inserted
	where Accounts.Id = inserted.Id
	