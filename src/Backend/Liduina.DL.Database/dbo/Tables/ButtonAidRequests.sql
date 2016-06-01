CREATE TABLE [dbo].[ButtonAidRequests] (
    [Id]           INT IDENTITY (1, 1) NOT NULL,
    [ButtonId]     INT NOT NULL,
    [AidRequestId] INT NOT NULL,
    CONSTRAINT [PK_dbo.ButtonAidRequests] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.ButtonAidRequests_dbo.AidRequests_AidRequestId] FOREIGN KEY ([AidRequestId]) REFERENCES [dbo].[AidRequests] ([Id]),
    CONSTRAINT [FK_dbo.ButtonAidRequests_dbo.Buttons_ButtonId] FOREIGN KEY ([ButtonId]) REFERENCES [dbo].[Buttons] ([Id])
);




GO
CREATE NONCLUSTERED INDEX [IX_AidRequestId]
    ON [dbo].[ButtonAidRequests]([AidRequestId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ButtonId]
    ON [dbo].[ButtonAidRequests]([ButtonId] ASC);

