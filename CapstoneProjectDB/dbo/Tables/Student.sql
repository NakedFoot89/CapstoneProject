CREATE TABLE [dbo].[Student]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FirstName] NCHAR(50) NOT NULL, 
    [Lastname] NCHAR(10) NOT NULL, 
    [BirthDate] NVARCHAR(15) NOT NULL, 
    [Phone] INT NOT NULL, 
    [Email] NCHAR(100) NOT NULL
)
