USE YellowBucketCSC365
GO

INSERT INTO MovieReview(datePosted, reviewDescription, rating, customerID, movieID)
VALUES
('04/16/2015', 'This movie is terrible!  I could have seen more action from traveling to Antarctica myself!', 1, 8, 4),
('07/10/2015', 'Best Sci-Fi Film Ever!!', 5, 3, 0),
('10/17/2015', 'Too Much Kissing.  Eww.', 2, 9, 2),
(GetDate(), 'The penguins are so much fun to watch!', 4, 2, 4);