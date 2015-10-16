/* Austin Caldwell and Evan Wehr */
-- Updated 10/16/2015

USE YellowBucketCSC365
GO

CREATE TABLE Customer -- Create a table of customers
(
	customerID int PRIMARY KEY IDENTITY(0000,1) NOT NULL,
	name varchar(32) NOT NULL,
	email varchar(32) NOT NULL,
	userName varchar(32) NOT NULL,
	userPassword varchar(24) NOT NULL,
	creditCard int CONSTRAINT creditCard_LengthCC CHECK(creditCard = 16) NOT NULL,
	customerAddressID int CONSTRAINT fk_Customer_CustomerAddress FOREIGN KEY REFERENCES CustomerAddress(customerAddressID) ON DELETE SET NULL
);