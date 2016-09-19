CREATE TABLE [dbo].[Settings]
(
	[Id] BIGINT NOT NULL , 
    [SettingName] NVARCHAR(50) NOT NULL, 
    [SettingValueStr] NVARCHAR(250) NULL, 
    [SettingValueBool] BIT NULL, 
    [SettingValueNumber] FLOAT NULL, 
    PRIMARY KEY ([SettingName])
)
