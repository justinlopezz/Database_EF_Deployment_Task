CREATE TABLE [dbo].[JusPet]
(
	[PetName] VARCHAR(50) NOT NULL, 
    [Type] VARCHAR(50) NOT NULL, 

    [OwnerID] INT NOT NULL FOREIGN KEY REFERENCES JusCustomer,

	PRIMARY KEY ([PetName], [OwnerID])
)
