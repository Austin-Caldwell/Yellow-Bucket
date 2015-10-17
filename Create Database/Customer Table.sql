/* Austin Caldwell and Evan Wehr */
-- Updated 10/17/2015

USE YellowBucketCSC365
GO

CREATE TABLE Customer -- Create a table of customers
(
	customerID int PRIMARY KEY IDENTITY(0000,1) NOT NULL,
	firstName varchar(32) NOT NULL,
	lastName varchar(32) NOT NULL,
	email varchar(32) NOT NULL,
	userName varchar(32) UNIQUE NOT NULL,
	userPassword varchar(32) NOT NULL,
	creditCard varchar(19) NOT NULL,
	customerAddressID int CONSTRAINT fk_Customer_CustomerAddress FOREIGN KEY REFERENCES CustomerAddress(customerAddressID) ON DELETE SET NULL
);