If(OBJECT_ID('Users','U') Is not Null)
	Drop Table Users
Go 
Create Table Users
(
	UserId			int Identity(1,1) Primary Key,
	UserName		nvarchar(50) Unique,
	Pass			nvarchar(200),
	FirstName		nvarchar(50),
	LastName		nvarchar(50),
	Email			nvarchar(100) unique,
	IsAdmin			Bit Default 0,
	CreateDate		Date
)
Go
 

insert into Users(UserName,Pass,FirstName, LastName, Email, IsAdmin, CreateDate) values('admin','admin123', 'Billy', ' ','admin@gmail.com',1, GETDATE() ) 

If(OBJECT_ID('ForgotPassword','U') Is not Null)
 Drop Table ForgotPassword
Go
Create Table ForgotPassword
(
 Id  int Identity(1,1) Primary key,
 UserID  int not null,
 Message nvarchar(500) null
 --constraint fk_UserId Foreign key (UserID) references Users(UserId)
)
Go

If(OBJECT_ID('Equipments','U') Is not Null)
	Drop Table Equipments
Go
Create Table Equipments
(
	EquipmentId		int Identity(1,1) Primary Key,
	Name			nvarchar(50) Unique,
	Value			nvarchar(100),
	EqType			varchar(20),
	CreateDate		Date
)
Go

 
If(OBJECT_ID('Role','U') Is not Null)
	Drop Table Role
Go
 
Create Table Role
(
	RoleId			int Identity(1,1) Primary Key,
	Name			nvarchar(50) Unique	
)
Go

If(OBJECT_ID('AdminRole','U') Is not Null)
	Drop Table AdminRole
Go
 
Create Table AdminRole
(
	RoleId			int,
	AdminId			int
	
	Primary key(AdminId, RoleId),
	Constraint Fk_AdminRole_RoleId Foreign Key (RoleId) References [Role](RoleId),
	 
)
Go 


If(OBJECT_ID('Settings','U') Is not Null)
	Drop Table Settings
Go
 
Create Table Settings
(
	Id				int,
	Email			nvarchar(100),
	SMTP			varchar(100),
	Port			varchar(100),
	LabourRate		varchar(100)
)
Go


If(OBJECT_ID('PlanHireMachine','U') Is not Null)
	Drop Table PlanHireMachine
Go
 
Create Table PlanHireMachine
(
	Id				int Identity(1,1) Primary key,
	HireDate		Date,
	DocketNo		int,
	StartHour		Decimal(6,2),
	FinishHour		Decimal(6,2),
	Hours			Decimal(6,2),
	Plant			int,
	Wet				Decimal(6,2),
	Nett			Decimal(6,2)
)
Go

If(OBJECT_ID('PlanHireLabour','U') Is not Null)
	Drop Table PlanHireLabour
Go
 
Create Table PlanHireLabour
(
	Id				int Identity(1,1) Primary key,
	HireDate		Date,
	Name			Varchar(100),
	Description		Varchar(500),
	StartHour		Decimal(6,2),
	FinishHour		Decimal(6,2),
	Plant			int,
	Total			Decimal(6,2)
)
Go




--Select 'If(OBJECT_ID('''+Name +''',''U'') Is not Null) Drop Table '+ name from sys.Tables

