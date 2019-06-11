use SystemTechnologies
go

create trigger Employees_UPDATE 
on Employees
after update 
as 
update Employees
set ModifiedOn = GETDATE()
from inserted 
where Employees.Id = inserted.Id

