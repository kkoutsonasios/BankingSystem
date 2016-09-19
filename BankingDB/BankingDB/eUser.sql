CREATE TABLE [dbo].[eUser]
(
	[Id] BIGINT NOT NULL  IDENTITY, 
    [PersonId] BIGINT NOT NULL, 
    [UserName] VARCHAR(50) NOT NULL, 
    [PasswordHash] VARCHAR(50) NOT NULL, 
    CONSTRAINT [FK_eUser_Person] FOREIGN KEY ([PersonId]) REFERENCES [Person]([Id]), 
    PRIMARY KEY ([UserName], [Id], [PersonId])
)

GO

CREATE INDEX [IX_eUser_PersonId] ON [dbo].[eUser] ([PersonId])
