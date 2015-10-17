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