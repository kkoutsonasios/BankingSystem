CREATE TABLE [dbo].[Transaction]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [Amount] FLOAT NOT NULL DEFAULT 0, 
    [Description] NVARCHAR(150) NOT NULL, 
    [PersonId] BIGINT NULL, 
    [AccountId] BIGINT NULL, 
    [Executed] BIT NOT NULL DEFAULT 0, 
    [CreationDate] DATETIME NOT NULL, 
    [ExecutionDate] DATETIME NULL, 
    CONSTRAINT [FK_Transaction_Person] FOREIGN KEY ([PersonId]) REFERENCES [Person]([Id]), 
    CONSTRAINT [FK_Transaction_Account] FOREIGN KEY ([AccountId]) REFERENCES [Account]([Id])
)

GO

CREATE INDEX [IX_Transaction_PersonId] ON [dbo].[Transaction] ([PersonId])

GO

CREATE INDEX [IX_Transaction_AccountId] ON [dbo].[Transaction] ([AccountId])
