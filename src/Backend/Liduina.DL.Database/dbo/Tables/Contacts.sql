CREATE TABLE [dbo].[Contacts] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [UserId]          INT            NULL,
    [PhoneNumber]     NVARCHAR (15)  NULL,
    [EmailAddress]    NVARCHAR (100) NULL,
    [AidProvider_Id]  INT            NULL,
    [AidOffer_Id]     INT            NULL,
    [AidRequester_Id] INT            NULL,
    CONSTRAINT [PK_dbo.Contacts] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Contacts_dbo.AidOffers_AidOffer_Id] FOREIGN KEY ([AidOffer_Id]) REFERENCES [dbo].[AidOffers] ([Id]),
    CONSTRAINT [FK_dbo.Contacts_dbo.AidProviders_AidProvider_Id] FOREIGN KEY ([AidProvider_Id]) REFERENCES [dbo].[AidProviders] ([Id]),
    CONSTRAINT [FK_dbo.Contacts_dbo.AidRequesters_AidRequester_Id] FOREIGN KEY ([AidRequester_Id]) REFERENCES [dbo].[AidRequesters] ([Id]),
    CONSTRAINT [FK_dbo.Contacts_dbo.Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id])
);




GO
CREATE NONCLUSTERED INDEX [IX_AidRequester_Id]
    ON [dbo].[Contacts]([AidRequester_Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AidProvider_Id]
    ON [dbo].[Contacts]([AidProvider_Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_UserId]
    ON [dbo].[Contacts]([UserId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AidOffer_Id]
    ON [dbo].[Contacts]([AidOffer_Id] ASC);

