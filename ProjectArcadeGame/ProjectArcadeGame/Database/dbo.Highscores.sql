CREATE TABLE [dbo].[Highscores] (
    [Id]        INT        IDENTITY (1, 1) NOT NULL,
    [Highscore] INT        NOT NULL,
    [Player]    NCHAR (10) NOT NULL,
	[Win/Lose]  NCHAR (4)  NOT NULL,
    [Date]      DATE       NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

