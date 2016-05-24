CREATE TABLE [dbo].[AidProviders] (
    [Id]             INT IDENTITY (1, 1) NOT NULL,
    [UserId]         INT NOT NULL,
    [AvailabilityId] INT NOT NULL,
    [IsProfessional] BIT NOT NULL,
    [AidRequest_Id]  INT NULL,
    CONSTRAINT [PK_dbo.AidProviders] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.AidProviders_dbo.AidRequests_AidRequest_Id] FOREIGN KEY ([AidRequest_Id]) REFERENCES [dbo].[AidRequests] ([Id]),
    CONSTRAINT [FK_dbo.AidProviders_dbo.Calendars_AvailabilityId] FOREIGN KEY ([AvailabilityId]) REFERENCES [dbo].[Calendars] ([Id]),
    CONSTRAINT [FK_dbo.AidProviders_dbo.Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id])
);




GO
CREATE NONCLUSTERED INDEX [IX_AvailabilityId]
    ON [dbo].[AidProviders]([AvailabilityId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_UserId]
    ON [dbo].[AidProviders]([UserId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AidRequest_Id]
    ON [dbo].[AidProviders]([AidRequest_Id] ASC);

