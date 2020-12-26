CREATE TABLE [dbo].[Students] (
    [Id]        INT         IDENTITY (1, 1) NOT NULL,
    [StudentID] INT  NOT NULL,
    [FirstName] NCHAR (50)  NOT NULL,
    [LastName]  NCHAR (50)  NOT NULL,
    [BirthDate] NCHAR (10)  NOT NULL,
    [Phone]     NCHAR(20)         NOT NULL,
    [Email]     NCHAR (100) NOT NULL,
    [Course] NCHAR(10) NOT NULL, 
    CONSTRAINT [PK__Students__3214EC0723210293] PRIMARY KEY CLUSTERED ([Id] ASC)
);

