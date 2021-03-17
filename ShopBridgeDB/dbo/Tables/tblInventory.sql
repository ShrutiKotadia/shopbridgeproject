CREATE TABLE [dbo].[tblInventory] (
    [inId]          INT             IDENTITY (1, 1) NOT NULL,
    [stName]        NVARCHAR (100)  NULL,
    [stDescription] NVARCHAR (1000) NULL,
    [dcPrice]       DECIMAL (10, 2) NULL,
    [stImageName]   VARCHAR (100)   NULL,
    [flgIsDeleted]  BIT             DEFAULT ((0)) NULL,
    [dtCreatedOn]   DATETIME        DEFAULT (getdate()) NULL,
    [dtModifiedOn]  DATETIME        DEFAULT (getdate()) NULL,
    PRIMARY KEY CLUSTERED ([inId] ASC)
);

