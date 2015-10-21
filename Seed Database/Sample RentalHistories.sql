USE YellowBucketCSC365
GO

INSERT INTO RentalHistory(customerID, movieID, outDate, inDate)
VALUES
(8, 4, '10/10/2015', '10/12/2015'),
(3, 0, '10/10/2015', '10/11/2015'),
(9, 2, '10/17/2015', '10/17/2015'),
(2, 4, '10/18/2015', '10/20/2015'),
(2, 1, (GetDate() - 1), GetDate());