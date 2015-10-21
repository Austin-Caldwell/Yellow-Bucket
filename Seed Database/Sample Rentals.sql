USE YellowBucketCSC365
GO

INSERT INTO Rental(dateReturned, customerID, stockID)
VALUES
(NULL, 0, 5),
(NULL, 1, 3),
('10/12/2015', 8, 10),
('10/11/2015', 3, 0),
(NULL, 11, 9),
('10/17/2015', 9, 5),
('10/20/2015', 2, 13),
(GetDate(), 2, 4);