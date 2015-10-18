USE YellowBucketCSC365
GO

INSERT INTO Rental(dateReturned, customerID, stockID)
VALUES
(NULL, 0, 5),
(NULL, 1, 3),
('04/16/2015', 8, 10),
('07/10/2015', 3, 0),
(NULL, 11, 4),
('10/17/2015', 9, 5),
(GetDate(), 2, 13);