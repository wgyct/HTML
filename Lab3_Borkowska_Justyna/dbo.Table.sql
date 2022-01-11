CREATE TABLE [dbo].[Table] (
    [Id]          INT          NOT NULL,
    [User]        VARCHAR (50) NULL,
    [Rozmiar]     INT          NULL,
    [Polozenie]   INT          NULL,
    [Godzina] VARBINARY(50) NULL, 
    [Data] VARCHAR(50) NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

