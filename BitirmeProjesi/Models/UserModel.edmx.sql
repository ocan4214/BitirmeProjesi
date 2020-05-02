
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/02/2020 12:58:25
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
IF OBJECT_ID(N'[dbo].[FK_GroupThreadRelation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GroupThreads] DROP CONSTRAINT [FK_GroupThreadRelation];
GO
IF OBJECT_ID(N'[dbo].[FK_UserGroupMember]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GroupMembers] DROP CONSTRAINT [FK_UserGroupMember];
GO
IF OBJECT_ID(N'[dbo].[FK_GroupMemberGroupMessage]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GroupMessages] DROP CONSTRAINT [FK_GroupMemberGroupMessage];
GO
IF OBJECT_ID(N'[dbo].[FK_GroupThreadGroupMessage]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GroupMessages] DROP CONSTRAINT [FK_GroupThreadGroupMessage];
GO
IF OBJECT_ID(N'[dbo].[FK_GroupGroupMember]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GroupMembers] DROP CONSTRAINT [FK_GroupGroupMember];
GO
IF OBJECT_ID(N'[dbo].[FK_UserGroup]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Groups] DROP CONSTRAINT [FK_UserGroup];
GO
IF OBJECT_ID(N'[dbo].[FK_GroupGroupChat]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GroupChats] DROP CONSTRAINT [FK_GroupGroupChat];
GO
IF OBJECT_ID(N'[dbo].[FK_GroupChatConnection]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Connections] DROP CONSTRAINT [FK_GroupChatConnection];
GO
IF OBJECT_ID(N'[dbo].[FK_UserConnection]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Connections] DROP CONSTRAINT [FK_UserConnection];
GO
IF OBJECT_ID(N'[dbo].[FK_GroupChatGroupChatMessage]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GroupChatMessages] DROP CONSTRAINT [FK_GroupChatGroupChatMessage];
GO
IF OBJECT_ID(N'[dbo].[FK_GroupEvent]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Events] DROP CONSTRAINT [FK_GroupEvent];
GO
IF OBJECT_ID(N'[dbo].[FK_EventGroupMember_Event]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EventGroupMember] DROP CONSTRAINT [FK_EventGroupMember_Event];
GO
IF OBJECT_ID(N'[dbo].[FK_EventGroupMember_GroupMember]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EventGroupMember] DROP CONSTRAINT [FK_EventGroupMember_GroupMember];
GO
IF OBJECT_ID(N'[dbo].[FK_EventEventNews]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EventNews] DROP CONSTRAINT [FK_EventEventNews];
GO
IF OBJECT_ID(N'[dbo].[FK_EventNewsFileEventNews]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EventNewsFiles] DROP CONSTRAINT [FK_EventNewsFileEventNews];
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
IF OBJECT_ID(N'[dbo].[Groups]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Groups];
GO
IF OBJECT_ID(N'[dbo].[GroupThreads]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GroupThreads];
GO
IF OBJECT_ID(N'[dbo].[GroupMessages]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GroupMessages];
GO
IF OBJECT_ID(N'[dbo].[GroupMembers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GroupMembers];
GO
IF OBJECT_ID(N'[dbo].[GroupChats]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GroupChats];
GO
IF OBJECT_ID(N'[dbo].[Connections]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Connections];
GO
IF OBJECT_ID(N'[dbo].[GroupChatMessages]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GroupChatMessages];
GO
IF OBJECT_ID(N'[dbo].[Events]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Events];
GO
IF OBJECT_ID(N'[dbo].[EventNews]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EventNews];
GO
IF OBJECT_ID(N'[dbo].[EventNewsFiles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EventNewsFiles];
GO
IF OBJECT_ID(N'[dbo].[RoleUser]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RoleUser];
GO
IF OBJECT_ID(N'[dbo].[FriendUser]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FriendUser];
GO
IF OBJECT_ID(N'[dbo].[EventGroupMember]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EventGroupMember];
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
    [UserName] nvarchar(max)  NOT NULL,
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
    [GroupType] nvarchar(max)  NOT NULL,
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
    [IsApproved] bit  NOT NULL,
    [UserId] int  NOT NULL,
    [GroupId] int  NOT NULL
);
GO

-- Creating table 'GroupChats'
CREATE TABLE [dbo].[GroupChats] (
    [GroupChatId] int IDENTITY(1,1) NOT NULL,
    [GroupChatName] nvarchar(max)  NOT NULL,
    [IsPublic] bit  NOT NULL,
    [GroupId] int  NOT NULL
);
GO

-- Creating table 'Connections'
CREATE TABLE [dbo].[Connections] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ConnectionId] nchar(4000)  NOT NULL,
    [isConnected] bit  NOT NULL,
    [UserId] int  NOT NULL,
    [GroupChatId] int  NOT NULL
);
GO

-- Creating table 'GroupChatMessages'
CREATE TABLE [dbo].[GroupChatMessages] (
    [ChatMessageId] int IDENTITY(1,1) NOT NULL,
    [ChatMessage] nvarchar(max)  NOT NULL,
    [PostDate] datetime  NOT NULL,
    [Username] nvarchar(max)  NOT NULL,
    [GroupChatId] int  NOT NULL
);
GO

-- Creating table 'Events'
CREATE TABLE [dbo].[Events] (
    [EventId] int IDENTITY(1,1) NOT NULL,
    [EventCreateDate] datetime  NOT NULL,
    [EventUpdateDate] datetime  NOT NULL,
    [EventDefinition] nvarchar(max)  NOT NULL,
    [EventTopic] nvarchar(max)  NOT NULL,
    [EventLocation] nvarchar(max)  NOT NULL,
    [EventBeginDate] datetime  NOT NULL,
    [EventThumbnail] varbinary(max)  NOT NULL,
    [EventGroup] int  NOT NULL,
    [EventTime] datetime  NOT NULL
);
GO

-- Creating table 'EventNews'
CREATE TABLE [dbo].[EventNews] (
    [EventNewsId] int IDENTITY(1,1) NOT NULL,
    [EventMessage] nvarchar(max)  NOT NULL,
    [EventNewsTopic] nvarchar(max)  NOT NULL,
    [CreateDate] datetime  NOT NULL,
    [EventId] int  NOT NULL
);
GO

-- Creating table 'EventNewsFiles'
CREATE TABLE [dbo].[EventNewsFiles] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FileContent] varbinary(max)  NOT NULL,
    [EventNewsEventNewsId] int  NOT NULL
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

-- Creating table 'EventGroupMember'
CREATE TABLE [dbo].[EventGroupMember] (
    [Events_EventId] int  NOT NULL,
    [GroupMembers_GroupMemberId] int  NOT NULL
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

-- Creating primary key on [GroupChatId] in table 'GroupChats'
ALTER TABLE [dbo].[GroupChats]
ADD CONSTRAINT [PK_GroupChats]
    PRIMARY KEY CLUSTERED ([GroupChatId] ASC);
GO

-- Creating primary key on [Id] in table 'Connections'
ALTER TABLE [dbo].[Connections]
ADD CONSTRAINT [PK_Connections]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [ChatMessageId] in table 'GroupChatMessages'
ALTER TABLE [dbo].[GroupChatMessages]
ADD CONSTRAINT [PK_GroupChatMessages]
    PRIMARY KEY CLUSTERED ([ChatMessageId] ASC);
GO

-- Creating primary key on [EventId] in table 'Events'
ALTER TABLE [dbo].[Events]
ADD CONSTRAINT [PK_Events]
    PRIMARY KEY CLUSTERED ([EventId] ASC);
GO

-- Creating primary key on [EventNewsId] in table 'EventNews'
ALTER TABLE [dbo].[EventNews]
ADD CONSTRAINT [PK_EventNews]
    PRIMARY KEY CLUSTERED ([EventNewsId] ASC);
GO

-- Creating primary key on [Id] in table 'EventNewsFiles'
ALTER TABLE [dbo].[EventNewsFiles]
ADD CONSTRAINT [PK_EventNewsFiles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
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

-- Creating primary key on [Events_EventId], [GroupMembers_GroupMemberId] in table 'EventGroupMember'
ALTER TABLE [dbo].[EventGroupMember]
ADD CONSTRAINT [PK_EventGroupMember]
    PRIMARY KEY CLUSTERED ([Events_EventId], [GroupMembers_GroupMemberId] ASC);
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

-- Creating foreign key on [GroupId] in table 'GroupChats'
ALTER TABLE [dbo].[GroupChats]
ADD CONSTRAINT [FK_GroupGroupChat]
    FOREIGN KEY ([GroupId])
    REFERENCES [dbo].[Groups]
        ([GroupId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GroupGroupChat'
CREATE INDEX [IX_FK_GroupGroupChat]
ON [dbo].[GroupChats]
    ([GroupId]);
GO

-- Creating foreign key on [GroupChatId] in table 'Connections'
ALTER TABLE [dbo].[Connections]
ADD CONSTRAINT [FK_GroupChatConnection]
    FOREIGN KEY ([GroupChatId])
    REFERENCES [dbo].[GroupChats]
        ([GroupChatId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GroupChatConnection'
CREATE INDEX [IX_FK_GroupChatConnection]
ON [dbo].[Connections]
    ([GroupChatId]);
GO

-- Creating foreign key on [UserId] in table 'Connections'
ALTER TABLE [dbo].[Connections]
ADD CONSTRAINT [FK_UserConnection]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserConnection'
CREATE INDEX [IX_FK_UserConnection]
ON [dbo].[Connections]
    ([UserId]);
GO

-- Creating foreign key on [GroupChatId] in table 'GroupChatMessages'
ALTER TABLE [dbo].[GroupChatMessages]
ADD CONSTRAINT [FK_GroupChatGroupChatMessage]
    FOREIGN KEY ([GroupChatId])
    REFERENCES [dbo].[GroupChats]
        ([GroupChatId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GroupChatGroupChatMessage'
CREATE INDEX [IX_FK_GroupChatGroupChatMessage]
ON [dbo].[GroupChatMessages]
    ([GroupChatId]);
GO

-- Creating foreign key on [EventGroup] in table 'Events'
ALTER TABLE [dbo].[Events]
ADD CONSTRAINT [FK_GroupEvent]
    FOREIGN KEY ([EventGroup])
    REFERENCES [dbo].[Groups]
        ([GroupId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GroupEvent'
CREATE INDEX [IX_FK_GroupEvent]
ON [dbo].[Events]
    ([EventGroup]);
GO

-- Creating foreign key on [Events_EventId] in table 'EventGroupMember'
ALTER TABLE [dbo].[EventGroupMember]
ADD CONSTRAINT [FK_EventGroupMember_Event]
    FOREIGN KEY ([Events_EventId])
    REFERENCES [dbo].[Events]
        ([EventId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [GroupMembers_GroupMemberId] in table 'EventGroupMember'
ALTER TABLE [dbo].[EventGroupMember]
ADD CONSTRAINT [FK_EventGroupMember_GroupMember]
    FOREIGN KEY ([GroupMembers_GroupMemberId])
    REFERENCES [dbo].[GroupMembers]
        ([GroupMemberId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EventGroupMember_GroupMember'
CREATE INDEX [IX_FK_EventGroupMember_GroupMember]
ON [dbo].[EventGroupMember]
    ([GroupMembers_GroupMemberId]);
GO

-- Creating foreign key on [EventId] in table 'EventNews'
ALTER TABLE [dbo].[EventNews]
ADD CONSTRAINT [FK_EventEventNews]
    FOREIGN KEY ([EventId])
    REFERENCES [dbo].[Events]
        ([EventId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EventEventNews'
CREATE INDEX [IX_FK_EventEventNews]
ON [dbo].[EventNews]
    ([EventId]);
GO

-- Creating foreign key on [EventNewsEventNewsId] in table 'EventNewsFiles'
ALTER TABLE [dbo].[EventNewsFiles]
ADD CONSTRAINT [FK_EventNewsFileEventNews]
    FOREIGN KEY ([EventNewsEventNewsId])
    REFERENCES [dbo].[EventNews]
        ([EventNewsId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EventNewsFileEventNews'
CREATE INDEX [IX_FK_EventNewsFileEventNews]
ON [dbo].[EventNewsFiles]
    ([EventNewsEventNewsId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------