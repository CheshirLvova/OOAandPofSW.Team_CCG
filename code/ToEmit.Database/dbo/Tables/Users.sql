CREATE TABLE [dbo].[Users]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Username] NCHAR(50) NOT NULL UNIQUE, 
    [EmailAddres] NCHAR(100) NOT NULL, 
    [Password] NCHAR(70) NOT NULL, 
    [Type] NCHAR(5) NOT NULL CHECK ([Type] IN ('Admin','User')),
)
