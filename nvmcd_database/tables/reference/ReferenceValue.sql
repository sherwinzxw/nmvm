
        
CREATE TABLE Reference
(
  Id                    INT          NOT NULL IDENTITY(1,1),
  DomainCode            VARCHAR(12)  NOT NULL,
  Code                  VARCHAR(12)  NOT NULL,
  Description           VARCHAR(255) NOT NULL,
  Label                 VARCHAR(255) NOT NULL,
  EffectiveFromDateTime         DATETIME     NOT NULL DEFAULT SYSDATETIME(),
  EffectiveToDateTime           DATETIME    NULL,
  ActiveFlag            BIT          NOT NULL DEFAULT 1,
  CreatedDateTime       DATETIME     NOT NULL DEFAULT SYSDATETIME(),
  CreatedByDisplayName  VARCHAR(255) NOT NULL DEFAULT SYSTEM_USER,
  CreatedByUserName     VARCHAR(255) NOT NULL DEFAULT SYSTEM_USER,
  ModifiedDateTime      DATETIME     NOT NULL DEFAULT SYSDATETIME(),
  ModifiedByDisplayName VARCHAR(255) NOT NULL DEFAULT SYSTEM_USER,
  ModifiedByUserName    VARCHAR(255) NOT NULL DEFAULT SYSTEM_USER, 
    CONSTRAINT [PK_Reference] PRIMARY KEY ([Id])
)
GO