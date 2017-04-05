
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/12/2017 11:23:49
-- Generated from EDMX file: C:\Users\jkoort\Desktop\csharp\ForeverNotes\ForeverNotes\Domain\NotesBaseModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ForeverNotes];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_GroupConnection_ToNote]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GroupConnection] DROP CONSTRAINT [FK_GroupConnection_ToNote];
GO
IF OBJECT_ID(N'[dbo].[FK_GroupConnection_ToNoteGroup]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GroupConnection] DROP CONSTRAINT [FK_GroupConnection_ToNoteGroup];
GO
IF OBJECT_ID(N'[dbo].[FK_TagConnection_Note]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TagConnection] DROP CONSTRAINT [FK_TagConnection_Note];
GO
IF OBJECT_ID(N'[dbo].[FK_TagConnection_Tag]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TagConnection] DROP CONSTRAINT [FK_TagConnection_Tag];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[GroupConnection]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GroupConnection];
GO
IF OBJECT_ID(N'[dbo].[Note]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Note];
GO
IF OBJECT_ID(N'[dbo].[NoteGroup]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NoteGroup];
GO
IF OBJECT_ID(N'[dbo].[Tag]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tag];
GO
IF OBJECT_ID(N'[dbo].[TagConnection]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TagConnection];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'GroupConnection'
CREATE TABLE [dbo].[GroupConnection] (
    [GroupConnectionID] int IDENTITY(1,1) NOT NULL,
    [NoteID] int  NOT NULL,
    [NoteGroupID] int  NOT NULL
);
GO

-- Creating table 'Note'
CREATE TABLE [dbo].[Note] (
    [NoteID] int  NOT NULL,
    [Heading] nvarchar(128)  NOT NULL,
    [Content] varchar(max)  NULL,
    [DateCreated] datetime  NOT NULL,
    [DateModified] datetime  NOT NULL
);
GO

-- Creating table 'NoteGroup'
CREATE TABLE [dbo].[NoteGroup] (
    [NoteGroupID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [DateCreated] datetime  NOT NULL,
    [DateModified] datetime  NOT NULL
);
GO

-- Creating table 'Tag'
CREATE TABLE [dbo].[Tag] (
    [TagID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [DateCreated] datetime  NOT NULL,
    [DateModified] datetime  NOT NULL
);
GO

-- Creating table 'TagConnection'
CREATE TABLE [dbo].[TagConnection] (
    [TagConnectionID] int IDENTITY(1,1) NOT NULL,
    [NoteID] int  NOT NULL,
    [TagID] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [GroupConnectionID] in table 'GroupConnection'
ALTER TABLE [dbo].[GroupConnection]
ADD CONSTRAINT [PK_GroupConnection]
    PRIMARY KEY CLUSTERED ([GroupConnectionID] ASC);
GO

-- Creating primary key on [NoteID] in table 'Note'
ALTER TABLE [dbo].[Note]
ADD CONSTRAINT [PK_Note]
    PRIMARY KEY CLUSTERED ([NoteID] ASC);
GO

-- Creating primary key on [NoteGroupID] in table 'NoteGroup'
ALTER TABLE [dbo].[NoteGroup]
ADD CONSTRAINT [PK_NoteGroup]
    PRIMARY KEY CLUSTERED ([NoteGroupID] ASC);
GO

-- Creating primary key on [TagID] in table 'Tag'
ALTER TABLE [dbo].[Tag]
ADD CONSTRAINT [PK_Tag]
    PRIMARY KEY CLUSTERED ([TagID] ASC);
GO

-- Creating primary key on [TagConnectionID] in table 'TagConnection'
ALTER TABLE [dbo].[TagConnection]
ADD CONSTRAINT [PK_TagConnection]
    PRIMARY KEY CLUSTERED ([TagConnectionID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [NoteID] in table 'GroupConnection'
ALTER TABLE [dbo].[GroupConnection]
ADD CONSTRAINT [FK_GroupConnection_ToNote]
    FOREIGN KEY ([NoteID])
    REFERENCES [dbo].[Note]
        ([NoteID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GroupConnection_ToNote'
CREATE INDEX [IX_FK_GroupConnection_ToNote]
ON [dbo].[GroupConnection]
    ([NoteID]);
GO

-- Creating foreign key on [NoteGroupID] in table 'GroupConnection'
ALTER TABLE [dbo].[GroupConnection]
ADD CONSTRAINT [FK_GroupConnection_ToNoteGroup]
    FOREIGN KEY ([NoteGroupID])
    REFERENCES [dbo].[NoteGroup]
        ([NoteGroupID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GroupConnection_ToNoteGroup'
CREATE INDEX [IX_FK_GroupConnection_ToNoteGroup]
ON [dbo].[GroupConnection]
    ([NoteGroupID]);
GO

-- Creating foreign key on [NoteID] in table 'TagConnection'
ALTER TABLE [dbo].[TagConnection]
ADD CONSTRAINT [FK_TagConnection_Note]
    FOREIGN KEY ([NoteID])
    REFERENCES [dbo].[Note]
        ([NoteID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TagConnection_Note'
CREATE INDEX [IX_FK_TagConnection_Note]
ON [dbo].[TagConnection]
    ([NoteID]);
GO

-- Creating foreign key on [TagID] in table 'TagConnection'
ALTER TABLE [dbo].[TagConnection]
ADD CONSTRAINT [FK_TagConnection_Tag]
    FOREIGN KEY ([TagID])
    REFERENCES [dbo].[Tag]
        ([TagID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TagConnection_Tag'
CREATE INDEX [IX_FK_TagConnection_Tag]
ON [dbo].[TagConnection]
    ([TagID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------