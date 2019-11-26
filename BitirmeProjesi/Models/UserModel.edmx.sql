
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/26/2019 15:30:19
-- Generated from EDMX file: C:\Users\ocan4214\source\repos\BitirmeProjesi\Models\UserModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [C:\USERS\OCAN4214\SOURCE\REPOS\BITIRMEPROJESI\APP_DATA\LOGREGDB.MDF];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_UserPost]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Posts] DROP CONSTRAINT [FK_UserPost];
GO
IF OBJECT_ID(N'[dbo].[FK_RoleUser_Role]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RoleUser] DROP CONSTRAINT [FK_RoleUser_Role];
GO
IF OBJECT_ID(N'[dbo].[FK_RoleUser_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RoleUser] DROP CONSTRAINT [FK_RoleUser_User];
GO
IF OBJECT_ID(N'[dbo].[FK_ProfileUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Profiles] DROP CONSTRAINT [FK_ProfileUser];
GO
IF OBJECT_ID(N'[dbo].[FK_UploadFilePost]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UploadFiles] DROP CONSTRAINT [FK_UploadFilePost];
GO
IF OBJECT_ID(N'[dbo].[FK_FriendUser_Friend]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FriendUser] DROP CONSTRAINT [FK_FriendUser_Friend];
GO
IF OBJECT_ID(N'[dbo].[FK_FriendUser_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FriendUser] DROP CONSTRAINT [FK_FriendUser_User];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Posts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Posts];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[dbo].[Roles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Roles];
GO
IF OBJECT_ID(N'[dbo].[Profiles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Profiles];
GO
IF OBJECT_ID(N'[dbo].[UploadFiles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UploadFiles];
GO
IF OBJECT_ID(N'[dbo].[Friends]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Friends];
GO
IF OBJECT_ID(N'[dbo].[RoleUser]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RoleUser];
GO
IF OBJECT_ID(N'[dbo].[FriendUser]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FriendUser];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Posts'
CREATE TABLE [dbo].[Posts] (
    [PostId] int IDENTITY(1,1) NOT NULL,
    [DateofPost] datetime  NOT NULL,
    [UserMentions] nvarchar(max)  NULL,
    [UserId] int  NOT NULL,
    [ContentofPost] nvarchar(max)  NULL,
    [Likes] int  NULL,
    [Dislikes] int  NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [UserId] int IDENTITY(1,1) NOT NULL,
    [FirstName] varchar(50)  NOT NULL,
    [LastName] varchar(50)  NOT NULL,
    [Email] varchar(max)  NOT NULL,
    [DateOfBirth] datetime  NOT NULL,
    [IsEmailVerified] bit  NOT NULL,
    [ActivationCode] uniqueidentifier  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [ResetPasswordCode] nvarchar(max)  NULL
);
GO

-- Creating table 'Roles'
CREATE TABLE [dbo].[Roles] (
    [RoleId] int IDENTITY(1,1) NOT NULL,
    [RoleType] int  NOT NULL,
    [RoleName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Profiles'
CREATE TABLE [dbo].[Profiles] (
    [ProfileId] int IDENTITY(1,1) NOT NULL,
    [CreateDate] datetime  NULL,
    [LastUpdateDate] datetime  NULL,
    [Avatar] varbinary(max)  NULL,
    [AvatarLocation] nvarchar(max)  NULL,
    [User_UserId] int  NOT NULL
);
GO

-- Creating table 'UploadFiles'
CREATE TABLE [dbo].[UploadFiles] (
    [UploadFileId] int IDENTITY(1,1) NOT NULL,
    [UploadContent] varbinary(max)  NOT NULL,
    [UploadFileType] nvarchar(max)  NOT NULL,
    [Post_PostId] int  NOT NULL
);
GO

-- Creating table 'Friends'
CREATE TABLE [dbo].[Friends] (
    [FriendId] int IDENTITY(1,1) NOT NULL,
    [FirstName] varchar(50)  NOT NULL,
    [LastName] varchar(50)  NOT NULL,
    [DateOfBirth] datetime  NOT NULL,
    [FriendAddDate] datetime  NOT NULL
);
GO

-- Creating table 'Groups'
CREATE TABLE [dbo].[Groups] (
    [GroupId] int IDENTITY(1,1) NOT NULL,
    [CreateDate] datetime  NOT NULL,
    [GroupDescription] nvarchar(max)  NOT NULL,
    [MemberCount] int  NULL,
    [IsPublic] bit  NOT NULL,
    [GroupName] nvarchar(max)  NOT NULL,
    [UpdateDate] datetime  NULL,
    [OwnerId] int  NOT NULL
);
GO

-- Creating table 'GroupThreads'
CREATE TABLE [dbo].[GroupThreads] (
    [GroupDiscussionId] int IDENTITY(1,1) NOT NULL,
    [CreateDate] tinyint  NOT NULL,
    [GroupId] int  NOT NULL,
    [ThreadName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'GroupMessages'
CREATE TABLE [dbo].[GroupMessages] (
    [GroupMessageId] int IDENTITY(1,1) NOT NULL,
    [CreateDate] datetime  NOT NULL,
    [UpdateDate] datetime  NULL,
    [MessageContext] nvarchar(max)  NOT NULL,
    [GroupMemberId] int  NOT NULL,
    [GroupThreadId] int  NOT NULL
);
GO

-- Creating table 'GroupMembers'
CREATE TABLE [dbo].[GroupMembers] (
    [GroupMemberId] int IDENTITY(1,1) NOT NULL,
    [CreateDate] nvarchar(max)  NOT NULL,
    [IsAdmin] bit  NOT NULL,
    [IsApproved] bit  NULL,
    [UserId] int  NOT NULL,
    [GroupId] int  NOT NULL
);
GO

-- Creating table 'RoleUser'
CREATE TABLE [dbo].[RoleUser] (
    [Roles_RoleId] int  NOT NULL,
    [Users_UserId] int  NOT NULL
);
GO

-- Creating table 'FriendUser'
CREATE TABLE [dbo].[FriendUser] (
    [Friends_FriendId] int  NOT NULL,
    [Users_UserId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [PostId] in table 'Posts'
ALTER TABLE [dbo].[Posts]
ADD CONSTRAINT [PK_Posts]
    PRIMARY KEY CLUSTERED ([PostId] ASC);
GO

-- Creating primary key on [UserId] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([UserId] ASC);
GO

-- Creating primary key on [RoleId] in table 'Roles'
ALTER TABLE [dbo].[Roles]
ADD CONSTRAINT [PK_Roles]
    PRIMARY KEY CLUSTERED ([RoleId] ASC);
GO

-- Creating primary key on [ProfileId] in table 'Profiles'
ALTER TABLE [dbo].[Profiles]
ADD CONSTRAINT [PK_Profiles]
    PRIMARY KEY CLUSTERED ([ProfileId] ASC);
GO

-- Creating primary key on [UploadFileId] in table 'UploadFiles'
ALTER TABLE [dbo].[UploadFiles]
ADD CONSTRAINT [PK_UploadFiles]
    PRIMARY KEY CLUSTERED ([UploadFileId] ASC);
GO

-- Creating primary key on [FriendId] in table 'Friends'
ALTER TABLE [dbo].[Friends]
ADD CONSTRAINT [PK_Friends]
    PRIMARY KEY CLUSTERED ([FriendId] ASC);
GO

-- Creating primary key on [GroupId] in table 'Groups'
ALTER TABLE [dbo].[Groups]
ADD CONSTRAINT [PK_Groups]
    PRIMARY KEY CLUSTERED ([GroupId] ASC);
GO

-- Creating primary key on [GroupDiscussionId] in table 'GroupThreads'
ALTER TABLE [dbo].[GroupThreads]
ADD CONSTRAINT [PK_GroupThreads]
    PRIMARY KEY CLUSTERED ([GroupDiscussionId] ASC);
GO

-- Creating primary key on [GroupMessageId] in table 'GroupMessages'
ALTER TABLE [dbo].[GroupMessages]
ADD CONSTRAINT [PK_GroupMessages]
    PRIMARY KEY CLUSTERED ([GroupMessageId] ASC);
GO

-- Creating primary key on [GroupMemberId] in table 'GroupMembers'
ALTER TABLE [dbo].[GroupMembers]
ADD CONSTRAINT [PK_GroupMembers]
    PRIMARY KEY CLUSTERED ([GroupMemberId] ASC);
GO

-- Creating primary key on [Roles_RoleId], [Users_UserId] in table 'RoleUser'
ALTER TABLE [dbo].[RoleUser]
ADD CONSTRAINT [PK_RoleUser]
    PRIMARY KEY CLUSTERED ([Roles_RoleId], [Users_UserId] ASC);
GO

-- Creating primary key on [Friends_FriendId], [Users_UserId] in table 'FriendUser'
ALTER TABLE [dbo].[FriendUser]
ADD CONSTRAINT [PK_FriendUser]
    PRIMARY KEY CLUSTERED ([Friends_FriendId], [Users_UserId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UserId] in table 'Posts'
ALTER TABLE [dbo].[Posts]
ADD CONSTRAINT [FK_UserPost]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserPost'
CREATE INDEX [IX_FK_UserPost]
ON [dbo].[Posts]
    ([UserId]);
GO

-- Creating foreign key on [Roles_RoleId] in table 'RoleUser'
ALTER TABLE [dbo].[RoleUser]
ADD CONSTRAINT [FK_RoleUser_Role]
    FOREIGN KEY ([Roles_RoleId])
    REFERENCES [dbo].[Roles]
        ([RoleId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Users_UserId] in table 'RoleUser'
ALTER TABLE [dbo].[RoleUser]
ADD CONSTRAINT [FK_RoleUser_User]
    FOREIGN KEY ([Users_UserId])
    REFERENCES [dbo].[Users]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RoleUser_User'
CREATE INDEX [IX_FK_RoleUser_User]
ON [dbo].[RoleUser]
    ([Users_UserId]);
GO

-- Creating foreign key on [User_UserId] in table 'Profiles'
ALTER TABLE [dbo].[Profiles]
ADD CONSTRAINT [FK_ProfileUser]
    FOREIGN KEY ([User_UserId])
    REFERENCES [dbo].[Users]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProfileUser'
CREATE INDEX [IX_FK_ProfileUser]
ON [dbo].[Profiles]
    ([User_UserId]);
GO

-- Creating foreign key on [Post_PostId] in table 'UploadFiles'
ALTER TABLE [dbo].[UploadFiles]
ADD CONSTRAINT [FK_UploadFilePost]
    FOREIGN KEY ([Post_PostId])
    REFERENCES [dbo].[Posts]
        ([PostId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UploadFilePost'
CREATE INDEX [IX_FK_UploadFilePost]
ON [dbo].[UploadFiles]
    ([Post_PostId]);
GO

-- Creating foreign key on [Friends_FriendId] in table 'FriendUser'
ALTER TABLE [dbo].[FriendUser]
ADD CONSTRAINT [FK_FriendUser_Friend]
    FOREIGN KEY ([Friends_FriendId])
    REFERENCES [dbo].[Friends]
        ([FriendId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Users_UserId] in table 'FriendUser'
ALTER TABLE [dbo].[FriendUser]
ADD CONSTRAINT [FK_FriendUser_User]
    FOREIGN KEY ([Users_UserId])
    REFERENCES [dbo].[Users]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FriendUser_User'
CREATE INDEX [IX_FK_FriendUser_User]
ON [dbo].[FriendUser]
    ([Users_UserId]);
GO

-- Creating foreign key on [GroupId] in table 'GroupThreads'
ALTER TABLE [dbo].[GroupThreads]
ADD CONSTRAINT [FK_GroupThreadRelation]
    FOREIGN KEY ([GroupId])
    REFERENCES [dbo].[Groups]
        ([GroupId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GroupThreadRelation'
CREATE INDEX [IX_FK_GroupThreadRelation]
ON [dbo].[GroupThreads]
    ([GroupId]);
GO

-- Creating foreign key on [UserId] in table 'GroupMembers'
ALTER TABLE [dbo].[GroupMembers]
ADD CONSTRAINT [FK_UserGroupMember]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserGroupMember'
CREATE INDEX [IX_FK_UserGroupMember]
ON [dbo].[GroupMembers]
    ([UserId]);
GO

-- Creating foreign key on [GroupMemberId] in table 'GroupMessages'
ALTER TABLE [dbo].[GroupMessages]
ADD CONSTRAINT [FK_GroupMemberGroupMessage]
    FOREIGN KEY ([GroupMemberId])
    REFERENCES [dbo].[GroupMembers]
        ([GroupMemberId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GroupMemberGroupMessage'
CREATE INDEX [IX_FK_GroupMemberGroupMessage]
ON [dbo].[GroupMessages]
    ([GroupMemberId]);
GO

-- Creating foreign key on [GroupThreadId] in table 'GroupMessages'
ALTER TABLE [dbo].[GroupMessages]
ADD CONSTRAINT [FK_GroupThreadGroupMessage]
    FOREIGN KEY ([GroupThreadId])
    REFERENCES [dbo].[GroupThreads]
        ([GroupDiscussionId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GroupThreadGroupMessage'
CREATE INDEX [IX_FK_GroupThreadGroupMessage]
ON [dbo].[GroupMessages]
    ([GroupThreadId]);
GO

-- Creating foreign key on [GroupId] in table 'GroupMembers'
ALTER TABLE [dbo].[GroupMembers]
ADD CONSTRAINT [FK_GroupGroupMember]
    FOREIGN KEY ([GroupId])
    REFERENCES [dbo].[Groups]
        ([GroupId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GroupGroupMember'
CREATE INDEX [IX_FK_GroupGroupMember]
ON [dbo].[GroupMembers]
    ([GroupId]);
GO

-- Creating foreign key on [OwnerId] in table 'Groups'
ALTER TABLE [dbo].[Groups]
ADD CONSTRAINT [FK_UserGroup]
    FOREIGN KEY ([OwnerId])
    REFERENCES [dbo].[Users]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserGroup'
CREATE INDEX [IX_FK_UserGroup]
ON [dbo].[Groups]
    ([OwnerId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------