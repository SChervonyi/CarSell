use CarSell

/* Manufactures table begin */
SET IDENTITY_INSERT Manufacturers ON

delete from Manufacturers
insert into Manufacturers(Id, Code, Name) values 
	(1, 'MITSUBISHI', 'Mitsubishi Motors')
	,(2, 'SHKODA', 'Shkoda Auto')
	,(3, 'HONDA', 'Honda Motor')

SET IDENTITY_INSERT Manufacturers OFF
/* Manufactures table end */
-------------------------------------
/* Cars table begin */
SET IDENTITY_INSERT Cars ON

truncate table Cars
insert into Cars(Id, ManufacturerId, Code, Name, Price) values 
	(1, 1, 'LANCER', 'Lancer X', 20000.77)
	,(2, 1, 'ASX', 'ASX', 30000)
	,(3, 1, 'PJSP', 'Pajero Sport', 42000)
	,(4, 2, 'OCT', 'Octavia A5', 25000)

SET IDENTITY_INSERT Cars OFF
/* Cars table end */
------------------------------------
/* Cars table begin */
SET IDENTITY_INSERT Equipments ON

truncate table Equipments
insert into Equipments(Id, Name, Rate) values 
	(1, 'None', 1)
	,(2, 'Standart', 1.1)
	,(3, 'Comfort', 1.3)

SET IDENTITY_INSERT Equipments OFF
/* Cars table end */