CREATE TABLE [dbo].[Person]
(
	[Id] BIGINT NOT NULL  IDENTITY, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [IdNumber] NVARCHAR(50) NOT NULL, 
    CONSTRAINT [PK_Person] PRIMARY KEY ([Id]) 
)

GO

CREATE INDEX [IX_IdNumber] ON [dbo].[Person] ([IdNumber])
