using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace Polotno.API.Models;

public partial class PolotnoContext : DbContext
{
    public PolotnoContext()
    {
    }

    public PolotnoContext(DbContextOptions<PolotnoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Answer> Answers { get; set; }

    public virtual DbSet<ArtMovement> ArtMovements { get; set; }

    public virtual DbSet<Artist> Artists { get; set; }

    public virtual DbSet<Favorite> Favorites { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Painting> Paintings { get; set; }

    public virtual DbSet<Question> Questions { get; set; }

    public virtual DbSet<Test> Tests { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserTestResult> UserTestResults { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Answer>(entity =>
        {
            entity.HasKey(e => e.AnswerId).HasName("PRIMARY");

            entity.ToTable("answer");

            entity.HasIndex(e => e.QuestionId, "question_id");

            entity.Property(e => e.AnswerId).HasColumnName("answer_id");
            entity.Property(e => e.AnswerText)
                .HasMaxLength(255)
                .HasColumnName("answer_text");
            entity.Property(e => e.IsCorrect)
                .HasDefaultValueSql("'0'")
                .HasColumnName("is_correct");
            entity.Property(e => e.QuestionId).HasColumnName("question_id");

            entity.HasOne(d => d.Question).WithMany(p => p.Answers)
                .HasForeignKey(d => d.QuestionId)
                .HasConstraintName("answer_ibfk_1");
        });

        modelBuilder.Entity<ArtMovement>(entity =>
        {
            entity.HasKey(e => e.MovementId).HasName("PRIMARY");

            entity.ToTable("art_movement");

            entity.HasIndex(e => e.MovementName, "idx_movement_name").IsUnique();

            entity.Property(e => e.MovementId).HasColumnName("movement_id");
            entity.Property(e => e.MovementDescription)
                .HasColumnType("text")
                .HasColumnName("movement_description");
            entity.Property(e => e.MovementName)
                .HasMaxLength(50)
                .HasColumnName("movement_name");
        });

        modelBuilder.Entity<Artist>(entity =>
        {
            entity.HasKey(e => e.ArtistId).HasName("PRIMARY");

            entity.ToTable("artist");

            entity.HasIndex(e => e.GenreId, "genre_id");

            entity.HasIndex(e => e.FirstName, "idx_artist_first_name");

            entity.HasIndex(e => e.LastName, "idx_artist_last_name");

            entity.HasIndex(e => e.MovementId, "movement_id");

            entity.Property(e => e.ArtistId).HasColumnName("artist_id");
            entity.Property(e => e.Bio)
                .HasColumnType("text")
                .HasColumnName("bio");
            entity.Property(e => e.DateOfBirth).HasColumnName("date_of_birth");
            entity.Property(e => e.DateOfDeath).HasColumnName("date_of_death");
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .HasColumnName("first_name");
            entity.Property(e => e.GenreId).HasColumnName("genre_id");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .HasColumnName("last_name");
            entity.Property(e => e.MovementId).HasColumnName("movement_id");
            entity.Property(e => e.PlaceOfBirth)
                .HasColumnType("text")
                .HasColumnName("place_of_birth");

            entity.HasOne(d => d.Genre).WithMany(p => p.Artists)
                .HasForeignKey(d => d.GenreId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("artist_ibfk_2");

            entity.HasOne(d => d.Movement).WithMany(p => p.Artists)
                .HasForeignKey(d => d.MovementId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("artist_ibfk_1");
        });

        modelBuilder.Entity<Favorite>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.PaintingId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("favorite");

            entity.HasIndex(e => e.PaintingId, "painting_id");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.PaintingId).HasColumnName("painting_id");
            entity.Property(e => e.AddedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("added_at");

            entity.HasOne(d => d.Painting).WithMany(p => p.Favorites)
                .HasForeignKey(d => d.PaintingId)
                .HasConstraintName("favorite_ibfk_2");

            entity.HasOne(d => d.User).WithMany(p => p.Favorites)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("favorite_ibfk_1");
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.GenreId).HasName("PRIMARY");

            entity.ToTable("genre");

            entity.HasIndex(e => e.GenreName, "genre_name").IsUnique();

            entity.Property(e => e.GenreId).HasColumnName("genre_id");
            entity.Property(e => e.GenreDescription)
                .HasColumnType("text")
                .HasColumnName("genre_description");
            entity.Property(e => e.GenreName)
                .HasMaxLength(50)
                .HasColumnName("genre_name");
        });

        modelBuilder.Entity<Painting>(entity =>
        {
            entity.HasKey(e => e.PaintingId).HasName("PRIMARY");

            entity.ToTable("painting");

            entity.HasIndex(e => e.ArtistId, "artist_id");

            entity.HasIndex(e => e.GenreId, "genre_id");

            entity.HasIndex(e => e.StyleId, "style_id");

            entity.Property(e => e.PaintingId).HasColumnName("painting_id");
            entity.Property(e => e.ArtistId).HasColumnName("artist_id");
            entity.Property(e => e.GenreId).HasColumnName("genre_id");
            entity.Property(e => e.PaintingDescription)
                .HasColumnType("text")
                .HasColumnName("painting_description");
            entity.Property(e => e.PaintingName)
                .HasMaxLength(100)
                .HasColumnName("painting_name");
            entity.Property(e => e.StyleId).HasColumnName("style_id");
            entity.Property(e => e.YearCreated).HasColumnName("year_created");

            entity.HasOne(d => d.Artist).WithMany(p => p.Paintings)
                .HasForeignKey(d => d.ArtistId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("painting_ibfk_1");

            entity.HasOne(d => d.Genre).WithMany(p => p.Paintings)
                .HasForeignKey(d => d.GenreId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("painting_ibfk_3");

            entity.HasOne(d => d.Style).WithMany(p => p.Paintings)
                .HasForeignKey(d => d.StyleId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("painting_ibfk_2");
        });

        modelBuilder.Entity<Question>(entity =>
        {
            entity.HasKey(e => e.QuestionId).HasName("PRIMARY");

            entity.ToTable("question");

            entity.HasIndex(e => e.TestId, "test_id");

            entity.Property(e => e.QuestionId).HasColumnName("question_id");
            entity.Property(e => e.QuestionText)
                .HasColumnType("text")
                .HasColumnName("question_text");
            entity.Property(e => e.TestId).HasColumnName("test_id");

            entity.HasOne(d => d.Test).WithMany(p => p.Questions)
                .HasForeignKey(d => d.TestId)
                .HasConstraintName("question_ibfk_1");
        });

        modelBuilder.Entity<Test>(entity =>
        {
            entity.HasKey(e => e.TestId).HasName("PRIMARY");

            entity.ToTable("test");

            entity.HasIndex(e => e.ArtistId, "artist_id");

            entity.Property(e => e.TestId).HasColumnName("test_id");
            entity.Property(e => e.ArtistId).HasColumnName("artist_id");
            entity.Property(e => e.Difficulty)
                .HasDefaultValueSql("'1'")
                .HasColumnName("difficulty");
            entity.Property(e => e.TestName)
                .HasMaxLength(100)
                .HasColumnName("test_name");

            entity.HasOne(d => d.Artist).WithMany(p => p.Tests)
                .HasForeignKey(d => d.ArtistId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("test_ibfk_1");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PRIMARY");

            entity.ToTable("users");

            entity.HasIndex(e => e.Email, "email").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .HasColumnName("password_hash");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");
        });

        modelBuilder.Entity<UserTestResult>(entity =>
        {
            entity.HasKey(e => e.ResultId).HasName("PRIMARY");

            entity.ToTable("user_test_result");

            entity.HasIndex(e => e.TestId, "test_id");

            entity.HasIndex(e => e.UserId, "user_id");

            entity.Property(e => e.ResultId).HasColumnName("result_id");
            entity.Property(e => e.CompletionDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("completion_date");
            entity.Property(e => e.Score).HasColumnName("score");
            entity.Property(e => e.TestId).HasColumnName("test_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Test).WithMany(p => p.UserTestResults)
                .HasForeignKey(d => d.TestId)
                .HasConstraintName("user_test_result_ibfk_2");

            entity.HasOne(d => d.User).WithMany(p => p.UserTestResults)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("user_test_result_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
