CREATE TABLE [dbo].[PersonAccount]
(
    [PersonId] BIGINT NOT NULL, 
    [AccountId] BIGINT NOT NULL, 
    CONSTRAINT [FK_PersonAccount_Person] FOREIGN KEY ([PersonId]) REFERENCES [Person]([Id]), 
    CONSTRAINT [FK_PersonAccount_Account] FOREIGN KEY ([AccountId]) REFERENCES [Account]([Id]), 
    CONSTRAINT [PK_PersonAccount] PRIMARY KEY ([AccountId], [PersonId])
)

GO

CREATE INDEX [IX_PersonAccount_PersonId] ON [dbo].[PersonAccount] ([PersonId])

GO

CREATE INDEX [IX_PersonAccount_AccountId] ON [dbo].[PersonAccount] ([AccountId])
