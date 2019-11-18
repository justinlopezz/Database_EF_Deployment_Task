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

Insert into JusCustomer (OwnerID, FirstName, Surname, Phone) Values
(1, 'Frank', 'Sinatra', 400111222),
(2, 'Duke', 'Ellington', 400222333),
(3, 'Ella', 'Fitzgerald', 400333444);

Insert into JusPet (PetName, Type, OwnerID) Values
('Buster', 'Dog', 1),
('Fluffy', 'Cat', 1),
('Stew', 'Rabbit', 2),
('Pooper', 'Dog', 3),
('Buster', 'Dog', 3);
