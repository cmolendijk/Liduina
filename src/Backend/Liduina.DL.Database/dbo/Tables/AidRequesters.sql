CREATE TABLE [dbo].[AidRequesters] (
    [Id]     INT IDENTITY (1, 1) NOT NULL,
    [UserId] INT NOT NULL,
    CONSTRAINT [PK_dbo.AidRequesters] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.AidRequesters_dbo.Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id])
);




GO
CREATE NONCLUSTERED INDEX [IX_UserId]
    ON [dbo].[AidRequesters]([UserId] ASC);

