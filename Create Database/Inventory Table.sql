/* Austin Caldwell and Evan Wehr */
-- Updated 10/21/2015

USE YellowBucketCSC365
GO

CREATE TABLE Inventory -- Create a table holding the inventory of each individual kiosk
(
	stockID int PRIMARY KEY IDENTITY(0000,1) NOT NULL,
	dvdBluRay varchar(8) NOT NULL,
	-- Allow one particular stockID to represent multiple copies of a movie at a particular kiosk.  When one is rented, decrement the count by one, and if count = 0 set inStock to "0" ("False")
	quantityAtKiosk int CONSTRAINT quantityAtKiosk_CC Check(quantityAtKiosk >= 0) NOT NULL,
	inStock bit CONSTRAINT inStock_Default DEFAULT 0 NOT NULL,
	movieID int CONSTRAINT fk_Inventory_Movie FOREIGN KEY REFERENCES Movie(movieID) ON DELETE CASCADE NOT NULL,
	kioskID int CONSTRAINT fk_Inventory_Kiosk FOREIGN KEY REFERENCES Kiosk(kioskID) ON DELETE SET NULL
);