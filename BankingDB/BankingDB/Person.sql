CREATE TABLE [dbo].[Person]
(
	[Id] BIGINT NOT NULL PRIMARY KEY, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [IdNumber] NVARCHAR(50) NOT NULL PRIMARY KEY
)

GO

CREATE INDEX [IX_IdNumber] ON [dbo].[Person] ([IdNumber])
