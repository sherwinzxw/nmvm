--IF OBJECT_ID(N'dbo.Vacancy') IS NOT NULL BEGIN DROP TABLE dbo.Vacancy
--END
GO
    CREATE TABLE dbo.Vacancy (
        Id INT NOT NULL IDENTITY(1,1),
        VacancyType VARCHAR(12) NOT NULL,
        ContractId INT NOT NULL,
        PositionId INT NOT NULL,
        VacantFte DECIMAL(5, 2) NOT NULL,
        ReasonCode VARCHAR(10) NOT NULL,
        ReasonDetails VARCHAR(1000) NULL,
        VacantFromDateTime DATETIME NOT NULL,
        VacantToDateTime DATETIME NULL,
        VacantDurationHours INT NOT NULL,
        Comments VARCHAR(1000),
        CreatedDateTime DATETIME NOT NULL DEFAULT SYSDATETIME(),
        CreatedByDisplayName VARCHAR(255) NOT NULL DEFAULT SYSTEM_USER,
        CreatedByUserName VARCHAR(255) NOT NULL DEFAULT SYSTEM_USER,
        ModifiedByUserName VARCHAR(255) NOT NULL DEFAULT SYSTEM_USER,
        ModifiedDateTime DATETIME NOT NULL DEFAULT SYSDATETIME(),
        ModifiedByDisplayName VARCHAR(255) NOT NULL DEFAULT SYSTEM_USER,
        CONSTRAINT PK_Vacancy PRIMARY KEY (Id)
    )
GO