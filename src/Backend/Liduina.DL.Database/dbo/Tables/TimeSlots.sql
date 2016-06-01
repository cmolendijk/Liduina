CREATE TABLE [dbo].[TimeSlots] (
    [Id]            INT      IDENTITY (1, 1) NOT NULL,
    [Day]           SMALLINT NOT NULL,
    [StartTime]     DATETIME NOT NULL,
    [EndTime]       DATETIME NOT NULL,
    [Calendar_Id]   INT      NULL,
    [AidRequest_Id] INT      NULL,
    CONSTRAINT [PK_dbo.TimeSlots] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.TimeSlots_dbo.AidRequests_AidRequest_Id] FOREIGN KEY ([AidRequest_Id]) REFERENCES [dbo].[AidRequests] ([Id]),
    CONSTRAINT [FK_dbo.TimeSlots_dbo.Calendars_Calendar_Id] FOREIGN KEY ([Calendar_Id]) REFERENCES [dbo].[Calendars] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_AidRequest_Id]
    ON [dbo].[TimeSlots]([AidRequest_Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Calendar_Id]
    ON [dbo].[TimeSlots]([Calendar_Id] ASC);

