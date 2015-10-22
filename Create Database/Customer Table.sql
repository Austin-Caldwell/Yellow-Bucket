/* Austin Caldwell and Evan Wehr */
-- Updated 10/21/2015

USE YellowBucketCSC365
GO

CREATE TABLE Customer -- Create a table of customers
(
	customerID int PRIMARY KEY IDENTITY(0000,1) NOT NULL,
	firstName varchar(32) NOT NULL,
	lastName varchar(32) NOT NULL,
	email varchar(32) NOT NULL,
	alternateEmail varchar(32) NULL,
	userName varchar(32) UNIQUE NOT NULL,
	userPassword varchar(32) NOT NULL,
	creditCard varchar(19) NULL,	-- Customer may create account online, but not have credit card information saved until he/she makes a first rental.  Also, customer may opt to not have credit card saved in the system
	customerAddressID int CONSTRAINT fk_Customer_CustomerAddress FOREIGN KEY REFERENCES CustomerAddress(customerAddressID) ON DELETE SET NULL
);