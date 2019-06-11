
use SystemTechnologies
go

insert into Clients (Name, Address)
values('Client1', 'Address1')

insert into Clients (Name, Address)
values('Client2', 'Address2')

insert into Clients (Name, Address)
values('Client3', 'Address3')

insert into Clients (Name, Address)
values('Client3', 'Address3')

insert into Accounts (Number, Currency, ClientId)
values ('1-1', 'someCurr', 1)

insert into Accounts (Number, Currency, ClientId)
values ('2-1', 'someCurr', 2)

insert into Accounts (Number, Currency, ClientId)
values ('3-1', 'someCurr', 3)

insert into Accounts (Number, Currency, ClientId)
values ('1-2', 'someCurr', 1)

select COUNT(c.name) as NumberOfAccounts, c.name
from Clients c
join Accounts a on a.ClientId = c.Id
group by c.name


update Accounts 
set closedOn = getDate()
where number in ('1-1', '2-1')

select c.name from Clients c
where (select count(a.Id) 
from accounts a 
where c.Id = a.ClientId and a.ClosedOn is not null) = 0
group by c.name

update Clients
set name = 'Œ¿Œ –Ó„‡ Ë ÍÓÔ˚Ú‡'
where id = 3

select a.number from Accounts a
join Clients c on c.Id = a.ClientId
where c.name like '%Œ¿Œ%'
group by a.number

select * from Accounts

update Accounts
set CurrentBalance = 0
where Accounts.CurrentBalance is null
and exists (select id from Clients where Accounts.ClientId = Id
and Name like '%Œ¿Œ%')

select a.Number, c.Name from Accounts a
join Clients c on c.Id = a.ClientId
where a.ClosedOn is not null 

create table T1
(
	f1 int
)

create table T2
(
	f1 int
)


select t2.f1 from T1
join t2 on t1.f1 = t2.f1


