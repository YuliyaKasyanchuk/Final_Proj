
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/28/2016 11:30:34
-- Generated from EDMX file: E:\asp.net\TestingSystem-master\TestingSystem-master\InternetApp\DataBaseModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [InternetApp.DataBaseModel];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_TestBlockTest]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TestSet] DROP CONSTRAINT [FK_TestBlockTest];
GO
IF OBJECT_ID(N'[dbo].[FK_TestQuestion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[QuestionSet] DROP CONSTRAINT [FK_TestQuestion];
GO
IF OBJECT_ID(N'[dbo].[FK_QuestionAnswer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AnswerSet] DROP CONSTRAINT [FK_QuestionAnswer];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[TestBlockSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TestBlockSet];
GO
IF OBJECT_ID(N'[dbo].[TestSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TestSet];
GO
IF OBJECT_ID(N'[dbo].[QuestionSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[QuestionSet];
GO
IF OBJECT_ID(N'[dbo].[AnswerSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AnswerSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'TestBlockSet'
CREATE TABLE [dbo].[TestBlockSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'TestSet'
CREATE TABLE [dbo].[TestSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [BeginDate] nvarchar(max)  NOT NULL,
    [EndDate] nvarchar(max)  NOT NULL,
    [IsPublic] bit  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [TestBlock_Id] int  NOT NULL
);
GO

-- Creating table 'QuestionSet'
CREATE TABLE [dbo].[QuestionSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [IsCheckedBuComputer] bit  NOT NULL,
    [Text] nvarchar(max)  NOT NULL,
    [Test_Id] int  NOT NULL
);
GO

-- Creating table 'AnswerSet'
CREATE TABLE [dbo].[AnswerSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [IsRight] bit  NOT NULL,
    [Text] nvarchar(max)  NOT NULL,
    [Question_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'TestBlockSet'
ALTER TABLE [dbo].[TestBlockSet]
ADD CONSTRAINT [PK_TestBlockSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TestSet'
ALTER TABLE [dbo].[TestSet]
ADD CONSTRAINT [PK_TestSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'QuestionSet'
ALTER TABLE [dbo].[QuestionSet]
ADD CONSTRAINT [PK_QuestionSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AnswerSet'
ALTER TABLE [dbo].[AnswerSet]
ADD CONSTRAINT [PK_AnswerSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [TestBlock_Id] in table 'TestSet'
ALTER TABLE [dbo].[TestSet]
ADD CONSTRAINT [FK_TestBlockTest]
    FOREIGN KEY ([TestBlock_Id])
    REFERENCES [dbo].[TestBlockSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TestBlockTest'
CREATE INDEX [IX_FK_TestBlockTest]
ON [dbo].[TestSet]
    ([TestBlock_Id]);
GO

-- Creating foreign key on [Test_Id] in table 'QuestionSet'
ALTER TABLE [dbo].[QuestionSet]
ADD CONSTRAINT [FK_TestQuestion]
    FOREIGN KEY ([Test_Id])
    REFERENCES [dbo].[TestSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TestQuestion'
CREATE INDEX [IX_FK_TestQuestion]
ON [dbo].[QuestionSet]
    ([Test_Id]);
GO

-- Creating foreign key on [Question_Id] in table 'AnswerSet'
ALTER TABLE [dbo].[AnswerSet]
ADD CONSTRAINT [FK_QuestionAnswer]
    FOREIGN KEY ([Question_Id])
    REFERENCES [dbo].[QuestionSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_QuestionAnswer'
CREATE INDEX [IX_FK_QuestionAnswer]
ON [dbo].[AnswerSet]
    ([Question_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------