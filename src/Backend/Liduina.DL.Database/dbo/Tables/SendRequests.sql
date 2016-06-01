CREATE TABLE [dbo].[SendRequests] (
    [Id]                INT      IDENTITY (1, 1) NOT NULL,
    [AidProviderId]     INT      NOT NULL,
    [Status]            SMALLINT NOT NULL,
    [SendAidRequest_Id] INT      NULL,
    CONSTRAINT [PK_dbo.SendRequests] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.SendRequests_dbo.AidProviders_AidProviderId] FOREIGN KEY ([AidProviderId]) REFERENCES [dbo].[AidProviders] ([Id]),
    CONSTRAINT [FK_dbo.SendRequests_dbo.SendAidRequests_SendAidRequest_Id] FOREIGN KEY ([SendAidRequest_Id]) REFERENCES [dbo].[SendAidRequests] ([Id])
);




GO
CREATE NONCLUSTERED INDEX [IX_SendAidRequest_Id]
    ON [dbo].[SendRequests]([SendAidRequest_Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AidProviderId]
    ON [dbo].[SendRequests]([AidProviderId] ASC);

