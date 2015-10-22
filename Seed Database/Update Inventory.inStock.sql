/* UPDATE Inventory inStock Fields */ /* Austin Caldwell and Evan Wehr */
-- Updated 10/21/2015
USE YellowBucketCSC365
GO

UPDATE Inventory
SET inStock = 1
WHERE quantityAtKiosk > 0;