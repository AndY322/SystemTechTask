	use SystemTechnologies
	go

	create trigger Departments_INSERT
	on Departments
	after insert 
	as 
	update Departments
	set CreatedOn = getdate()
	from inserted
	where Departments.Id = inserted.Id
	