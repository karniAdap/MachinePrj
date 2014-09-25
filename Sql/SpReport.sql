-- uspReportList '%t%',1,1 
--Select * from mstReport where Name like '
If OBJECT_ID('uspReportList','p') Is not Null
	Drop Proc uspReportList
Go
Create Proc uspReportList
@str nvarchar(50)=null,
@IsActive bit=0,
@IsParent bit=0

As
	Declare @Filter nvarchar(500),@sql nvarchar(600)
	
	Set @Filter =' where 1=1 '
	
	if(@str is not null And @str <> '')
		set @Filter =@Filter +' And Name like '''+@str+''''
	if(@IsActive =1)
		set @Filter =@Filter +' And IsActive =1'
	if(@IsParent =1)
		set @Filter =@Filter +' And IsParent =1'
	
	set @sql = 'Select * From mstReport '+ @Filter+' order by ReportId desc '
	
	Print @sql
	Exec(@sql)
	
Go 

If OBJECT_ID('uspReportDetail','p') Is not Null
	Drop Proc uspReportDetail
Go
Create Proc uspReportDetail
@Id		int
As
Select * From mstReport where ReportId=@Id 
Go  

If OBJECT_ID('uspReportCheckExist','p') Is not Null
	Drop Proc uspReportCheckExist
Go
Create Proc uspReportCheckExist
@Name		Nvarchar(50),
@Id			Int=null

As
if(@Id is Not null or @Id > 0)
Begin
	if Exists(Select 'x' From mstReport where Name=@Name and ReportId <>@Id)
		Select 1
	else
		Select 0			
End
else
Begin
	if Exists(Select 'x' From mstReport where Name=@Name)
		Select 1
	else
		Select 0			
End
Go  


If OBJECT_ID('uspReportEdit','p') Is not Null
	Drop Proc uspReportEdit
Go
Create Proc uspReportEdit
@Id			int,
@Name		nvarchar(50),
@Desc		nvarchar(50),
@PageUrl	nvarchar(500),
@IsParent	bit,
@Parent		int,
@IsActive	bit

As
	if(@Id >0)
	Begin
		Update mstReport set Name=@Name, Description=@Desc, PageUrl =@PageUrl, IsParent=@IsParent,Parent=@Parent, IsActive= @IsActive where ReportId= @Id
	End
	Else
	Begin
		Insert into mstReport (Name, Description, PageUrl, IsParent,Parent,IsActive, CreateDate) Values(@Name,@Desc,@PageUrl,@IsParent,@Parent,@IsActive, GETDATE())
	ENd
Go 


If OBJECT_ID('uspReportDelete','p') Is not Null
	Drop Proc uspReportDelete
Go
Create Proc uspReportDelete
@Id		int
As
	Delete mstReport where ReportId=@Id
Go 
