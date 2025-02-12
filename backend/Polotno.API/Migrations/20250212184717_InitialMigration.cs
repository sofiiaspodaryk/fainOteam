using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Polotno.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "art_movement",
                columns: table => new
                {
                    movement_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    movement_name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    movement_description = table.Column<string>(type: "text", nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.movement_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "genre",
                columns: table => new
                {
                    genre_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    genre_name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    genre_description = table.Column<string>(type: "text", nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.genre_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    username = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    password_hash = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    created_at = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.user_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "artist",
                columns: table => new
                {
                    artist_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    first_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    last_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    date_of_birth = table.Column<int>(type: "int", nullable: true),
                    date_of_death = table.Column<int>(type: "int", nullable: true),
                    place_of_birth = table.Column<string>(type: "text", nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    movement_id = table.Column<int>(type: "int", nullable: true),
                    genre_id = table.Column<int>(type: "int", nullable: true),
                    bio = table.Column<string>(type: "text", nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.artist_id);
                    table.ForeignKey(
                        name: "artist_ibfk_1",
                        column: x => x.movement_id,
                        principalTable: "art_movement",
                        principalColumn: "movement_id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "artist_ibfk_2",
                        column: x => x.genre_id,
                        principalTable: "genre",
                        principalColumn: "genre_id",
                        onDelete: ReferentialAction.SetNull);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "painting",
                columns: table => new
                {
                    painting_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    painting_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    artist_id = table.Column<int>(type: "int", nullable: false),
                    style_id = table.Column<int>(type: "int", nullable: true),
                    genre_id = table.Column<int>(type: "int", nullable: true),
                    year_created = table.Column<int>(type: "int", nullable: true),
                    painting_description = table.Column<string>(type: "text", nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.painting_id);
                    table.ForeignKey(
                        name: "painting_ibfk_1",
                        column: x => x.artist_id,
                        principalTable: "artist",
                        principalColumn: "artist_id");
                    table.ForeignKey(
                        name: "painting_ibfk_2",
                        column: x => x.style_id,
                        principalTable: "art_movement",
                        principalColumn: "movement_id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "painting_ibfk_3",
                        column: x => x.genre_id,
                        principalTable: "genre",
                        principalColumn: "genre_id",
                        onDelete: ReferentialAction.SetNull);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "test",
                columns: table => new
                {
                    test_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    test_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    difficulty = table.Column<int>(type: "int", nullable: true, defaultValueSql: "'1'"),
                    artist_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.test_id);
                    table.ForeignKey(
                        name: "test_ibfk_1",
                        column: x => x.artist_id,
                        principalTable: "artist",
                        principalColumn: "artist_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "favorite",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false),
                    painting_id = table.Column<int>(type: "int", nullable: false),
                    added_at = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.user_id, x.painting_id })
                        .Annotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                    table.ForeignKey(
                        name: "favorite_ibfk_1",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "favorite_ibfk_2",
                        column: x => x.painting_id,
                        principalTable: "painting",
                        principalColumn: "painting_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "question",
                columns: table => new
                {
                    question_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    test_id = table.Column<int>(type: "int", nullable: false),
                    question_text = table.Column<string>(type: "text", nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.question_id);
                    table.ForeignKey(
                        name: "question_ibfk_1",
                        column: x => x.test_id,
                        principalTable: "test",
                        principalColumn: "test_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "user_test_result",
                columns: table => new
                {
                    result_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    test_id = table.Column<int>(type: "int", nullable: false),
                    score = table.Column<int>(type: "int", nullable: false),
                    completion_date = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.result_id);
                    table.ForeignKey(
                        name: "user_test_result_ibfk_1",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "user_test_result_ibfk_2",
                        column: x => x.test_id,
                        principalTable: "test",
                        principalColumn: "test_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "answer",
                columns: table => new
                {
                    answer_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    question_id = table.Column<int>(type: "int", nullable: false),
                    answer_text = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    is_correct = table.Column<bool>(type: "tinyint(1)", nullable: true, defaultValueSql: "'0'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.answer_id);
                    table.ForeignKey(
                        name: "answer_ibfk_1",
                        column: x => x.question_id,
                        principalTable: "question",
                        principalColumn: "question_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateIndex(
                name: "question_id",
                table: "answer",
                column: "question_id");

            migrationBuilder.CreateIndex(
                name: "idx_movement_name",
                table: "art_movement",
                column: "movement_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "genre_id",
                table: "artist",
                column: "genre_id");

            migrationBuilder.CreateIndex(
                name: "idx_artist_first_name",
                table: "artist",
                column: "first_name");

            migrationBuilder.CreateIndex(
                name: "idx_artist_last_name",
                table: "artist",
                column: "last_name");

            migrationBuilder.CreateIndex(
                name: "movement_id",
                table: "artist",
                column: "movement_id");

            migrationBuilder.CreateIndex(
                name: "painting_id",
                table: "favorite",
                column: "painting_id");

            migrationBuilder.CreateIndex(
                name: "genre_name",
                table: "genre",
                column: "genre_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "artist_id",
                table: "painting",
                column: "artist_id");

            migrationBuilder.CreateIndex(
                name: "genre_id1",
                table: "painting",
                column: "genre_id");

            migrationBuilder.CreateIndex(
                name: "style_id",
                table: "painting",
                column: "style_id");

            migrationBuilder.CreateIndex(
                name: "test_id",
                table: "question",
                column: "test_id");

            migrationBuilder.CreateIndex(
                name: "artist_id1",
                table: "test",
                column: "artist_id");

            migrationBuilder.CreateIndex(
                name: "test_id1",
                table: "user_test_result",
                column: "test_id");

            migrationBuilder.CreateIndex(
                name: "user_id",
                table: "user_test_result",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "email",
                table: "users",
                column: "email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "answer");

            migrationBuilder.DropTable(
                name: "favorite");

            migrationBuilder.DropTable(
                name: "user_test_result");

            migrationBuilder.DropTable(
                name: "question");

            migrationBuilder.DropTable(
                name: "painting");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "test");

            migrationBuilder.DropTable(
                name: "artist");

            migrationBuilder.DropTable(
                name: "art_movement");

            migrationBuilder.DropTable(
                name: "genre");
        }
    }
}
