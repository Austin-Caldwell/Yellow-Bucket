USE YellowBucketCSC365
GO

INSERT INTO Customer(firstName, lastName, email, alternateEmail, userName, userPassword, creditCard, customerAddressID)
VALUES
('Michael', 'Kearney', 'michael.kearney@fictional.net', '', 'mkearney', 'Qw9+B64CUEst1bpk9YbvQg==', 'b+5Z2yki94dXKhQxJ1oILmlnCnCue/KB', 0),
('Ethan', 'Mathews', 'ethan.mathews@fictional.net', '', 'emathews', 'dOalxexcTr+65DuTja8q3g==', 'b+5Z2yki94dgaSa1E97n+rBvsX3MOzbb', 1),
('Kenneth', 'Kutcel', 'ken.kutcel@fictional.net', '', 'kkutcel', 'dhC5KiaFD/H/7v6Y1KplNA==', 'b+5Z2yki94f/ew4Y8Wa6xwKLO1IqGlE5', 4),
('Joshua', 'Shultz', 'josh.shultz@random.org', '', 'jshultz', 'g+JlyzGPnv2Z3WJLlYLyxQ==', 'b+5Z2yki94dm1D57im/tl9PvYLZhIAmU', 5),
('House', 'Scheidler', 'house.scheidler@random.org', '', 'hscheidler', '8SQNIyNu/HsAPll4jcnfag==', 'b+5Z2yki94dsXK8wUw1ECjqwJJXqOvsV', 3),
('Austin', 'Caldwell', 'austin.caldwell@random.org', '', 'acaldwell', '7o1jteYYbeaJHG/TEsHs8A==', 'b+5Z2yki94ew39RYA4OID2L+zHeOl3Zt', 2),
('Bethany', 'Ames', 'bethany.ames@speech.org', '', 'bames', '7OHUtZyTqw4toOB/DLjRaLrvDRFdf+tK', 'VpPn67IdMGuTEU2l33Hxvg7qCLIFWoLs', 6),
('Joy', 'Decker', 'joy.decker@happiness.com', '', 'jdecker', 'MS21DJcWrRqcJ/9JLxJnbw==', 'VpPn67IdMGvnAA+NTQZEYoGQx/yNpF1G', 7),
('Katie', 'McCormick', 'katie.mccormick@spice.com', '', 'kmccormick', 'FMYl9i/6hk3BheDMWmTEhg==', 'VpPn67IdMGvGwcZtRq3RNgm+2XTQgXsx', 8),
('Becca', 'Miller', 'becca.miller@running.org', '', 'bmiller', '6N7jhctAk2JHDD7UbZ0ogw==', 'VpPn67IdMGslBweYRAy0tVT1pu+kW+RP', 9),
('Hannah', 'Miller', 'hannah.miller@instrument.org', '', 'hmiller', 'YNxp3nzwneng3AO3796S0g==', 'VpPn67IdMGsWJApLnZzPodtxR646hhMm', 10),
('Audrey', 'Humphrey', 'audrey.humphrey@history.net', '', 'ahumphrey', 'FjiT7t5Fm9xhCrorAYltUw==', 'VpPn67IdMGtWxuy8JdvCNCeLILF6Cyf5', 11);