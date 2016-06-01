CREATE TABLE [dbo].[ConfigurationKeys] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [Name]         NVARCHAR (MAX) NULL,
    [IsOptional]   BIT            NOT NULL,
    [IsRecurring]  BIT            NOT NULL,
    [ActionTypeId] INT            NOT NULL,
    CONSTRAINT [PK_dbo.ConfigurationKeys] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.ConfigurationKeys_dbo.ActionTypes_ActionTypeId] FOREIGN KEY ([ActionTypeId]) REFERENCES [dbo].[ActionTypes] ([Id])
);




GO
CREATE NONCLUSTERED INDEX [IX_ActionTypeId]
    ON [dbo].[ConfigurationKeys]([ActionTypeId] ASC);

