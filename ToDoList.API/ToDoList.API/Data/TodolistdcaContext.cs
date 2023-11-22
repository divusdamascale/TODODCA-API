using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ToDoList.API.Utils;
using ToDoList.API.Views.Models;

namespace ToDoList.API.Data;

public partial class TodolistdcaContext : DbContext
{

 

    public TodolistdcaContext(DbContextOptions<TodolistdcaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<List> Lists { get; set; }

    public virtual DbSet<Profile> Profiles { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    public virtual DbSet<Views.Models.Task> Tasks { get; set; }

    public virtual DbSet<TaskTag> TaskTags { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<List>(entity =>
        {
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.ListName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StartDate).HasColumnType("datetime");

            entity.HasOne(d => d.User).WithMany(p => p.Lists)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Lists_Users");
        });

        modelBuilder.Entity<Profile>(entity =>
        {
            entity.HasKey(e => e.ProfileId).HasName("PK__Profile__290C88E464F2F0F1");

            entity.ToTable("Profile");

            entity.HasIndex(e => e.UserId, "Index_Profile_1")
                .IsUnique()
                .IsDescending();

            entity.Property(e => e.BirthDate).HasColumnType("date");
            entity.Property(e => e.FirstName).HasMaxLength(30);
            entity.Property(e => e.LastName).HasMaxLength(30);
            entity.Property(e => e.RegisterDate).HasColumnType("date");

            //entity.HasOne(d => d.User).WithOne(p => p.Profile)
            //    .HasForeignKey<Profile>(d => d.UserId)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("FK__Profile__UserId__74AE54BC");
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.HasKey(e => e.TagId).HasName("PK__TAGS__657CF9AC8D24AD7F");

            entity.Property(e => e.TagName)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.User).WithMany(p => p.Tags)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TAGS__UserId__778AC167");
        });

        modelBuilder.Entity<Views.Models.Task>(entity =>
        {
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.TaskName)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.List).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.ListId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tasks_Lists");
        });

        modelBuilder.Entity<TaskTag>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Task_Tags");

            entity.HasOne(d => d.Tag).WithMany()
                .HasForeignKey(d => d.TagId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Task_Tags_TAGS");

            entity.HasOne(d => d.Task).WithMany()
                .HasForeignKey(d => d.TaskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Task_Tags__TaskI__797309D9");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Pass)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
