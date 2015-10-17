USE YellowBucketCSC365
GO

INSERT INTO Rental(dateReturned, customerID, stockID)
VALUES
(NULL, 0, 5),
(NULL, 1, 3),
(GetDate(), 10, 7),
(GetDate(), 3, 2),
(NULL, 11, 4),
(GetDate(), 9, 0);