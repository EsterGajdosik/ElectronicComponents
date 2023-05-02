CREATE TABLE [dbo].[stock] (
    [id]           INT           IDENTITY (1, 1) NOT NULL,
    [name]         VARCHAR (100) NOT NULL,
    [manufacturer] VARCHAR (150) NOT NULL,
    [price]        VARCHAR (20)  NULL,
    [address]      VARCHAR (100) NULL,
    [created_at]   DATETIME      DEFAULT (getdate()) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
 
);

