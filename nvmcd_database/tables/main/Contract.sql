--IF OBJECT_ID(N'dbo.Contract') IS NOT NULL BEGIN DROP TABLE dbo.Contract
--END
GO
    CREATE TABLE dbo.Contract (
        id INT IDENTITY(1, 1) NOT NULL,
        EmployeeId INT NOT NULL,
        PositionId INT NOT NULL,
        EffectiveFrom DATETIME NOT NULL,
        EffectiveTo DATETIME NULL,
        ContractType VARCHAR(10) NOT NULL,
        FteFilled DECIMAL(5, 2) NOT NULL,
        CreatedDateTime DATETIME NOT NULL DEFAULT SYSDATETIME(),
        CreatedByDisplayName VARCHAR(255) NOT NULL DEFAULT SYSTEM_USER,
        CreatedByUserName VARCHAR(255) NOT NULL DEFAULT SYSTEM_USER,
        ModifiedDateTime DATETIME NOT NULL DEFAULT SYSDATETIME(),
        ModifiedByDisplayName VARCHAR(255) NOT NULL DEFAULT SYSTEM_USER,
        ModifiedByUserName VARCHAR(255) NOT NULL DEFAULT SYSTEM_USER,
        CONSTRAINT PK_Contract PRIMARY KEY (id)
    )
GO