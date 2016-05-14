/* MovieReview View */ /* Austin Caldwell and Evan Wehr */
-- Updated 10/20/2015

SELECT C.userName AS 'User Name', M.title AS 'Movie', MR.reviewDescription AS 'Review', MR.rating AS 'Rating', MR.datePosted AS 'Date Posted'
FROM Customer C, MovieReview MR, Movie M
WHERE
C.customerID IN (SELECT MR.customerID FROM MovieReview)
AND
M.movieID IN (SELECT MR.movieID FROM MovieReview);
/*
	-- Use to specify specific movie's posted reviews:
AND
M.title = [MOVIE TITLE];
*/
/*
	-- Use to specify specific customer's posted reviews:
AND
C.lastName = [CUSTOMER LAST NAME];
*/
