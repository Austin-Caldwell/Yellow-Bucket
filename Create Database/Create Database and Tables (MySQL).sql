/* CREATE THE ENTIRE YellowBucketCSC365 DATABASE, AND CREATE/LINK ALL TABLES */ /* Austin Caldwell and Evan Wehr */
-- Updated 12/28/2015 FOR MySQL

-- Create the database itself
CREATE DATABASE YellowBucketCSC365;

USE YellowBucketCSC365;

CREATE TABLE Movie -- Create a table of movies
(
	movieID INTEGER AUTO_INCREMENT PRIMARY KEY NOT NULL,
	title varchar(64) NOT NULL,
	movieDescription varchar(256) NOT NULL,
	director varchar(32) NOT NULL,
	studio varchar(32) NOT NULL,
	runTime int NOT NULL,
    Check(runTime >= 0),
	parentalRating varchar(8) NOT NULL,
	genre varchar(32) NOT NULL,
	releaseDate date NOT NULL,
	coverPhoto varbinary(20000) NULL
);

CREATE TABLE CustomerAddress -- Create a table of customers' addresses
(
	customerAddressID INTEGER AUTO_INCREMENT PRIMARY KEY NOT NULL,
	addressLine1 varchar(32) NOT NULL,
	addressLine2 varchar(32) NULL,
	city varchar(32) NOT NULL,
	stateProvince varchar(32) NOT NULL,
	postalCode varchar(16) NOT NULL
);

CREATE TABLE Customer -- Create a table of customers
(
	customerID INTEGER AUTO_INCREMENT PRIMARY KEY NOT NULL,
	firstName varchar(32) NOT NULL,
	lastName varchar(32) NOT NULL,
	email varchar(32) NOT NULL,
	alternateEmail varchar(32) NULL,
	userName varchar(32) UNIQUE NOT NULL,
	userPassword varchar(64) NOT NULL,
	creditCard varchar(64) NULL,	-- Customer may create account online, but not have credit card information saved until he/she makes a first rental.  Also, customer may opt to not have credit card saved in the system
	customerAddressID int,
    FOREIGN KEY (customerAddressID) REFERENCES CustomerAddress(customerAddressID) ON DELETE CASCADE
);

CREATE TABLE MovieReview -- Create a table of movie reviews
(
	reviewID INTEGER AUTO_INCREMENT PRIMARY KEY NOT NULL,
	datePosted datetime DEFAULT NOW() NOT NULL,
	reviewDescription varchar(256) NULL,
	rating int DEFAULT 0 NOT NULL,
    CHECK(rating >= 0 AND rating <= 5),
	customerID int NOT NULL,
    FOREIGN KEY (customerID) REFERENCES Customer(customerID) ON DELETE CASCADE,
	movieID int NOT NULL,
    FOREIGN KEY (movieID) REFERENCES Movie(movieID) ON DELETE CASCADE
);

CREATE TABLE Wish -- Create a table linking customers to the movies they wish for
(
	wishID INTEGER AUTO_INCREMENT PRIMARY KEY NOT NULL,
	customerID int NOT NULL,
    FOREIGN KEY (customerID) REFERENCES Customer(customerID) ON DELETE CASCADE,
	movieID int NOT NULL,
    FOREIGN KEY (movieID) REFERENCES Movie(movieID) ON DELETE CASCADE,
	dateWished datetime DEFAULT NOW() NOT NULL -- Pull the current date and time and record when the wish was posted
);

CREATE TABLE Kiosk -- Create a table holding addresses for each kiosk as well as kiosk location
(
	kioskID INTEGER AUTO_INCREMENT PRIMARY KEY NOT NULL,
	location varchar(32) NULL,
	addressLine1 varchar(32) NOT NULL,
	addressLine2 varchar(32) NULL,
	city varchar(32) NOT NULL,
	stateProvince varchar(32) NOT NULL,
	postalCode varchar(16) NOT NULL
);

CREATE TABLE Inventory -- Create a table holding the inventory of each individual kiosk
(
	stockID INTEGER AUTO_INCREMENT PRIMARY KEY NOT NULL,
	dvdBluRay varchar(8) NOT NULL,
	-- Allow one particular stockID to represent multiple copies of a movie at a particular kiosk.  When one is rented, decrement the count by one, and if count = 0 set inStock to "0" ("False")
	quantityAtKiosk int NOT NULL,
    Check(quantityAtKiosk >= 0),
	inStock bit DEFAULT 0 NOT NULL,
	movieID int NOT NULL,
    FOREIGN KEY (movieID) REFERENCES Movie(movieID) ON DELETE CASCADE,
	kioskID int,
    FOREIGN KEY (kioskID) REFERENCES Kiosk(kioskID) ON DELETE SET NULL
);

CREATE TABLE Rental -- Create a table to hold information on current rentals held by a particular customer
(
	rentalID INTEGER AUTO_INCREMENT PRIMARY KEY NOT NULL,
	rentalCost DECIMAL(6,2) DEFAULT 1.00 NOT NULL,
    CHECK(rentalCost >= 0),
	dateRented datetime DEFAULT NOW() NOT NULL,
	dateReturned datetime NULL, -- dateReturned will be NULL until the customer returns the movie
	customerID int,
    FOREIGN KEY (customerID) REFERENCES Customer(customerID) ON DELETE SET NULL,
	stockID int,
    FOREIGN KEY (stockID) REFERENCES Inventory(stockID) ON DELETE SET NULL
);

CREATE TABLE RentalHistory -- Create a table to hold a record/history of all rentals performed by a particular customer
(
	historyID INTEGER AUTO_INCREMENT PRIMARY KEY NOT NULL,
	customerID int NOT NULL,
    FOREIGN KEY (customerID) REFERENCES Customer(customerID) ON DELETE CASCADE,
	movieID int,
    FOREIGN KEY (movieID) REFERENCES Movie(movieID) ON DELETE SET NULL,
	outDate datetime NOT NULL, 
	inDate datetime NULL
);