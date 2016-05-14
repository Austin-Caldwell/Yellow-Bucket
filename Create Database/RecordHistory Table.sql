/* Austin Caldwell and Evan Wehr */
-- Updated 10/16/2015

USE YellowBucketCSC365
GO

CREATE TABLE RentalHistory -- Create a table to hold a record/history of all rentals performed by a particular customer
(
	historyID int PRIMARY KEY IDENTITY(0000,1) NOT NULL,
	customerID int CONSTRAINT fk_History_Customer FOREIGN KEY REFERENCES Customer(customerID) ON DELETE CASCADE NOT NULL,
	movieID int CONSTRAINT fk_History_Movie FOREIGN KEY REFERENCES Movie(movieID) ON DELETE SET NULL,
	outDate datetime NOT NULL, 
	inDate datetime NULL
);