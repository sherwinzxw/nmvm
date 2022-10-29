
        
CREATE TABLE dbo.Backfill
(
  Id                    INT          NOT NULL IDENTITY(1,1),
  VacancyId             INT          NOT NULL,
  BackfillEmployeeId    INT          NOT NULL,
  BackfillFte           DECIMAL(5,2) NOT NULL,
  BackfillFrom          DATETIME    ,
  BackfillTo            DATETIME    ,
  BackfillDurationHours INT         ,
  CreatedDateTime       DATETIME     NOT NULL DEFAULT SYSDATETIME(),
  CreatedByDisplayName  VARCHAR(255) NOT NULL DEFAULT SYSTEM_USER,
  CreatedBySystemName   VARCHAR(255) NOT NULL DEFAULT SYSTEM_USER,
  ModifiedDateTime      DATETIME     NOT NULL DEFAULT SYSDATETIME(),
  ModifiedByDisplayName VARCHAR(255) NOT NULL DEFAULT SYSTEM_USER,
  ModifiedBySystemName  VARCHAR(255) NOT NULL DEFAULT SYSTEM_USER
)
GO

        
      