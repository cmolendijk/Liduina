CREATE TABLE [dbo].[Activities] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [Name]          NVARCHAR (50)  NULL,
    [IconUri]       NVARCHAR (250) NULL,
    [AidOffer_Id]   INT            NULL,
    [AidRequest_Id] INT            NULL,
    CONSTRAINT [PK_dbo.Activities] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Activities_dbo.AidOffers_AidOffer_Id] FOREIGN KEY ([AidOffer_Id]) REFERENCES [dbo].[AidOffers] ([Id]),
    CONSTRAINT [FK_dbo.Activities_dbo.AidRequests_AidRequest_Id] FOREIGN KEY ([AidRequest_Id]) REFERENCES [dbo].[AidRequests] ([Id])
);




GO
CREATE NONCLUSTERED INDEX [IX_AidRequest_Id]
    ON [dbo].[Activities]([AidRequest_Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AidOffer_Id]
    ON [dbo].[Activities]([AidOffer_Id] ASC);

