CREATE TABLE [dbo].[AidOffers] (
    [Id]                   INT           IDENTITY (1, 1) NOT NULL,
    [Name]                 NVARCHAR (50) NULL,
    [AidProviderId]        INT           NOT NULL,
    [Frequency]            SMALLINT      NOT NULL,
    [ActionsLeftThisMonth] SMALLINT      NOT NULL,
    [MaxTravelDistance]    SMALLINT      NOT NULL,
    [Availability_Id]      INT           NULL,
    CONSTRAINT [PK_dbo.AidOffers] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.AidOffers_dbo.AidProviders_AidProviderId] FOREIGN KEY ([AidProviderId]) REFERENCES [dbo].[AidProviders] ([Id]),
    CONSTRAINT [FK_dbo.AidOffers_dbo.Calendars_Availability_Id] FOREIGN KEY ([Availability_Id]) REFERENCES [dbo].[Calendars] ([Id])
);




GO
CREATE NONCLUSTERED INDEX [IX_Availability_Id]
    ON [dbo].[AidOffers]([Availability_Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AidProviderId]
    ON [dbo].[AidOffers]([AidProviderId] ASC);

