/* CREATE THE ENTIRE YellowBucketCSC365 DATABASE, AND CREATE/LINK ALL TABLES */ /* Austin Caldwell and Evan Wehr */
-- Updated 11/18/2015

-- Create the database itself
Use master
IF DB_ID('YellowBucketCSC365') is not null  -- Code replicated from a suggestion by http://stackoverflow.com/users/9823/eduardo
	BEGIN								    -- If the database already exists, drop the entire database and recreate it.
		DROP DATABASE YellowBucketCSC365;
		CREATE DATABASE YellowBucketCSC365;
	END;
ELSE										-- If the database did not already exist, create the database.
	CREATE DATABASE YellowBucketCSC365;
GO

-- Create all database tables
USE YellowBucketCSC365
GO

CREATE TABLE Movie -- Create a table of movies
(
	movieID int PRIMARY KEY IDENTITY(0000,1) NOT NULL,
	title varchar(64) NOT NULL,
	movieDescription varchar(256) NOT NULL,
	director varchar(32) NOT NULL,
	studio varchar(32) NOT NULL,
	runTime int CONSTRAINT runTime_CC Check(runTime >= 0) NOT NULL,
	parentalRating varchar(8) NOT NULL,
	genre varchar(32) NOT NULL,
	releaseDate date NOT NULL,
	coverPhoto varbinary(max) NULL
);

CREATE TABLE CustomerAddress -- Create a table of customers' addresses
(
	customerAddressID int PRIMARY KEY IDENTITY(0000,1) NOT NULL,
	addressLine1 varchar(32) NOT NULL,
	addressLine2 varchar(32) NULL,
	city varchar(32) NOT NULL,
	stateProvince varchar(32) NOT NULL,
	postalCode varchar(16) NOT NULL
);

CREATE TABLE Customer -- Create a table of customers
(
	customerID int PRIMARY KEY IDENTITY(0000,1) NOT NULL,
	firstName varchar(32) NOT NULL,
	lastName varchar(32) NOT NULL,
	email varchar(32) NOT NULL,
	alternateEmail varchar(32) NULL,
	userName varchar(32) UNIQUE NOT NULL,
	userPassword varchar(64) NOT NULL,
	creditCard varchar(64) NULL,	-- Customer may create account online, but not have credit card information saved until he/she makes a first rental.  Also, customer may opt to not have credit card saved in the system
	customerAddressID int CONSTRAINT fk_Customer_CustomerAddress FOREIGN KEY REFERENCES CustomerAddress(customerAddressID) ON DELETE CASCADE
);

CREATE TABLE MovieReview -- Create a table of movie reviews
(
	reviewID int PRIMARY KEY IDENTITY(0000,1) NOT NULL,
	datePosted date CONSTRAINT datePosted_Default DEFAULT GetDate() NOT NULL,
	reviewDescription varchar(256) NULL,
	rating int CONSTRAINT rating_Default DEFAULT 0 CONSTRAINT rating_CC CHECK(rating >= 0 AND rating <= 5) NOT NULL,
	customerID int CONSTRAINT fk_MovieReview_Customer FOREIGN KEY REFERENCES Customer(customerID) ON DELETE CASCADE NOT NULL,
	movieID int CONSTRAINT fk_MovieReview_Movie FOREIGN KEY REFERENCES Movie(movieID) ON DELETE CASCADE NOT NULL,
);

CREATE TABLE Wish -- Create a table linking customers to the movies they wish for
(
	wishID int PRIMARY KEY IDENTITY(0000,1) NOT NULL,
	customerID int CONSTRAINT fk_Wish_Customer FOREIGN KEY REFERENCES Customer(customerID) ON DELETE CASCADE NOT NULL,
	movieID int CONSTRAINT fk_Wish_Movie FOREIGN KEY REFERENCES Movie(movieID) ON DELETE CASCADE NOT NULL,
	dateWished datetime CONSTRAINT dateWished_Default DEFAULT GetDate() NOT NULL -- Pull the current date and time and record when the wish was posted
);

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

CREATE TABLE Rental -- Create a table to hold information on current rentals held by a particular customer
(
	rentalID int PRIMARY KEY IDENTITY(0000,1) NOT NULL,
	rentalCost smallmoney CONSTRAINT rentalCost_Default DEFAULT $1.00 CONSTRAINT rentalCost_CC CHECK(rentalCost >= 0) NOT NULL,
	dateRented datetime CONSTRAINT dateRented_Default DEFAULT GetDate() NOT NULL,
	dateReturned datetime NULL, -- dateReturned will be NULL until the customer returns the movie
	customerID int CONSTRAINT fk_Rental_Customer FOREIGN KEY REFERENCES Customer(customerID) ON DELETE SET NULL,
	stockID int CONSTRAINT fk_Rental_Inventory FOREIGN KEY REFERENCES Inventory(stockID) ON DELETE SET NULL,
);

CREATE TABLE RentalHistory -- Create a table to hold a record/history of all rentals performed by a particular customer
(
	historyID int PRIMARY KEY IDENTITY(0000,1) NOT NULL,
	customerID int CONSTRAINT fk_History_Customer FOREIGN KEY REFERENCES Customer(customerID) ON DELETE CASCADE NOT NULL,
	movieID int CONSTRAINT fk_History_Movie FOREIGN KEY REFERENCES Movie(movieID) ON DELETE SET NULL,
	outDate datetime NOT NULL, 
	inDate datetime NULL
);