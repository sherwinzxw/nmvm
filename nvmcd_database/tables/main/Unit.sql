
        
CREATE TABLE Unit
(
  Id                    INT          NOT NULL IDENTITY(1,1),
  UnitCode              VARCHAR(10) NOT NULL,
  UnitName              VARCHAR(255) NOT NULL,
  UnitDescription       VARCHAR(255) NOT NULL,
  Facility              VARCHAR(255) NOT NULL,
  Region                VARCHAR(12)  NOT NULL,
  EffectiveFromDateTime         DATETIME     NOT NULL DEFAULT SYSDATETIME(),
  EffectiveToDateTime           DATETIME    NULL,
  CreatedDateTime       DATETIME     NOT NULL DEFAULT SYSDATETIME(),
  CreatedByDisplayName  VARCHAR(255) NOT NULL DEFAULT SYSTEM_USER,
  CreatedByUserName     VARCHAR(255) NOT NULL DEFAULT SYSTEM_USER,
  ModifiedDateTime      DATETIME     NOT NULL DEFAULT SYSDATETIME(),
  ModifiedByDisplayName VARCHAR(255) NOT NULL DEFAULT SYSTEM_USER,
  ModifiedByUserName    VARCHAR(255) NOT NULL DEFAULT SYSTEM_USER,
  CONSTRAINT PK_Unit PRIMARY KEY (Id)
)
GO

        
      