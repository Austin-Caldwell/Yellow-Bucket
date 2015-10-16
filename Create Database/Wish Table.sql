/* Austin Caldwell and Evan Wehr */
-- Updated 10/16/2015

USE YellowBucketCSC365
GO

CREATE TABLE Wish -- Create a table linking customers to the movies they wish for
(
	wishID int PRIMARY KEY IDENTITY(0000,1) NOT NULL,
	customerID int CONSTRAINT fk_Wish_Customer FOREIGN KEY REFERENCES Customer(customerID) ON DELETE CASCADE NOT NULL,
	movieID int CONSTRAINT fk_Wish_Movie FOREIGN KEY REFERENCES Movie(movieID) ON DELETE SET NULL,
	dateWished datetime CONSTRAINT dateWished_Default DEFAULT GetDate() NOT NULL -- Pull the current date and time and record when the wish was posted
);