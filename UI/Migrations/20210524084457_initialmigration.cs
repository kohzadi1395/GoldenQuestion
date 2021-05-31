using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UI.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateUser = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyUser = table.Column<Guid>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    TableId = table.Column<Guid>(nullable: false),
                    TableType = table.Column<int>(nullable: false),
                    CommentText = table.Column<string>(maxLength: 500, nullable: true),
                    IsApproved = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateUser = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyUser = table.Column<Guid>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Name = table.Column<string>(nullable: true),
                    flag = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Exams",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateUser = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyUser = table.Column<Guid>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Name = table.Column<string>(nullable: false),
                    ShowResultAfterTheExam = table.Column<bool>(nullable: true),
                    ShowCorrectAnswerAfterTheExam = table.Column<bool>(nullable: true),
                    ShowCorrectAnswerSameMoment = table.Column<bool>(nullable: true),
                    RedirectOnQuizCompletionToAnotherSite = table.Column<bool>(nullable: true),
                    RedirectOnQuizCompletionToAnotherExam = table.Column<bool>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsRandomQuestions = table.Column<bool>(nullable: false),
                    IsRandomOptions = table.Column<bool>(nullable: false),
                    Logo = table.Column<byte[]>(nullable: true),
                    ShowLogo = table.Column<bool>(nullable: false),
                    ShowProgress = table.Column<bool>(nullable: false),
                    AllowContinuousLater = table.Column<bool>(nullable: false),
                    IsFree = table.Column<bool>(nullable: false),
                    IsPublish = table.Column<bool>(nullable: false),
                    Cost = table.Column<decimal>(nullable: false),
                    ShowQuestionNumber = table.Column<bool>(nullable: false),
                    AllowCut = table.Column<bool>(nullable: false),
                    AllowCopy = table.Column<bool>(nullable: false),
                    AllowPaste = table.Column<bool>(nullable: false),
                    AllowRightClick = table.Column<bool>(nullable: false),
                    AllowPrint = table.Column<bool>(nullable: false),
                    AllowPreviousQuestion = table.Column<bool>(nullable: false),
                    AllowComment = table.Column<bool>(nullable: false),
                    ConfirmSubmit = table.Column<bool>(nullable: false),
                    ConfirmCloseTab = table.Column<bool>(nullable: false),
                    IsCommentNeedApprove = table.Column<bool>(nullable: false),
                    ProjectId = table.Column<Guid>(nullable: true),
                    TimeLimited = table.Column<string>(maxLength: 5, nullable: true),
                    IsTimeLimited = table.Column<bool>(nullable: false),
                    MinimumPassingScore = table.Column<int>(nullable: true),
                    MaximumPassingScore = table.Column<int>(nullable: true),
                    IsDisplayExamTitle = table.Column<bool>(nullable: false),
                    IsQuestionsPerPage = table.Column<bool>(nullable: false),
                    QuestionsPerPage = table.Column<int>(nullable: false),
                    MaximumQuizAttempts = table.Column<int>(nullable: false),
                    IsMaximumQuizAttempts = table.Column<bool>(nullable: false),
                    IsRedirectOnQuizCompletion = table.Column<bool>(nullable: false),
                    RedirectOnQuizCompletionOption = table.Column<string>(nullable: true),
                    RedirectOnQuizCompletionUrl = table.Column<string>(nullable: true),
                    QuestionLayoutOption = table.Column<bool>(nullable: false),
                    IsPageTimeLimits = table.Column<bool>(nullable: false),
                    PageTimeLimits = table.Column<string>(maxLength: 5, nullable: true),
                    ScheduleDateFirst = table.Column<DateTime>(nullable: false),
                    ScheduleTimeFirst = table.Column<string>(maxLength: 5, nullable: true),
                    ScheduleDateSecond = table.Column<DateTime>(nullable: false),
                    ScheduleTimeSecond = table.Column<string>(maxLength: 5, nullable: true),
                    IsPublic = table.Column<bool>(nullable: false),
                    Tags = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateUser = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyUser = table.Column<Guid>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Abbreviation = table.Column<string>(nullable: true),
                    Icon = table.Column<string>(nullable: true),
                    RightToLeft = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LearningQto",
                columns: table => new
                {
                    Like = table.Column<int>(nullable: true),
                    View = table.Column<int>(nullable: true),
                    Rate = table.Column<double>(nullable: true),
                    CommentNumber = table.Column<int>(nullable: true),
                    Html = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    Image = table.Column<byte[]>(nullable: true),
                    Tags = table.Column<string>(nullable: true),
                    LanguageId = table.Column<Guid>(nullable: true),
                    IsPublic = table.Column<bool>(nullable: true),
                    IsFree = table.Column<bool>(nullable: true),
                    IsCommentNeedApprove = table.Column<bool>(nullable: true),
                    AllowComment = table.Column<bool>(nullable: true),
                    ProjectId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "LikeViews",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateUser = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyUser = table.Column<Guid>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    TableId = table.Column<Guid>(nullable: false),
                    TableType = table.Column<int>(nullable: false),
                    LikeViewType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LikeViews", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuestionTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateUser = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyUser = table.Column<Guid>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RateScores",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateUser = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyUser = table.Column<Guid>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Rate = table.Column<double>(nullable: false),
                    TableId = table.Column<Guid>(nullable: false),
                    TableType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RateScores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateUser = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyUser = table.Column<Guid>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserDtos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    ProfileImage = table.Column<byte[]>(nullable: true),
                    GenderId = table.Column<Guid>(nullable: false),
                    CommentId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDtos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserDtos_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateUser = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyUser = table.Column<Guid>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Name = table.Column<string>(nullable: true),
                    CountryId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.Id);
                    table.ForeignKey(
                        name: "FK_States_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExamTakens",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateUser = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyUser = table.Column<Guid>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    TakeExam = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    ExamId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamTakens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExamTakens_Exams_ExamId",
                        column: x => x.ExamId,
                        principalTable: "Exams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Learnings",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateUser = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyUser = table.Column<Guid>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Html = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    Image = table.Column<byte[]>(nullable: true),
                    Tags = table.Column<string>(nullable: true),
                    LanguageId = table.Column<Guid>(nullable: false),
                    IsPublic = table.Column<bool>(nullable: false),
                    IsFree = table.Column<bool>(nullable: false),
                    IsCommentNeedApprove = table.Column<bool>(nullable: false),
                    AllowComment = table.Column<bool>(nullable: false),
                    ProjectId = table.Column<Guid>(nullable: true),
                    StateId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Learnings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Learnings_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Learnings_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateUser = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyUser = table.Column<Guid>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Html = table.Column<string>(nullable: true),
                    LanguageId = table.Column<Guid>(nullable: false),
                    StateId = table.Column<Guid>(nullable: false),
                    Tags = table.Column<string>(nullable: true),
                    IsPublic = table.Column<bool>(nullable: false),
                    QuestionTypeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Questions_QuestionTypes_QuestionTypeId",
                        column: x => x.QuestionTypeId,
                        principalTable: "QuestionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Questions_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExamQuestions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateUser = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyUser = table.Column<Guid>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    QuestionNumber = table.Column<int>(nullable: false),
                    QuestionId = table.Column<Guid>(nullable: false),
                    ExamId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExamQuestions_Exams_ExamId",
                        column: x => x.ExamId,
                        principalTable: "Exams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExamQuestions_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Options",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateUser = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyUser = table.Column<Guid>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Html = table.Column<string>(nullable: true),
                    CorrectOption = table.Column<bool>(nullable: false),
                    QuestionId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Options", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Options_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_TableId_TableType",
                table: "Comments",
                columns: new[] { "TableId", "TableType" })
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_ExamQuestions_ExamId",
                table: "ExamQuestions",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamQuestions_QuestionId",
                table: "ExamQuestions",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Exams_ProjectId",
                table: "Exams",
                column: "ProjectId")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_ExamTakens_ExamId",
                table: "ExamTakens",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_Learnings_LanguageId",
                table: "Learnings",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Learnings_ProjectId",
                table: "Learnings",
                column: "ProjectId")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_Learnings_StateId",
                table: "Learnings",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_LikeViews_TableId_TableType",
                table: "LikeViews",
                columns: new[] { "TableId", "TableType" })
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_Options_QuestionId",
                table: "Options",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_LanguageId",
                table: "Questions",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_QuestionTypeId",
                table: "Questions",
                column: "QuestionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_StateId",
                table: "Questions",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_RateScores_TableId_TableType",
                table: "RateScores",
                columns: new[] { "TableId", "TableType" })
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_States_CountryId",
                table: "States",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDtos_CommentId",
                table: "UserDtos",
                column: "CommentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExamQuestions");

            migrationBuilder.DropTable(
                name: "ExamTakens");

            migrationBuilder.DropTable(
                name: "LearningQto");

            migrationBuilder.DropTable(
                name: "Learnings");

            migrationBuilder.DropTable(
                name: "LikeViews");

            migrationBuilder.DropTable(
                name: "Options");

            migrationBuilder.DropTable(
                name: "RateScores");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "UserDtos");

            migrationBuilder.DropTable(
                name: "Exams");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "QuestionTypes");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
