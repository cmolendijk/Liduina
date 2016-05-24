CREATE TABLE [dbo].[Categories] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (50)  NULL,
    [ActivityId] INT            NOT NULL,
    [IconUri]    NVARCHAR (250) NULL,
    CONSTRAINT [PK_dbo.Categories] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Categories_dbo.Activities_ActivityId] FOREIGN KEY ([ActivityId]) REFERENCES [dbo].[Activities] ([Id])
);




GO



GO
CREATE NONCLUSTERED INDEX [IX_ActivityId]
    ON [dbo].[Categories]([ActivityId] ASC);

