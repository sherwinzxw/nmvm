
CREATE PROCEDURE dbo.usp_UPDATE_User @Id INT,
    @Username varchar(255),
    @FirstName varchar(255),
    @LastName varchar(255),
    @Email varchar(255),
    @Mobile varchar(50),
    @ModifiedByUserName VARCHAR(255),
    @ModifiedByDisplayName VARCHAR(255) 
AS
UPDATE
    [dbo].[User]
SET
    Username = @Username,
    FirstName = @FirstName,
    LastName = @LastName,
    Email = @Email,
    Mobile = @Mobile,
    ModifiedDateTime = SYSDATETIME(),
	ModifiedByDisplaName = @ModifiedByDisplayName,
    ModifiedByUserName = @ModifiedByUserName
WHERE
    Id = @Id