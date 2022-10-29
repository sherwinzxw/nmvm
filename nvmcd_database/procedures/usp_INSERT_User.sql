CREATE PROCEDURE dbo.usp_INSERT_User 
	@Username varchar(255),
    @FirstName varchar(255),
    @LastName varchar(255),
    @Email varchar(255),
    @Mobile varchar(50) = NULL
AS
INSERT INTO [dbo].[User] (
        [Username],
        [FirstName],
        [LastName],
        [Email],
        [Mobile]
    )
VALUES
    (
        @Username,
        @FirstName,
        @LastName,
        @Email,
        @Mobile
    )
GO