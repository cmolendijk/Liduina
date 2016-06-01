CREATE TABLE [dbo].[Calendars] (
    [Id]   INT      IDENTITY (1, 1) NOT NULL,
    [From] DATETIME NOT NULL,
    [To]   DATETIME NOT NULL,
    CONSTRAINT [PK_dbo.Calendars] PRIMARY KEY CLUSTERED ([Id] ASC)
);

