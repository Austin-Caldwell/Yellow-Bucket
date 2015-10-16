/* Austin Caldwell and Evan Wehr */
-- Updated 10/16/2015

USE YellowBucketCSC365
GO

CREATE TABLE Kiosk -- Create a table holding addresses for each kiosk as well as kiosk location
(
	kioskID int PRIMARY KEY IDENTITY(0000,1) NOT NULL,
	location varchar(32) NULL,
	addressLine1 varchar(32) NOT NULL,
	addressLine2 varchar(32) NULL,
	city varchar(32) NOT NULL,
	stateProvince varchar(32) NOT NULL,
	postalCode varchar(16) NOT NULL
);