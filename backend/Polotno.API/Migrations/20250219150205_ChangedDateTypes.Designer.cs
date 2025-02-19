﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Polotno.API.Models;

#nullable disable

namespace Polotno.API.Migrations
{
    [DbContext(typeof(PolotnoContext))]
    [Migration("20250219150205_ChangedDateTypes")]
    partial class ChangedDateTypes
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("utf8mb4_0900_ai_ci")
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.HasCharSet(modelBuilder, "utf8mb4");
            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Polotno.API.Models.Answer", b =>
                {
                    b.Property<int>("AnswerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("answer_id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("AnswerId"));

                    b.Property<string>("AnswerText")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("answer_text");

                    b.Property<bool?>("IsCorrect")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("is_correct")
                        .HasDefaultValueSql("'0'");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int")
                        .HasColumnName("question_id");

                    b.HasKey("AnswerId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "QuestionId" }, "question_id");

                    b.ToTable("answer", (string)null);
                });

            modelBuilder.Entity("Polotno.API.Models.ArtMovement", b =>
                {
                    b.Property<int>("MovementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("movement_id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("MovementId"));

                    b.Property<string>("MovementDescription")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("movement_description");

                    b.Property<string>("MovementName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("movement_name");

                    b.HasKey("MovementId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "MovementName" }, "idx_movement_name")
                        .IsUnique();

                    b.ToTable("art_movement", (string)null);
                });

            modelBuilder.Entity("Polotno.API.Models.Artist", b =>
                {
                    b.Property<int>("ArtistId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("artist_id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("ArtistId"));

                    b.Property<string>("Bio")
                        .HasColumnType("text")
                        .HasColumnName("bio");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("date_of_birth");

                    b.Property<DateTime?>("DateOfDeath")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("date_of_death");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("first_name");

                    b.Property<int?>("GenreId")
                        .HasColumnType("int")
                        .HasColumnName("genre_id");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("last_name");

                    b.Property<int?>("MovementId")
                        .HasColumnType("int")
                        .HasColumnName("movement_id");

                    b.Property<string>("PathToTheImage")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("path_to_the_image");

                    b.Property<string>("PlaceOfBirth")
                        .HasColumnType("text")
                        .HasColumnName("place_of_birth");

                    b.HasKey("ArtistId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "GenreId" }, "genre_id");

                    b.HasIndex(new[] { "FirstName" }, "idx_artist_first_name");

                    b.HasIndex(new[] { "LastName" }, "idx_artist_last_name");

                    b.HasIndex(new[] { "MovementId" }, "movement_id");

                    b.ToTable("artist", (string)null);
                });

            modelBuilder.Entity("Polotno.API.Models.Favorite", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.Property<int>("PaintingId")
                        .HasColumnType("int")
                        .HasColumnName("painting_id");

                    b.Property<DateTime>("AddedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp")
                        .HasColumnName("added_at")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("UserId", "PaintingId")
                        .HasName("PRIMARY")
                        .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                    b.HasIndex(new[] { "PaintingId" }, "painting_id");

                    b.ToTable("favorite", (string)null);
                });

            modelBuilder.Entity("Polotno.API.Models.Genre", b =>
                {
                    b.Property<int>("GenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("genre_id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("GenreId"));

                    b.Property<string>("GenreDescription")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("genre_description");

                    b.Property<string>("GenreName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("genre_name");

                    b.HasKey("GenreId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "GenreName" }, "genre_name")
                        .IsUnique();

                    b.ToTable("genre", (string)null);
                });

            modelBuilder.Entity("Polotno.API.Models.Painting", b =>
                {
                    b.Property<int>("PaintingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("painting_id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("PaintingId"));

                    b.Property<int>("ArtistId")
                        .HasColumnType("int")
                        .HasColumnName("artist_id");

                    b.Property<int?>("GenreId")
                        .HasColumnType("int")
                        .HasColumnName("genre_id");

                    b.Property<string>("PaintingDescription")
                        .HasColumnType("text")
                        .HasColumnName("painting_description");

                    b.Property<string>("PaintingName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("painting_name");

                    b.Property<string>("PathToTheImage")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("path_to_the_image");

                    b.Property<int?>("StyleId")
                        .HasColumnType("int")
                        .HasColumnName("style_id");

                    b.Property<int?>("YearCreated")
                        .HasColumnType("int")
                        .HasColumnName("year_created");

                    b.HasKey("PaintingId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "ArtistId" }, "artist_id");

                    b.HasIndex(new[] { "GenreId" }, "genre_id")
                        .HasDatabaseName("genre_id1");

                    b.HasIndex(new[] { "StyleId" }, "style_id");

                    b.ToTable("painting", (string)null);
                });

            modelBuilder.Entity("Polotno.API.Models.Question", b =>
                {
                    b.Property<int>("QuestionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("question_id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("QuestionId"));

                    b.Property<string>("QuestionText")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("question_text");

                    b.Property<int>("TestId")
                        .HasColumnType("int")
                        .HasColumnName("test_id");

                    b.HasKey("QuestionId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "TestId" }, "test_id");

                    b.ToTable("question", (string)null);
                });

            modelBuilder.Entity("Polotno.API.Models.Test", b =>
                {
                    b.Property<int>("TestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("test_id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("TestId"));

                    b.Property<int?>("ArtistId")
                        .HasColumnType("int")
                        .HasColumnName("artist_id");

                    b.Property<int?>("Difficulty")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("difficulty")
                        .HasDefaultValueSql("'1'");

                    b.Property<string>("TestName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("test_name");

                    b.HasKey("TestId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "ArtistId" }, "artist_id")
                        .HasDatabaseName("artist_id1");

                    b.ToTable("test", (string)null);
                });

            modelBuilder.Entity("Polotno.API.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("UserId"));

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("email");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("password_hash");

                    b.Property<string>("PathToTheImage")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("path_to_the_image");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("username");

                    b.HasKey("UserId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "Email" }, "email")
                        .IsUnique();

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("Polotno.API.Models.UserTestResult", b =>
                {
                    b.Property<int>("ResultId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("result_id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("ResultId"));

                    b.Property<DateTime>("CompletionDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp")
                        .HasColumnName("completion_date")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<int>("Score")
                        .HasColumnType("int")
                        .HasColumnName("score");

                    b.Property<int>("TestId")
                        .HasColumnType("int")
                        .HasColumnName("test_id");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.HasKey("ResultId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "TestId" }, "test_id")
                        .HasDatabaseName("test_id1");

                    b.HasIndex(new[] { "UserId" }, "user_id");

                    b.ToTable("user_test_result", (string)null);
                });

            modelBuilder.Entity("Polotno.API.Models.Answer", b =>
                {
                    b.HasOne("Polotno.API.Models.Question", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("answer_ibfk_1");

                    b.Navigation("Question");
                });

            modelBuilder.Entity("Polotno.API.Models.Artist", b =>
                {
                    b.HasOne("Polotno.API.Models.Genre", "Genre")
                        .WithMany("Artists")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .HasConstraintName("artist_ibfk_2");

                    b.HasOne("Polotno.API.Models.ArtMovement", "Movement")
                        .WithMany("Artists")
                        .HasForeignKey("MovementId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .HasConstraintName("artist_ibfk_1");

                    b.Navigation("Genre");

                    b.Navigation("Movement");
                });

            modelBuilder.Entity("Polotno.API.Models.Favorite", b =>
                {
                    b.HasOne("Polotno.API.Models.Painting", "Painting")
                        .WithMany("Favorites")
                        .HasForeignKey("PaintingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("favorite_ibfk_2");

                    b.HasOne("Polotno.API.Models.User", "User")
                        .WithMany("Favorites")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("favorite_ibfk_1");

                    b.Navigation("Painting");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Polotno.API.Models.Painting", b =>
                {
                    b.HasOne("Polotno.API.Models.Artist", "Artist")
                        .WithMany("Paintings")
                        .HasForeignKey("ArtistId")
                        .IsRequired()
                        .HasConstraintName("painting_ibfk_1");

                    b.HasOne("Polotno.API.Models.Genre", "Genre")
                        .WithMany("Paintings")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .HasConstraintName("painting_ibfk_3");

                    b.HasOne("Polotno.API.Models.ArtMovement", "Style")
                        .WithMany("Paintings")
                        .HasForeignKey("StyleId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .HasConstraintName("painting_ibfk_2");

                    b.Navigation("Artist");

                    b.Navigation("Genre");

                    b.Navigation("Style");
                });

            modelBuilder.Entity("Polotno.API.Models.Question", b =>
                {
                    b.HasOne("Polotno.API.Models.Test", "Test")
                        .WithMany("Questions")
                        .HasForeignKey("TestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("question_ibfk_1");

                    b.Navigation("Test");
                });

            modelBuilder.Entity("Polotno.API.Models.Test", b =>
                {
                    b.HasOne("Polotno.API.Models.Artist", "Artist")
                        .WithMany("Tests")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("test_ibfk_1");

                    b.Navigation("Artist");
                });

            modelBuilder.Entity("Polotno.API.Models.UserTestResult", b =>
                {
                    b.HasOne("Polotno.API.Models.Test", "Test")
                        .WithMany("UserTestResults")
                        .HasForeignKey("TestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("user_test_result_ibfk_2");

                    b.HasOne("Polotno.API.Models.User", "User")
                        .WithMany("UserTestResults")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("user_test_result_ibfk_1");

                    b.Navigation("Test");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Polotno.API.Models.ArtMovement", b =>
                {
                    b.Navigation("Artists");

                    b.Navigation("Paintings");
                });

            modelBuilder.Entity("Polotno.API.Models.Artist", b =>
                {
                    b.Navigation("Paintings");

                    b.Navigation("Tests");
                });

            modelBuilder.Entity("Polotno.API.Models.Genre", b =>
                {
                    b.Navigation("Artists");

                    b.Navigation("Paintings");
                });

            modelBuilder.Entity("Polotno.API.Models.Painting", b =>
                {
                    b.Navigation("Favorites");
                });

            modelBuilder.Entity("Polotno.API.Models.Question", b =>
                {
                    b.Navigation("Answers");
                });

            modelBuilder.Entity("Polotno.API.Models.Test", b =>
                {
                    b.Navigation("Questions");

                    b.Navigation("UserTestResults");
                });

            modelBuilder.Entity("Polotno.API.Models.User", b =>
                {
                    b.Navigation("Favorites");

                    b.Navigation("UserTestResults");
                });
#pragma warning restore 612, 618
        }
    }
}
