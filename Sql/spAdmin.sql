
If OBJECT_ID('uspAdminList','p') Is not Null
	Drop Proc uspAdminList
Go
Create Proc uspAdminList
@str nvarchar(50) =null
As
if(@str is not null And @str <> '')
	Select * From mstAdmin where AdminName like @str or FirstName like @str or LastName like @str order by AdminId desc
else
	Select * From mstAdmin order by AdminId desc
Go 

 If OBJECT_ID('uspAdminLogin','p') Is not Null
	Drop Proc uspAdminLogin
Go
Create Proc uspAdminLogin
@AdminName		nvarchar(50),
@Pass		nvarchar(50)
As
	select * from mstAdmin where AdminName=@AdminName and Pass=@Pass
Go 

 If OBJECT_ID('uspAdminDetail','p') Is not Null
	Drop Proc uspAdminDetail
Go
Create Proc uspAdminDetail
@AdminId		int
As
	Select * From mstAdmin where AdminId =@AdminId
Go 

If OBJECT_ID('uspAdminRole','p') Is not Null
	Drop Proc uspAdminRole
Go
Create Proc uspAdminRole
As
	Select a.AdminId, a.AdminName, 
	case when (Select RoleId from AdminRole where RoleId=1 and AdminId= a.AdminId) is null then 0 else 1 end IsAdmin,
	case when (Select RoleId from AdminRole where RoleId=2 and AdminId= a.AdminId) is null then 0 else 1 end IsTrail
	from mstAdmin a 

Go

If OBJECT_ID('uspAdminEdit','p') Is not Null
	Drop Proc uspAdminEdit
Go
Create Proc uspAdminEdit
@AdminId		int,
@AdminName	nvarchar(50),
@Pass		nvarchar(50),
@FirstName	nvarchar(50),
@LastName	nvarchar(50),
@Email		nvarchar(50)

As
	if(@AdminId >0)
	Begin
		Update mstAdmin set FirstName=@FirstName, LastName= @LastName, Email=@Email where AdminId= @AdminId
	End
	Else
	Begin
		Insert into mstAdmin (AdminName, Pass, FirstName, LastName,Email, CreateDate) Values(@AdminName,@Pass, @FirstName, @LastName, @Email, GETDATE())
	ENd
Go 

If OBJECT_ID('uspAdminDelete','p') Is not Null
	Drop Proc uspAdminDelete
Go
Create Proc uspAdminDelete
@AdminId		int
As
 Delete AdminRole where AdminId=@AdminId
 Delete mstAdmin where AdminId=@AdminId
Go 

If OBJECT_ID('uspAdminPasswordChange','p') Is not Null
 Drop Proc uspAdminPasswordChange
Go
Create Proc uspAdminPasswordChange
@AdminName  nvarchar(50),
@NewPass  nvarchar(50),
@OldPass  nvarchar(50)
As
  Declare @Admin nvarchar(50)
  Select  @Admin=AdminName from mstAdmin where AdminName =@AdminName and Pass=@OldPass
 if(@Admin is not null)
 Begin
   Update mstAdmin set Pass=@NewPass where AdminName=@AdminName
   select 1
 End
 else
  select 0
Go

If OBJECT_ID('uspAdminCheckExist','p') Is not Null
	Drop Proc uspAdminCheckExist
Go
Create Proc uspAdminCheckExist
@Name		Nvarchar(50),
@Id			Int=null

As
if(@Id is Not null or @Id > 0)
Begin
	if Exists(Select 'x' From mstAdmin where AdminName=@Name and AdminId<>@Id)
		Select 1
	else
		Select 0			
End
else
Begin
	if Exists(Select 'x' From mstAdmin where AdminName=@Name)
		Select 1
	else
		Select 0			
End
Go  

If OBJECT_ID('uspAdminEmailCheck','p') Is not Null
 Drop Proc uspAdminEmailCheck 
Go
Create Proc uspAdminEmailCheck
@Email			nvarchar(200),
@AdminId		int = null

As
if(@AdminId is not null)
	 Select AdminId From mstAdmin where Email=@Email and AdminId <> @AdminId
else
	 Select AdminId From mstAdmin where Email=@Email 
Go
