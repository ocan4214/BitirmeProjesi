﻿

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace BitirmeProjesi.Models
{

using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;


public partial class LogRegDBEntities1 : DbContext
{
    public LogRegDBEntities1()
        : base("name=LogRegDBEntities1")
    {

    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        throw new UnintentionalCodeFirstException();
    }


    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Profile> Profiles { get; set; }

    public virtual DbSet<UploadFile> UploadFiles { get; set; }

    public virtual DbSet<Friend> Friends { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<GroupThread> GroupThreads { get; set; }

    public virtual DbSet<GroupMessage> GroupMessages { get; set; }

    public virtual DbSet<GroupMember> GroupMembers { get; set; }

    public virtual DbSet<GroupChat> GroupChats { get; set; }

    public virtual DbSet<Connection> Connections { get; set; }

    public virtual DbSet<GroupChatMessage> GroupChatMessages { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<EventNews> EventNews { get; set; }

    public virtual DbSet<EventNewsFile> EventNewsFiles { get; set; }

}

}

