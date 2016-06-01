CREATE TABLE [dbo].[ActionTypes] (
    [Id]      INT            IDENTITY (1, 1) NOT NULL,
    [Name]    NVARCHAR (50)  NULL,
    [IconUri] NVARCHAR (250) NULL,
    CONSTRAINT [PK_dbo.ActionTypes] PRIMARY KEY CLUSTERED ([Id] ASC)
);

