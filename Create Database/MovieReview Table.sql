/* Austin Caldwell and Evan Wehr */
-- Updated 10/18/2015

USE YellowBucketCSC365
GO

CREATE TABLE MovieReview -- Create a table of movie reviews
(
	reviewID int PRIMARY KEY IDENTITY(0000,1) NOT NULL,
	datePosted date NOT NULL,
	reviewDescription varchar(256) NULL,
	rating int CONSTRAINT rating_Default DEFAULT 0 CONSTRAINT rating_CC CHECK(rating >= 0 AND rating <= 5) NOT NULL,
	customerID int CONSTRAINT fk_MovieReview_Customer FOREIGN KEY REFERENCES Customer(customerID) ON DELETE CASCADE NOT NULL,
	movieID int CONSTRAINT fk_MovieReview_Movie FOREIGN KEY REFERENCES Movie(movieID) ON DELETE CASCADE NOT NULL,
);