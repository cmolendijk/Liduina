CREATE TABLE [dbo].[ButtonActions] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [Name]         NVARCHAR (50) NULL,
    [ActionTypeId] INT           NOT NULL,
    [Button_Id]    INT           NULL,
    CONSTRAINT [PK_dbo.ButtonActions] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.ButtonActions_dbo.ActionTypes_ActionTypeId] FOREIGN KEY ([ActionTypeId]) REFERENCES [dbo].[ActionTypes] ([Id]),
    CONSTRAINT [FK_dbo.ButtonActions_dbo.Buttons_Button_Id] FOREIGN KEY ([Button_Id]) REFERENCES [dbo].[Buttons] ([Id])
);




GO
CREATE NONCLUSTERED INDEX [IX_Button_Id]
    ON [dbo].[ButtonActions]([Button_Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ActionTypeId]
    ON [dbo].[ButtonActions]([ActionTypeId] ASC);

