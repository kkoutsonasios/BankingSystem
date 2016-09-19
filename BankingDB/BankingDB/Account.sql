CREATE TABLE [dbo].[Account]
(
	[Id] BIGINT NOT NULL  IDENTITY, 
    [PersonId] BIGINT NOT NULL, 
    [Description] NVARCHAR(150) NULL, 
    CONSTRAINT [FK_Account_Person] FOREIGN KEY ([PersonId]) REFERENCES [Person]([Id]), 
    PRIMARY KEY ([Id], [PersonId])
)

GO

CREATE INDEX [IX_Account_PersonId] ON [dbo].[Account] ([PersonId])
