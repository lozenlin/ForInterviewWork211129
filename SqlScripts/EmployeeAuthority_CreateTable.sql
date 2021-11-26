use ForInterviewWork2021
go

----------------------------------------------------------------------------
-- dbo.Department �������
----------------------------------------------------------------------------
create table dbo.Department (
	DeptId	int	Not Null	identity primary key
	,DeptName	nvarchar(50)	Not Null
	,SortNo	int		
	,PostAccount	varchar(20)		
	,PostDate	datetime		
	,MdfAccount	varchar(20)		
	,MdfDate	datetime		
)
go

-- �����W�ٳ]�w�ߤ@��
create unique index UIX_Department on dbo.Department(DeptName)
go

--�w�]���e
set identity_insert dbo.Department on
insert into dbo.Department (DeptId, DeptName, SortNo, PostAccount, PostDate)
	values (1, N'Default', 10, 'admin', getdate())

set identity_insert dbo.Department off
go

----------------------------------------------------------------------------
-- dbo.EmployeeRole ���u����	
----------------------------------------------------------------------------
create table dbo.EmployeeRole (
	RoleId	int	Not Null	identity primary key
	,RoleName	nvarchar(20)	Not Null
	,RoleDisplayName	nvarchar(20)	
	,SortNo	int	
	,PostAccount	varchar(20)	
	,PostDate	datetime	
	,MdfAccount	varchar(20)	
	,MdfDate	datetime	
)
go

-- �����W�ٳ]�w�ߤ@��
create unique index UIX_EmployeeRole on dbo.EmployeeRole(RoleName)
go

-- �w�]���e
set identity_insert dbo.EmployeeRole on
insert into dbo.EmployeeRole (RoleId, RoleName, RoleDisplayName, SortNo, PostAccount, PostDate)
	values (1, N'admin', N'�t�κ޲z��', 10, 'admin', getdate())
insert into dbo.EmployeeRole (RoleId, RoleName, RoleDisplayName, SortNo, PostAccount, PostDate)
	values (2, N'user', N'�ϥΪ�', 20, 'admin', getdate())

set identity_insert dbo.EmployeeRole off
go

----------------------------------------------------------------------------
-- dbo.Employee ���u���	
----------------------------------------------------------------------------
create table dbo.Employee (
	EmpId	int	Not Null	identity primary key
	,EmpAccount	varchar(20)	Not Null	
	,EmpPassword	varchar(128)	Not Null	
	,EmpName	nvarchar(50)		
	,Email	varchar(100)		
	,Remarks	nvarchar(200)		
	,DeptId	int		
	,RoleId	int		
	,IsAccessDenied	bit	Not Null	Default(0)
	,PostAccount	varchar(20)		
	,PostDate	datetime		
	,MdfAccount	varchar(20)		
	,MdfDate	datetime		
)
go

-- foreign key
alter table dbo.Employee with check add constraint FK_Employee_Department foreign key(DeptId) references dbo.Department(DeptId)
go
alter table dbo.Employee check constraint FK_Employee_Department
go

alter table dbo.Employee with check add constraint FK_Employee_EmployeeRole foreign key(RoleId) references dbo.EmployeeRole(RoleId)
go
alter table dbo.Employee check constraint FK_Employee_EmployeeRole
go

-- �b���]�w�ߤ@��
create unique index UIX_Employee on dbo.Employee(EmpAccount)
go
