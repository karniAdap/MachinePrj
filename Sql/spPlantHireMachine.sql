
If OBJECT_ID('uspPlantHireMachineList','p') Is not Null
	Drop Proc uspPlantHireMachineList
Go
-- uspPlantHireMachineList 'Vehicle'
Create Proc uspPlantHireMachineList
As
	Select p.*,eq.Name PlantName, eq.EquipmentId PlantId From PlantHireMachines p Inner Join Equipments eq on p.PlantHireMachineId= eq.EquipmentId order by p.PlantHireMachineId desc
--else
--	Select * From PlantHireMachines WHERE EqType= @EqType order by PlantHireMachineId desc
Go 

If OBJECT_ID('uspPlantHireMachineDetail','p') Is not Null
	Drop Proc uspPlantHireMachineDetail
Go
Create Proc uspPlantHireMachineDetail
@Id		int
As
	Select p.*,eq.Name PlantName, eq.EquipmentId PlantId From PlantHireMachines p Inner Join Equipments eq on p.PlantHireMachineId= eq.EquipmentId where PlantHireMachineId=@Id 
Go  
 
If OBJECT_ID('uspPlantHireMachineEdit','p') Is not Null
	Drop Proc uspPlantHireMachineEdit
Go
Create Proc uspPlantHireMachineEdit
@Id						int,
@HireDate				Datetime,
@DocketNo				int,
@StartHour				decimal,
@FinishHour				decimal,
@Hours					decimal,
@Plant					int,
@Wet					decimal,	
@Nett					decimal

As
	if(@Id >0)
	Begin
		Update PlantHireMachines set HireDate=@HireDate,DocketNo=@DocketNo,StartHour=@StartHour,FinishHour=@FinishHour,
									Hours=@Hours,Plant=@Plant,Wet=@Wet,Nett=@Nett  where PlantHireMachineId= @Id
	End
	Else
	Begin
		Insert into PlantHireMachines (HireDate,DocketNo,StartHour,FinishHour,Hours,Plant,Wet,Nett,CreateDate)
		 Values(@HireDate,@DocketNo,@StartHour,@FinishHour,@Hours,@Plant,@Wet,@Nett, GETDATE())
	ENd
Go 


If OBJECT_ID('uspPlantHireMachineDelete','p') Is not Null
	Drop Proc uspPlantHireMachineDelete
Go
Create Proc uspPlantHireMachineDelete
@Id		int
As
	Delete PlantHireMachines where PlantHireMachineId=@Id
Go  