CREATE TABLE [dbo].[Scores]
(
	[Id] INT NOT NULL IDENTITY , 
    [Username] NCHAR(50) NOT NULL UNIQUE, 
    [Score] INT NOT NULL, 
    CONSTRAINT [FK_Scores_Users] FOREIGN KEY ([Username]) REFERENCES [Users]([Username]), 
    PRIMARY KEY ([Id])
)
