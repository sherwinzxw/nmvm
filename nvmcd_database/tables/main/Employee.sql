--IF OBJECT_ID(N'dbo.Employee') IS NOT NULL BEGIN DROP TABLE dbo.Employee
--END
GO
    CREATE TABLE dbo.Employee (
        Id INT NOT NULL IDENTITY(1, 1),
        EmployeeNumber VARCHAR(12) NULL,
        FirstName VARCHAR(255) NOT NULL,
        MiddleName VARCHAR(255) NULL,
        LastName VARCHAR(255) NOT NULL,
        WorkPhone VARCHAR(20) NULL,
        Mobile VARCHAR(20) NULL,
        Email VARCHAR(255) NOT NULL UNIQUE,
        Profession VARCHAR(255) NULL,
        BirthYear INT NULL,
        Gender VARCHAR(50) NULL,
        CreatedDateTime DATETIME NOT NULL DEFAULT SYSDATETIME(),
        CreatedByDisplayName VARCHAR(255) NOT NULL DEFAULT SYSTEM_USER,
        CreatedByUserName VARCHAR(255) NOT NULL DEFAULT SYSTEM_USER,
        ModifiedDateTime DATETIME NOT NULL DEFAULT SYSDATETIME(),
        ModifiedByDisplayName VARCHAR(255) NOT NULL DEFAULT SYSTEM_USER,
        ModifiedByUserName VARCHAR(255) NOT NULL DEFAULT SYSTEM_USER,
        CONSTRAINT PK_Employee PRIMARY KEY (Id)
    )
GO