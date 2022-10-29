
        
CREATE TABLE PositionHistory
(
  Id                    INT          NOT NULL IDENTITY(1,1),
  PositionId            INT          NOT NULL,
  PosiionTitle          VARCHAR(255) NOT NULL,
  PositionNumber        VARCHAR(12)  NOT NULL,
  ContractType          VARCHAR(12)  NOT NULL,
  EffectiveFromDateTime         DATETIME     NOT NULL,
  EffectiveToDateTime           DATETIME     NOT NULL,
  CreatedDateTime       DATETIME     NOT NULL DEFAULT SYSDATETIME(),
  CreatedByDisplayName  VARCHAR(255) NOT NULL DEFAULT SYSTEM_USER,
  CreatedByUserName     VARCHAR(255) NOT NULL DEFAULT SYSTEM_USER,
  ModifiedDateTime      DATETIME     NOT NULL DEFAULT SYSDATETIME(),
  ModifiedByDisplayName VARCHAR(255) NOT NULL DEFAULT SYSTEM_USER,
  ModifiedByUserName    VARCHAR(255) NOT NULL DEFAULT SYSTEM_USER,
  ArchiveDateTime       DATETIME     NOT NULL DEFAULT SYSDATETIME(),
  ArchiveByUserName     VARCHAR(255) NOT NULL DEFAULT SYSTEM_USER,
  ArchiveByDisplayName  VARCHAR(255) DEFAULT SYSTEM_USER
)
GO

        
      