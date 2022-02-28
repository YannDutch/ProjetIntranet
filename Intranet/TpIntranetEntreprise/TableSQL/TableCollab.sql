CREATE TABLE [dbo].[collaborateurs] (
    [matricule]    INT  IDENTITY (1, 1) NOT NULL,
    [nom]   VARCHAR (50) NOT NULL,
    [prenom] VARCHAR (50) NOT NULL,
    [email] VARCHAR (60) NOT NULL,
    [telephone] VARCHAR(17) NOT NULL,     
    PRIMARY KEY CLUSTERED ([matricule] ASC)
);