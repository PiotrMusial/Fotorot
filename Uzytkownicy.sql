CREATE TABLE [dbo].[Uzytkownicy] (
    [Id]       NCHAR (50) NOT NULL,
    [Login]    NCHAR (50) NOT NULL,
    [Password] NCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

