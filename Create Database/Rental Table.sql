/* Austin Caldwell and Evan Wehr */
-- Updated 10/17/2015

USE YellowBucketCSC365
GO

CREATE TABLE Rental -- Create a table to hold information on current rentals held by a particular customer
(
	rentalID int PRIMARY KEY IDENTITY(0000,1) NOT NULL,
	rentalCost smallmoney CONSTRAINT rentalCost_Default DEFAULT $1.00 CONSTRAINT rentalCost_CC CHECK(rentalCost >= 0) NOT NULL,
	dateRented datetime CONSTRAINT dateRented_Default DEFAULT GetDate() NOT NULL,
	dateReturned datetime NULL, -- dateReturned will be NULL until the customer returns the movie
	customerID int CONSTRAINT fk_Rental_Customer FOREIGN KEY REFERENCES Customer(customerID) ON DELETE NO ACTION, -- Raise an error if a customer is deleted from the database while that customer still has a movie on rental
	stockID int CONSTRAINT fk_Rental_Inventory FOREIGN KEY REFERENCES Inventory(stockID) ON DELETE NO ACTION, -- Raise an error if a movie is deleted from the database while a customer still has the movie on rental
);