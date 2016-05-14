USE YellowBucketCSC365
GO

INSERT INTO Movie(title, movieDescription, director, studio, runTime, parentalRating, genre, releaseDate)
VALUES
('Star Wars', 'A tale of intergalactic war and the discovery of family lineage.', 'George Lucas', 'Lucasfilm Studios', 125, 'PG', 'Sci-Fi', '10/10/1978'),
('The Lord of The Rings', 'Running, running,... more running. Action.', 'Steven Wier', 'Gateway Films', 160, 'PG-13', 'Fantasy', '02/26/2002'),
('The Prince and Me', 'Fall in love. Break up. Fall in love.', 'Amberly Kissinger', 'Brighthouse', 130, 'PG-13', 'Romance', '08/21/2005'),
('The Peanuts Movie', 'A lonely boy and his search for friends.', 'Charles Schultz', 'ComicsRUs', 90, 'G', 'Kids', '06/15/1995'),
('Penguins: A Documentary', 'Life of the tuxedo animals in Antarctica.', 'Abigail Davis', 'Geneva Studios', 95, 'NR', 'Documentary', '12/13/2015');