/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
DELETE From JusTreatment;
DELETE From JusProcedure;
DELETE From JusPet;
DELETE From JusCustomer;

Insert into [dbo].[JusCustomer] ([OwnerID], [FirstName], [Surname], [Phone]) Values
(1, 'Frank', 'Sinatra', 400111222),
(2, 'Duke', 'Ellington', 400222333),
(3, 'Ella', 'Fitzgerald', 400333444);

Insert into [dbo].[JusPet] ([PetName], [Type], [OwnerID]) Values
('Buster', 'Dog', 1),
('Fluffy', 'Cat', 1),
('Stew', 'Rabbit', 2),
('Pooper', 'Dog', 3),
('Buster', 'Dog', 3);

Insert into [dbo].[JusProcedure] ([ProcedureID], [Description], [Price]) Values
(01, 'Rabies Vaccination', 24.00),
(10, 'Examine and treat wound', 30.00),
(05, 'Heart Worm Test', 25.00),
(08, 'Tetnus Vaccination', 17.00);

Insert into [dbo].[JusTreatment] ([Date], [Notes], [PaidPrice], [OwnerID], [PetName], [ProcedureID]) Values
('2017-6-20', 'Routine Vaccination', 22.00, 1, 'Buster', 01),
('2018-5-15', 'Booster Shot', 24.00, 1, 'Buster', 01),
('2018-5-10', 'Wounds Sustained int apparent cat fight', 30.00, 1, 'Fluffy', 10),
('2017-6-20', 'Routine Vaccination', 22.00, 1, 'Fluffy', 01),
('2018-5-10', 'Wounds sustained suring attempt to cook stew', 30.00, 2, 'Stew', 10),
('2018-5-15', 'Routine Vaccination', 24.00, 2, 'Stew', 01),
('2018-5-18', 'Routine Test', 25.00, 3, 'Pooper', 05),
('2017-6-20', 'Stepped on a rusty nail', 17.00, 3, 'Buster', 08),
('2017-6-20', 'Routine Vaccination', 22.00, 3, 'Buster', 01);

GO
