/* SEED THE YellowBucketCSC365 DATABASE WITH SAMPLE DATA */ /* Austin Caldwell and Evan Wehr */
-- Updated 12/28/2015 FOR MySQL

USE YellowBucketCSC365;

INSERT INTO CustomerAddress(addressLine1, addressLine2, city, stateProvince, postalCode)
VALUES
('777 Kindgom Way', '', 'Ararat', 'New York', '13011'),
('111 Lonestar Street', '', 'Mainville', 'Ohio', '18292'),
('581 Maisly Ave.', '', 'Gateway', 'Pennsylvania', '16911'),
('196 Lighthouse Blvd.', '', 'Atlantia', 'Pennsylvania', '10222'),
('009 Endline Circle', '', 'Faraway', 'Ohio', '19990'),
('260 Geneva Hwy.', '', 'Snyder', 'Ohio', '17888'),
('282 Tulip Way', '', 'Greenhouse', 'New York', '13357'),
('985 Sunshine Ave.', '', 'Positive', 'Indiana', '15929'),
('171 Staw Lane', '', 'Brave', 'Pennsylvania', '00829'),
('200 Jogger Place', '', 'Toetown', 'West Virginia', '16600'),
('999 Papyrus Street', '', 'Jolly', 'New York', '18802'),
('875 Peanut Hwy.', '', 'Endor', 'West Virginia', '17070');

INSERT INTO Customer(firstName, lastName, email, alternateEmail, userName, userPassword, creditCard, customerAddressID)
VALUES
('Michael', 'Kearney', 'michael.kearney@fictional.net', '', 'mkearney', 'Qw9+B64CUEst1bpk9YbvQg==', 'b+5Z2yki94dXKhQxJ1oILmlnCnCue/KB', 1),
('Ethan', 'Mathews', 'ethan.mathews@fictional.net', '', 'emathews', 'dOalxexcTr+65DuTja8q3g==', 'b+5Z2yki94dgaSa1E97n+rBvsX3MOzbb', 2),
('Kenneth', 'Kutcel', 'ken.kutcel@fictional.net', '', 'kkutcel', 'dhC5KiaFD/H/7v6Y1KplNA==', 'b+5Z2yki94f/ew4Y8Wa6xwKLO1IqGlE5', 5),
('Joshua', 'Shultz', 'josh.shultz@random.org', '', 'jshultz', 'g+JlyzGPnv2Z3WJLlYLyxQ==', 'b+5Z2yki94dm1D57im/tl9PvYLZhIAmU', 6),
('House', 'Scheidler', 'house.scheidler@random.org', '', 'hscheidler', '8SQNIyNu/HsAPll4jcnfag==', 'b+5Z2yki94dsXK8wUw1ECjqwJJXqOvsV', 4),
('Austin', 'Caldwell', 'austin.caldwell@random.org', '', 'acaldwell', '7o1jteYYbeaJHG/TEsHs8A==', 'b+5Z2yki94ew39RYA4OID2L+zHeOl3Zt', 3),
('Bethany', 'Ames', 'bethany.ames@speech.org', '', 'bames', '7OHUtZyTqw4toOB/DLjRaLrvDRFdf+tK', 'VpPn67IdMGuTEU2l33Hxvg7qCLIFWoLs', 7),
('Joy', 'Decker', 'joy.decker@happiness.com', '', 'jdecker', 'MS21DJcWrRqcJ/9JLxJnbw==', 'VpPn67IdMGvnAA+NTQZEYoGQx/yNpF1G', 8),
('Katie', 'McCormick', 'katie.mccormick@spice.com', '', 'kmccormick', 'FMYl9i/6hk3BheDMWmTEhg==', 'VpPn67IdMGvGwcZtRq3RNgm+2XTQgXsx', 9),
('Becca', 'Miller', 'becca.miller@running.org', '', 'bmiller', '6N7jhctAk2JHDD7UbZ0ogw==', 'VpPn67IdMGslBweYRAy0tVT1pu+kW+RP', 10),
('Hannah', 'Miller', 'hannah.miller@instrument.org', '', 'hmiller', 'YNxp3nzwneng3AO3796S0g==', 'VpPn67IdMGsWJApLnZzPodtxR646hhMm', 11),
('Audrey', 'Humphrey', 'audrey.humphrey@history.net', '', 'ahumphrey', 'FjiT7t5Fm9xhCrorAYltUw==', 'VpPn67IdMGtWxuy8JdvCNCeLILF6Cyf5', 12);

