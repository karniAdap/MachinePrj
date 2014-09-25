
If OBJECT_ID('uspPlantHireLabourList','p') Is not Null
	Drop Proc uspPlantHireLabourList
Go
-- uspPlantHireLabourList 'Vehicle'
Create Proc uspPlantHireLabourList
@str		nvarchar(50) =null
As
if(@str is not null And @str <> '')
	Select * From PlantHireLabours WHERE Name  like @str order by PlantHireLabourId desc
else
	Select * From PlantHireLabours order by PlantHireLabourId desc
Go 

If OBJECT_ID('uspPlantHireLabourDetail','p') Is not Null
	Drop Proc uspPlantHireLabourDetail
Go
Create Proc uspPlantHireLabourDetail
@Id		int
As
	Select * From PlantHireLabours where PlantHireLabourId=@Id 
Go  
 

If OBJECT_ID('uspPlantHireLabourEdit','p') Is not Null
	Drop Proc uspPlantHireLabourEdit
Go
Create Proc uspPlantHireLabourEdit
@Id				int,
@Name			nvarchar(100),
@HireDate		DateTime,
@Description	varchar(500),
@StartHour		decimal,
@FinishHour		decimal,
@Total			decimal 
As
	if(@Id >0)
	Begin
		Update PlantHireLabours set HireDate=@HireDate, Name=@Name, Description=@Description, 
		StartHour=@StartHour,FinishHour=@FinishHour, Total=@Total where PlantHireLabourId= @Id
	End
	Else
	Begin
		Insert into PlantHireLabours (HireDate,Name,Description,StartHour,FinishHour,Total,CreateDate)
		 Values(@HireDate,@Name,@Description,@StartHour,@FinishHour,@Total, GETDATE())
	ENd
Go 


If OBJECT_ID('uspPlantHireLabourDelete','p') Is not Null
	Drop Proc uspPlantHireLabourDelete
Go
Create Proc uspPlantHireLabourDelete
@Id		int
As
	Delete PlantHireLabours where PlantHireLabourId=@Id
Go  