
If OBJECT_ID('uspUserList','p') Is not Null
	Drop Proc uspUserList
Go
Create Proc uspUserList
@IsAdmin	Bit,
@str		nvarchar(50) =null
As
if(@str is not null And @str <> '')
	Select * From Users where IsAdmin=@IsAdmin And UserName like @str or FirstName like @str or LastName like @str order by UserId desc
else
	Select * From Users where IsAdmin=@IsAdmin order by UserId desc
Go 

If OBJECT_ID('uspUserDetail','p') Is not Null
	Drop Proc uspUserDetail
Go
Create Proc uspUserDetail
@UserId		int
As
	Select * From Users where UserId=@UserId
Go  

If OBJECT_ID('uspUserLogin','p') Is not Null
	Drop Proc uspUserLogin
Go
Create Proc uspUserLogin
@Name		Nvarchar(50),
@Pass		nvarchar(50)

As
if Exists(Select 'x' From Users where UserName=@Name and Convert(binary, Pass) =CONVERT(binary,@Pass))
	Select * From Users where UserName=@Name and Convert(binary, Pass) =CONVERT(binary,@Pass)

Go  

If OBJECT_ID('uspUserCheckExist','p') Is not Null
	Drop Proc uspUserCheckExist
Go
Create Proc uspUserCheckExist
@Name		Nvarchar(50),
@Id			Int=null

As
if(@Id is Not null or @Id > 0)
Begin
	if Exists(Select 'x' From Users where UserName=@Name and UserId <>@Id)
		Select 1
	else
		Select 0			
End
else
Begin
	if Exists(Select 'x' From Users where UserName=@Name)
		Select 1
	else
		Select 0			
End
Go  


If OBJECT_ID('uspUserEdit','p') Is not Null
	Drop Proc uspUserEdit
Go
Create Proc uspUserEdit
@UserId		int,
@UserName	nvarchar(50),
@Pass		nvarchar(50),
@FirstName	nvarchar(50),
@LastName	nvarchar(50),
@Email		nvarchar(50),
@IsAdmin	Bit

As
	if(@UserId >0)
	Begin
		Update Users set FirstName=@FirstName, LastName= @LastName, Email=@Email where UserId= @UserId
	End
	Else
	Begin
		Insert into Users (UserName, Pass, FirstName, LastName,Email, IsAdmin, CreateDate) Values(@UserName,@Pass, @FirstName, @LastName, @Email,@IsAdmin, GETDATE())
	ENd
Go 


If OBJECT_ID('uspUserDelete','p') Is not Null
	Drop Proc uspUserDelete
Go
Create Proc uspUserDelete
@UserId		int
As
 Delete mstForgotPassword where UserID=@UserId
 Delete tblUserGroup where UserId =@UserId
 Delete Users where UserId=@UserId
Go 
   
If OBJECT_ID('uspUserEmailCheck','p') Is not Null
 Drop Proc uspUserEmailCheck 
Go
Create Proc uspUserEmailCheck
@UserEmail  nvarchar(200),
@UserId		int = null

As
if(@UserId is not null)
	 Select UserId From Users where Email=@UserEmail and UserId <> @UserId
else
	 Select UserId From Users where Email=@UserEmail 
Go


If OBJECT_ID('uspFGPassCheckExist','p') Is not Null
 Drop Proc uspFGPassCheckExist
Go
Create Proc uspFGPassCheckExist
@Email nvarchar(100)
As
	if Exists(Select 'x' from Users where Email=@Email)
	Begin
		if Exists(select 'x' from mstForgotPassword where UserID = (select UserId from Users where Email=@Email))
			Select 2
		else
			select 0
	End
	else
		Select 1
	
Go
 
If OBJECT_ID('uspFGPassAdd','p') Is not Null
 Drop Proc uspFGPassAdd
Go
Create Proc uspFGPassAdd
@Email nvarchar(100),
@Message  nvarchar(500)
As
	Declare @Userid int
	Select @Userid = UserId from Users where Email =@Email
	if(@Userid is not null)
	Begin
		if exists(Select 'x' from mstForgotPassword where UserID =@Userid)
			select 0
		else
			Insert into mstForgotPassword(UserID,Message) Values(@UserId,@Message)
	End
	else
		select -1
Go 

If OBJECT_ID('uspFGPassList','p') Is not Null
 Drop Proc uspFGPassList
Go
Create Proc uspFGPassList
@str		nvarchar(50)=null
As
	if(@str is not null And @str <> '')
		Select u.UserID,u.UserName ,u.Email,f.Message From mstForgotPassword f inner join Users u on f.UserID =u.UserId  where UserName like @str or Email like @str
	else
		Select u.UserID,u.UserName ,u.Email,f.Message From mstForgotPassword f inner join Users u on f.UserID =u.UserId  
Go
 
 If OBJECT_ID('uspUserPasswordUpdate','p') Is not Null
	Drop Proc uspUserPasswordUpdate
Go
Create Proc uspUserPasswordUpdate
@UserId		int,
@Pass		nvarchar(50)
As
	 Update Users set Pass=@Pass where UserId= @UserId
	 Delete mstForgotPassword where UserID =@UserId
Go 


 If OBJECT_ID('uspUserChangePassword','p') Is not Null
	Drop Proc uspUserChangePassword
Go
Create Proc uspUserChangePassword
@UserId			int,
@OldPass		nvarchar(50),
@NewPass		nvarchar(50)

As
	if Exists(Select 'x' from Users where UserId=@UserId and  Convert(binary, Pass) =CONVERT(binary,@OldPass))
	Begin
		Update Users set Pass= @NewPass where UserId=@UserId
		Select 1
	End
	else
	Begin
		Select -1
	End
	
Go 
 