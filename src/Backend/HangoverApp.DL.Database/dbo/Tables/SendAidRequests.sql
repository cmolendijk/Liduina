CREATE TABLE [dbo].[SendAidRequests] (
    [Id]           INT      IDENTITY (1, 1) NOT NULL,
    [AidRequestId] INT      NOT NULL,
    [Status]       SMALLINT NOT NULL,
    CONSTRAINT [PK_dbo.SendAidRequests] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.SendAidRequests_dbo.AidRequests_AidRequestId] FOREIGN KEY ([AidRequestId]) REFERENCES [dbo].[AidRequests] ([Id])
);




GO
CREATE NONCLUSTERED INDEX [IX_AidRequestId]
    ON [dbo].[SendAidRequests]([AidRequestId] ASC);

