use SystemTechnologies 
go 

	create trigger Departments_UPDATE
	on Departments
	after update
	as 
	update Departments
	set ModifiedOn = getdate()
	from inserted
	where Departments.id = inserted.Id