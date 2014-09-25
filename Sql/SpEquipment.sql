
If OBJECT_ID('uspEquipmentList','p') Is not Null
	Drop Proc uspEquipmentList
Go
-- uspEquipmentList 'Vehicle'
Create Proc uspEquipmentList
@EqType		varchar(20),
@str		nvarchar(50) =null
As
if(@str is not null And @str <> '')
	Select * From Equipments WHERE EqType= @EqType and (Name  like @str or Value like @str) order by EquipmentId desc
else
	Select * From Equipments WHERE EqType= @EqType order by EquipmentId desc
Go 

If OBJECT_ID('uspEquipmentDetail','p') Is not Null
	Drop Proc uspEquipmentDetail
Go
Create Proc uspEquipmentDetail
@Id		int
As
	Select * From Equipments where EquipmentId=@Id 
Go  

If OBJECT_ID('uspEquipmentCheckExist','p') Is not Null
	Drop Proc uspEquipmentCheckExist
Go
Create Proc uspEquipmentCheckExist
@Name		Nvarchar(50),
@Id			Int=null

As
if(@Id is Not null or @Id > 0)
Begin
	if Exists(Select 'x' From Equipments where Name=@Name and EquipmentId <>@Id)
		Select 1
	else
		Select 0			
End
else
Begin
	if Exists(Select 'x' From Equipments where Name=@Name)
		Select 1
	else
		Select 0			
End
Go  


If OBJECT_ID('uspEquipmentEdit','p') Is not Null
	Drop Proc uspEquipmentEdit
Go
Create Proc uspEquipmentEdit
@Id			int,
@Name		nvarchar(50),
@Value		nvarchar(50),
@EqType		varchar(20)

As
	if(@Id >0)
	Begin
		Update Equipments set Name=@Name, Value=@Value where EquipmentId= @Id
	End
	Else
	Begin
		Insert into Equipments (Name, Value, EqType, CreateDate) Values(@Name,@Value, @EqType, GETDATE())
	ENd
Go 


If OBJECT_ID('uspEquipmentDelete','p') Is not Null
	Drop Proc uspEquipmentDelete
Go
Create Proc uspEquipmentDelete
@Id		int
As
	Delete Equipments where EquipmentId=@Id
Go  