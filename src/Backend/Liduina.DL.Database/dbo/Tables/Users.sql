CREATE TABLE [dbo].[Users] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [Type]            SMALLINT       NOT NULL,
    [Email]           NVARCHAR (250) NULL,
    [FirstName]       NVARCHAR (25)  NULL,
    [MiddleName]      NVARCHAR (25)  NULL,
    [LastName]        NVARCHAR (25)  NULL,
    [AddressLine]     NVARCHAR (250) NULL,
    [ZipCode]         NVARCHAR (6)   NULL,
    [City]            NVARCHAR (100) NULL,
    [Country]         NVARCHAR (100) NULL,
    [Description]     NVARCHAR (500) NULL,
    [PhotoIdentifier] NVARCHAR (100) NULL,
    CONSTRAINT [PK_dbo.Users] PRIMARY KEY CLUSTERED ([Id] ASC)
);






GO



GO


