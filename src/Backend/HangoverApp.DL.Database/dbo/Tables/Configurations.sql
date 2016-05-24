CREATE TABLE [dbo].[Configurations] (
    [Id]                 INT            IDENTITY (1, 1) NOT NULL,
    [ButtonActionId]     INT            NOT NULL,
    [ConfigurationKeyId] INT            NOT NULL,
    [Value]              NVARCHAR (MAX) NULL,
    [Index]              SMALLINT       NOT NULL,
    CONSTRAINT [PK_dbo.Configurations] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Configurations_dbo.ButtonActions_ButtonActionId] FOREIGN KEY ([ButtonActionId]) REFERENCES [dbo].[ButtonActions] ([Id]),
    CONSTRAINT [FK_dbo.Configurations_dbo.ConfigurationKeys_ConfigurationKeyId] FOREIGN KEY ([ConfigurationKeyId]) REFERENCES [dbo].[ConfigurationKeys] ([Id])
);




GO



GO
CREATE NONCLUSTERED INDEX [IX_ConfigurationKeyId]
    ON [dbo].[Configurations]([ConfigurationKeyId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ButtonActionId]
    ON [dbo].[Configurations]([ButtonActionId] ASC);

