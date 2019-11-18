CREATE TABLE [dbo].[JusTreatment]
(
	Date Date,
	Notes varchar(50),
	PaidPrice money,
	ProcedureID int,
	PetName varchar(50),
	OwnerID int,

	Primary Key (Date, ProcedureID, PetName, OwnerID),
	Foreign Key (ProcedureID) References JusProcedure,
	Foreign Key (PetName, OwnerID) References JusPet,



)
