
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/27/2015 14:42:49
-- Generated from EDMX file: C:\NoJohns\NoJohns\NoJohns.API\Models\NoJohnsModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [NoJohns];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ClientsComments]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CommentsSet] DROP CONSTRAINT [FK_ClientsComments];
GO
IF OBJECT_ID(N'[dbo].[FK_ProceduresTypes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProceduresSet] DROP CONSTRAINT [FK_ProceduresTypes];
GO
IF OBJECT_ID(N'[dbo].[FK_ClientsClientsProcedures]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ClientsProceduresSet] DROP CONSTRAINT [FK_ClientsClientsProcedures];
GO
IF OBJECT_ID(N'[dbo].[FK_ProceduresClientsProcedures]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ClientsProceduresSet] DROP CONSTRAINT [FK_ProceduresClientsProcedures];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[ClientsSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ClientsSet];
GO
IF OBJECT_ID(N'[dbo].[CommentsSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CommentsSet];
GO
IF OBJECT_ID(N'[dbo].[TypesSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TypesSet];
GO
IF OBJECT_ID(N'[dbo].[ProceduresSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProceduresSet];
GO
IF OBJECT_ID(N'[dbo].[ClientsProceduresSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ClientsProceduresSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'ClientsSet'
CREATE TABLE [dbo].[ClientsSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Username] nvarchar(50)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [Mail] nvarchar(50)  NOT NULL,
    [fName] nvarchar(max)  NOT NULL,
    [lName] nvarchar(max)  NOT NULL,
    [Address] nvarchar(max)  NULL,
    [Phone] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CommentsSet'
CREATE TABLE [dbo].[CommentsSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ClientId] int  NOT NULL,
    [Comment] nvarchar(max)  NOT NULL,
    [ClientType] bit  NOT NULL
);
GO

-- Creating table 'TypesSet'
CREATE TABLE [dbo].[TypesSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ProcedureName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ProceduresSet'
CREATE TABLE [dbo].[ProceduresSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [TypesId] int  NOT NULL,
    [Price] decimal(18,0)  NOT NULL,
    [Status] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ClientsProceduresSet'
CREATE TABLE [dbo].[ClientsProceduresSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ClientType] bit  NOT NULL,
    [ClientId] int  NOT NULL,
    [ProcedureId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'ClientsSet'
ALTER TABLE [dbo].[ClientsSet]
ADD CONSTRAINT [PK_ClientsSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CommentsSet'
ALTER TABLE [dbo].[CommentsSet]
ADD CONSTRAINT [PK_CommentsSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TypesSet'
ALTER TABLE [dbo].[TypesSet]
ADD CONSTRAINT [PK_TypesSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProceduresSet'
ALTER TABLE [dbo].[ProceduresSet]
ADD CONSTRAINT [PK_ProceduresSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ClientsProceduresSet'
ALTER TABLE [dbo].[ClientsProceduresSet]
ADD CONSTRAINT [PK_ClientsProceduresSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ClientId] in table 'CommentsSet'
ALTER TABLE [dbo].[CommentsSet]
ADD CONSTRAINT [FK_ClientsComments]
    FOREIGN KEY ([ClientId])
    REFERENCES [dbo].[ClientsSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClientsComments'
CREATE INDEX [IX_FK_ClientsComments]
ON [dbo].[CommentsSet]
    ([ClientId]);
GO

-- Creating foreign key on [TypesId] in table 'ProceduresSet'
ALTER TABLE [dbo].[ProceduresSet]
ADD CONSTRAINT [FK_ProceduresTypes]
    FOREIGN KEY ([TypesId])
    REFERENCES [dbo].[TypesSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProceduresTypes'
CREATE INDEX [IX_FK_ProceduresTypes]
ON [dbo].[ProceduresSet]
    ([TypesId]);
GO

-- Creating foreign key on [ClientId] in table 'ClientsProceduresSet'
ALTER TABLE [dbo].[ClientsProceduresSet]
ADD CONSTRAINT [FK_ClientsClientsProcedures]
    FOREIGN KEY ([ClientId])
    REFERENCES [dbo].[ClientsSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClientsClientsProcedures'
CREATE INDEX [IX_FK_ClientsClientsProcedures]
ON [dbo].[ClientsProceduresSet]
    ([ClientId]);
GO

-- Creating foreign key on [ProcedureId] in table 'ClientsProceduresSet'
ALTER TABLE [dbo].[ClientsProceduresSet]
ADD CONSTRAINT [FK_ProceduresClientsProcedures]
    FOREIGN KEY ([ProcedureId])
    REFERENCES [dbo].[ProceduresSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProceduresClientsProcedures'
CREATE INDEX [IX_FK_ProceduresClientsProcedures]
ON [dbo].[ClientsProceduresSet]
    ([ProcedureId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------