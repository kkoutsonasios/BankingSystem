CREATE TABLE [dbo].[Account]
(
	[Id] BIGINT NOT NULL  IDENTITY, 
    [PersonId] BIGINT NULL, 
    [Description] NVARCHAR(150) NULL, 
    CONSTRAINT [FK_Account_Person] FOREIGN KEY ([PersonId]) REFERENCES [Person]([Id]), 
    CONSTRAINT [PK_Account] PRIMARY KEY ([Id]) 
)

GO

CREATE INDEX [IX_Account_PersonId] ON [dbo].[Account] ([PersonId])
