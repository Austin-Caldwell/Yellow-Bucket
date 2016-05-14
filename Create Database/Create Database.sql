/* CREATING THE YellowBucketCSC365 DATABASE */ /* Austin Caldwell and Evan Wehr */
-- Updated 10/16/2015
Use master
IF DB_ID('YellowBucketCSC365') is not null  -- Code replicated from a suggestion by http://stackoverflow.com/users/9823/eduardo
	BEGIN								    -- If the database already exists, drop the entire database and recreate it.
		DROP DATABASE YellowBucketCSC365;
		CREATE DATABASE YellowBucketCSC365;
	END;
ELSE										-- If the database did not already exist, create the database.
	CREATE DATABASE YellowBucketCSC365;
GO