INSERT INTO Kiosk(location, addressLine1, city, stateProvince, postalCode)
VALUES
('Walmart', '2001 Chippewa Street', 'Beaver Falls', 'Pennsylvania', '15010'),
('Rite Aid', '9010 University Way', 'Fredonia', 'New York', '10222'),
('Giant Eagle', '1000 Main St. Ext.', 'Meadville', 'Pennsylvania', '16335'),
('Target', '2039 Shopping Lane', 'Cadbury', 'Ohio', '19992');


INSERT INTO Movie(title, movieDescription, director, studio, runTime, parentalRating, genre, releaseDate)
VALUES
('Star Wars', 'A tale of intergalactic war and the discovery of family lineage.', 'George Lucas', 'Lucasfilm Studios', 125, 'PG', 'Sci-Fi', 	'1978/10/10'),
('The Lord of The Rings', 'Running, running,... more running. Action.', 'Steven Wier', 'Gateway Films', 160, 'PG-13', 'Fantasy', '2002/02/26'),
('The Prince and Me', 'Fall in love. Break up. Fall in love.', 'Amberly Kissinger', 'Brighthouse', 130, 'PG-13', 'Romance', '2005/08/21'),
('The Peanuts Movie', 'A lonely boy and his search for friends.', 'Charles Schultz', 'ComicsRUs', 90, 'G', 'Kids', '1995/06/15'),
('Penguins: A Documentary', 'Life of the tuxedo animals in Antarctica.', 'Abigail Davis', 'Geneva Studios', 95, 'NR', 'Documentary', '2015/12/13');


INSERT INTO Inventory(dvdBluRay, movieID, kioskID, quantityAtKiosk)
VALUES
('DVD', 1, 1, 1),
('DVD', 1, 2, 2),
('DVD', 1, 3, 1),
('DVD', 2, 1, 1),
('DVD', 2, 4, 1),
('DVD', 3, 2, 2),
('DVD', 3, 3, 2),
('Blu-Ray', 3, 4, 1),
('DVD', 4, 3, 1),
('DVD', 4, 4, 2),
('Blu-Ray', 5, 1, 1),
('Blu-Ray', 5, 2, 1),
('Blu-Ray', 5, 3, 1),
('DVD', 5, 4, 2);

UPDATE Inventory
SET inStock = 1
WHERE quantityAtKiosk > 0;

INSERT INTO Wish(customerID, movieID)
VALUES
(1, 5),
(4, 2),
(4, 4),
(8, 1),
(8, 2),
(11, 3);


INSERT INTO Rental(dateRented, dateReturned, customerID, stockID)
VALUES
('2015/02/26', NULL, 1, 6),
('2015/02/26', NULL, 2, 4),
('2015/02/26', '2015/10/12', 9, 11),
('2015/02/26', '2015/10/11', 4, 1),
('2015/02/26', NULL, 12, 10),
('2015/02/26', '2015/10/17', 10, 6),
('2015/02/26', '2015/10/20', 3, 14),
('2015/02/26', '2015/11/22', 3, 5);


INSERT INTO RentalHistory(customerID, movieID, outDate, inDate)
VALUES
(9, 5, '2015/02/26', '2015/10/12'),
(4, 1, '2015/02/26', '2015/10/11'),
(10, 3, '2015/02/26', '2015/10/17'),
(3, 5, '2015/02/26', '2015/10/20'),
(3, 2, '2015/02/26', '2015/11/22');


INSERT INTO MovieReview(datePosted, reviewDescription, rating, customerID, movieID)
VALUES
('2015/10/12', 'This movie is terrible!  I could have seen more action from traveling to Antarctica myself!', 1, 9, 5),
('2015/10/11', 'Best Sci-Fi Film Ever!!', 5, 4, 1),
('2015/10/17', 'Too Much Kissing.  Eww.', 2, 10, 3),
('2015/10/20', 'The penguins are so much fun to watch!', 4, 3, 5),
(NOW(), 'The culture of Star Wars with the thematics of Narnia.', 5, 3, 2);

