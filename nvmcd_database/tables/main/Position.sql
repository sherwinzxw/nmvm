﻿--IF OBJECT_ID(N'dbo.Contract') IS NOT NULL BEGIN DROP TABLE dbo.Position
--END
--GO
CREATE TABLE dbo.Position (
    Id INT NOT NULL IDENTITY(1,1),
    UnitId INT NOT NULL,
    PositionTitle VARCHAR(255) NOT NULL,
    PositionNumber VARCHAR(12) NOT NULL,
    AwardCode VARCHAR(10) NOT NULL,
    Grade VARCHAR(10) NOT NULL,
    FteApproved DECIMAL(5, 2) NOT NULL,
    EffectiveFrom DATETIME NOT NULL DEFAULT SYSDATETIME(),
    CreatedDateTime DATETIME NOT NULL DEFAULT SYSDATETIME(),
    CreatedByDisplayName VARCHAR(255) NOT NULL DEFAULT SYSTEM_USER,
    CreatedBySystemName VARCHAR(255) NOT NULL DEFAULT SYSTEM_USER,
    ModifiedDateTime DATETIME NOT NULL DEFAULT SYSDATETIME(),
    ModifiedByDisplayName VARCHAR(255) NOT NULL DEFAULT SYSTEM_USER,
    ModifiedBySystemName VARCHAR(255) NOT NULL DEFAULT SYSTEM_USER,
    CONSTRAINT PK_Position PRIMARY KEY (Id)
)