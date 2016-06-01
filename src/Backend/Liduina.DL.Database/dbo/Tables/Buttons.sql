CREATE TABLE [dbo].[Buttons] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [Name]      NVARCHAR (50) NULL,
    [Color]     NVARCHAR (6)  NULL,
    [TillHours] SMALLINT      NOT NULL,
    CONSTRAINT [PK_dbo.Buttons] PRIMARY KEY CLUSTERED ([Id] ASC)
);

