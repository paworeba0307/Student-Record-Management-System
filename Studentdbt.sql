CREATE TABLE [dbo].[Studentdbt] (
    [Id]      INT            IDENTITY (1, 1) NOT NULL,
    [Name]    NVARCHAR (100) NOT NULL,
    [Grade]   INT            NOT NULL,
    [Subject] NVARCHAR (100) NOT NULL,
    [Marks]   NVARCHAR (50)  NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
