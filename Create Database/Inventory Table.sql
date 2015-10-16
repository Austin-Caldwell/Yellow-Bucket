/* Austin Caldwell and Evan Wehr */
-- Updated 10/16/2015

USE YellowBucketCSC365
GO

CREATE TABLE Inventory -- Create a table holding the inventory of each individual kiosk
(
	stockID int PRIMARY KEY IDENTITY(0000,1) NOT NULL,
	dvdBluRay varchar(8) NOT NULL,
	movieID int CONSTRAINT fk_Inventory_Movie FOREIGN KEY REFERENCES Movie(movieID) ON DELETE CASCADE NOT NULL,
	kioskID int CONSTRAINT fk_Inventory_Kiosk FOREIGN KEY REFERENCES Kiosk(kioskID) ON DELETE SET NULL
);