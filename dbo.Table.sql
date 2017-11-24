CREATE TABLE [dbo].[Medicine] (
    [Id]      INT         IDENTITY (1, 1) NOT NULL,
    [MedName] NCHAR (30)  NOT NULL,
    [Length]   NCHAR (100) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);