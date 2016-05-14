/* Austin Caldwell and Evan Wehr */
-- Updated 10/16/2015

USE YellowBucketCSC365
GO

CREATE TABLE CustomerAddress -- Create a table of customers' addresses
(
	customerAddressID int PRIMARY KEY IDENTITY(0000,1) NOT NULL,
	addressLine1 varchar(32) NOT NULL,
	addressLine2 varchar(32) NULL,
	city varchar(32) NOT NULL,
	stateProvince varchar(32) NOT NULL,
	postalCode varchar(16) NOT NULL
);