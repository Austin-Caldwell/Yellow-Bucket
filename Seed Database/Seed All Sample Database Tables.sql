/* SEED THE YellowBucketCSC365 DATABASE WITH SAMPLE DATA */ /* Austin Caldwell and Evan Wehr */
-- Updated 10/17/2015

USE YellowBucketCSC365
GO

INSERT INTO CustomerAddress(addressLine1, city, stateProvince, postalCode)
VALUES
('777 Kindgom Way', 'Ararat', 'New York', '13011'),
('111 Texas Street', 'Lonestar', 'Texas', '18292'),
('581 Maisly Ave.', 'Gateway', 'Pennsylvania', '16911'),
('196 Lighthouse Blvd.', 'Atlantia', 'North Carolina', '10222'),
('009 Endline Circle', 'Faraway', 'Alaska', '19990'),
('260 Geneva Hwy.', 'Snyder', 'Ohio', '17888'),
('282 Tulip Way', 'Greenhouse', 'New York', '13357'),
('985 Sunshine Ave.', 'Positive', 'Indiana', '15929'),
('171 Staw Lane', 'Brave', 'Pennsylvania', '00829'),
('200 Jogger Place', 'Toetown', 'Louisiana', '16600'),
('999 Papyrus Street', 'Jolly', 'California', '18802'),
('875 Peanut Hwy.', 'Endor', 'West Virginia', '17070');

USE YellowBucketCSC365
GO

INSERT INTO Customer(firstName, lastName, email, userName, userPassword, creditCard, customerAddressID)
VALUES
('Michael', 'Kearney', 'michael.kearney@fictional.net', 'mkearney', 'C#D#Music', '1234-5678-9101-1123', 0),
('Ethan', 'Mathews', 'ethan.mathews@fictional.net', 'emathews', '!Writing!', '1234-5678-0099-0099', 1),
('Kenneth', 'Kutcel', 'ken.kutcel@fictional.net', 'kkutcel', 'JogRunWalk', '1234-5678-1122-3344', 4),
('Joshua', 'Shultz', 'josh.shultz@random.org', 'jshultz', 'Violin%2015', '1234-5678-3579-4680', 5),
('House', 'Scheidler', 'house.scheidler@random.org', 'hscheidler', 'MovieFANATIC1', '1234-5678-4756-3829', 3),
('Austin', 'Caldwell', 'austin.caldwell@random.org', 'acaldwell', 'RanDom&8', '1234-5678-1111-0000', 2),
('Bethany', 'Ames', 'bethany.ames@speech.org', 'bames', 'sternocleidomastoid', '0987-6543-2217-6521', 6),
('Joy', 'Decker', 'joy.decker@happiness.com', 'jdecker', 'PopCorn!', '0987-6543-1943-0027', 7),
('Katie', 'McCormick', 'katie.mccormick@spice.com', 'kmccormick', 'YellowRoses', '0987-6543-1626-1929', 8),
('Becca', 'Miller', 'becca.miller@running.org', 'bmiller', 'Tangled14', '0987-6543-0010-1022', 9),
('Hannah', 'Miller', 'hannah.miller@instrument.org', 'hmiller', 'Fiddle4Life', '0987-6543-6673-2828', 10),
('Audrey', 'Humphrey', 'audrey.humphrey@history.net', 'ahumphrey', 'GilmoreGirls', '0987-6543-3222-1299', 11);

USE YellowBucketCSC365
GO

INSERT INTO Kiosk(location, addressLine1, city, stateProvince, postalCode)
VALUES
('Walmart', '2001 Chippewa Street', 'Beaver Falls', 'Pennsylvania', '15010'),
('Rite Aid', '9010 University Way', 'Pittsburgh', 'Pennsylvania', '10222'),
('Giant Eagle', '1000 Main St. Ext.', 'Meadville', 'Pennsylvania', '16335'),
('Target', '2039 Shopping Lane', 'Cadbury', 'Ohio', '19992');

USE YellowBucketCSC365
GO

INSERT INTO Movie(title, movieDescription, avgRating, director, studio, runTime, parentalRating, genre, releaseDate)
VALUES
('Star Wars', 'A tale of intergalactic war and the discovery of family lineage.', 5, 'George Lucas', 'Lucasfilm Studios', 125, 'PG', 'Sci-Fi', '10/10/1978'),
('The Lord of The Rings', 'Running, running,... more running. Action.', 5, 'Steven Wier', 'Gateway Films', 160, 'PG-13', 'Fantasy', '02/26/2002'),
('The Prince and Me', 'Fall in love. Break up. Fall in love.', 4, 'Amberly Kissinger', 'Brighthouse', 130, 'PG-13', 'Romance', '08/21/2005'),
('The Peanuts Movie', 'A lonely boy and his search for friends.', 4, 'Charles Schultz', 'ComicsRUs', 90, 'G', 'Kids', '06/15/1995'),
('Penguins: A Documentary', 'Life of the tuxedo animals in Antarctica.', 3, 'Abigail Davis', 'Geneva Studios', 95, 'NR', 'Documentary', '12/13/2015');

USE YellowBucketCSC365
GO

INSERT INTO Inventory(dvdBluRay, movieID, kioskID)
VALUES
('DVD', 0, 0),
('DVD', 0, 1),
('DVD', 0, 2),
('DVD', 1, 0),
('DVD', 1, 3),
('Blu-Ray', 2, 3),
('DVD', 3, 2),
('DVD', 3, 3),
('Blu-Ray', 4, 0),
('Blu-Ray', 4, 1),
('Blu-Ray', 4, 2);

USE YellowBucketCSC365
GO

INSERT INTO Wish(customerID, movieID)
VALUES
(0, 4),
(3, 1),
(3, 3),
(7, 0),
(7, 1),
(10, 2);

USE YellowBucketCSC365
GO

INSERT INTO Rental(dateReturned, customerID, stockID)
VALUES
(NULL, 0, 5),
(NULL, 1, 3),
(GetDate(), 8, 8),
(GetDate(), 3, 0),
(NULL, 11, 4),
(GetDate(), 9, 5);

USE YellowBucketCSC365
GO

INSERT INTO RentalHistory(customerID, movieID, outDate, inDate)
VALUES
(8, 4, '04/15/2015', '04/16/2015'),
(3, 0, '06/10/2015', '06/20/2015'),
(9, 2, '10/17/2015', '10/17/2015');

USE YellowBucketCSC365
GO

INSERT INTO RatingReview(datePosted, reviewDescription, rating, customerID, movieID)
VALUES
('04/16/2015', 'This movie is terrible!  I could have seen more action from traveling to Antarctica myself!', 1, 8, 4),
('06/20/2015', 'Best Sci-Fi Film Ever!!', 5, 3, 0),
('10/17/2015', 'Too Much Kissing.  Eww.', 2, 9, 2);

