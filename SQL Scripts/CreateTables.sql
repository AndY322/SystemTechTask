	Create database SystemTechnologies

	use SystemTechnologies
	go
	
	create table Departments(
		Id int identity(1,1) primary key,
		Name varchar(50),
		CreatedOn DateTime,
		ModifiedOn DateTime
	)

	create table Positions
	(
		Id int identity(1,1) primary key,
		Name varchar(50)
	)

	create table Employees
	(
	Id int identity(1,1) primary key,
	Name varchar(70),
	CreatedOn DateTime NULL,
	ModifiedOn DateTime NULL,
	DateOfEmployment DateTime NULL,
	DepartmentId int,
	PositionId int,
	constraint FK_DepartmentEmployee foreign key(DepartmentId)
	references Departments(Id),
	constraint FK_PositionEmployee foreign key(PositionId)
	references Positions(Id)
	)

	use SystemTechnologies
	go

	insert into Positions (Name)
	values ('Developer')

	insert into Positions (Name)
	values ('Manager')

	insert into Positions (Name)
	values ('DevOps')

	