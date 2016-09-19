CREATE TABLE [dbo].[Balance]
(
	[Id] BIGINT NOT NULL  IDENTITY, 
    [AccountId] BIGINT NOT NULL, 
    [Amount] FLOAT NOT NULL DEFAULT 0, 
    CONSTRAINT [FK_Balance_Account] FOREIGN KEY ([AccountId]) REFERENCES [Account]([Id]), 
    PRIMARY KEY ([AccountId], [Id])
)

GO

CREATE INDEX [IX_Balance_AccountId] ON [dbo].[Balance] (AccountId)
