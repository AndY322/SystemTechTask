use SystemTechnologies
go

create trigger Employees_INSERT 
on Employees
after insert
as
update Employees
set CreatedOn = getdate()
from inserted 
where Employees.id = inserted.Id