CREATE TABLE [dbo].[AidRequests] (
    [Id]                  INT           IDENTITY (1, 1) NOT NULL,
    [Name]                NVARCHAR (50) NULL,
    [RecurrenceFrequency] SMALLINT      NOT NULL,
    [RecurrencePattern]   SMALLINT      NOT NULL,
    [UserId]              INT           NOT NULL,
    [EndTime_Id]          INT           NULL,
    [StartTime_Id]        INT           NULL,
    CONSTRAINT [PK_dbo.AidRequests] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.AidRequests_dbo.TimeSlots_EndTime_Id] FOREIGN KEY ([EndTime_Id]) REFERENCES [dbo].[TimeSlots] ([Id]),
    CONSTRAINT [FK_dbo.AidRequests_dbo.TimeSlots_StartTime_Id] FOREIGN KEY ([StartTime_Id]) REFERENCES [dbo].[TimeSlots] ([Id]),
    CONSTRAINT [FK_dbo.AidRequests_dbo.Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id])
);




GO
CREATE NONCLUSTERED INDEX [IX_UserId]
    ON [dbo].[AidRequests]([UserId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_StartTime_Id]
    ON [dbo].[AidRequests]([StartTime_Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_EndTime_Id]
    ON [dbo].[AidRequests]([EndTime_Id] ASC);

