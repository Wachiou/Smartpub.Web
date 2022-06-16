using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MVWorkflows.Infrastructure.Migrations
{
    public partial class WorkflowsInitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "RH");

            migrationBuilder.EnsureSchema(
                name: "Workflows");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDepart",
                schema: "Identity",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateEmbauche",
                schema: "Identity",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "JoursDeCongeRestantAvant",
                schema: "Identity",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Matricule",
                schema: "Identity",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Profils",
                schema: "RH",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomProfil = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionProfil = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profils", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeGroupement",
                schema: "RH",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomTypeGroupement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IntituleTypeGroupement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionTypeGroupement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeGroupement", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Workflows",
                schema: "Workflows",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomWorkflow = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionWorkflow = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleWorkflow = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkflowImageUrl = table.Column<string>(type: "text", nullable: true),
                    WorkflowOwnerUserID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workflows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Workflows_Users_WorkflowOwnerUserID",
                        column: x => x.WorkflowOwnerUserID,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Groupement",
                schema: "RH",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomGroupement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionGroupement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IntituleGroupement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdTypeGroupement = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groupement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Groupement_TypeGroupement_IdTypeGroupement",
                        column: x => x.IdTypeGroupement,
                        principalSchema: "RH",
                        principalTable: "TypeGroupement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkflowInstance",
                schema: "Workflows",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkflowsId = table.Column<int>(type: "int", nullable: false),
                    DateCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WorkflowId = table.Column<int>(type: "int", nullable: true),
                    WorkflowInstantiatorUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DateInitiation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkflowInstance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkflowInstance_Users_WorkflowInstantiatorUserId",
                        column: x => x.WorkflowInstantiatorUserId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkflowInstance_Workflows_WorkflowId",
                        column: x => x.WorkflowId,
                        principalSchema: "Workflows",
                        principalTable: "Workflows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Poste",
                schema: "RH",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PosteActualOwnerUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PosteSuperieurId = table.Column<int>(type: "int", nullable: false),
                    NomPoste = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IntitulePoste = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionPoste = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdGroupement = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Poste", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Poste_Groupement_IdGroupement",
                        column: x => x.IdGroupement,
                        principalSchema: "RH",
                        principalTable: "Groupement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Poste_Poste_PosteSuperieurId",
                        column: x => x.PosteSuperieurId,
                        principalSchema: "RH",
                        principalTable: "Poste",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Poste_Users_PosteActualOwnerUserId",
                        column: x => x.PosteActualOwnerUserId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkflowInstanceActions",
                schema: "Workflows",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActionExecutedByUserID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    WorkflowInstanceId = table.Column<long>(type: "bigint", nullable: false),
                    StateBefore = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StateAfter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Commentaire = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateAction = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEffetNouvelEtat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkflowInstanceActions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkflowInstanceActions_Users_ActionExecutedByUserID",
                        column: x => x.ActionExecutedByUserID,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkflowInstanceActions_WorkflowInstance_WorkflowInstanceId",
                        column: x => x.WorkflowInstanceId,
                        principalSchema: "Workflows",
                        principalTable: "WorkflowInstance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkflowInstanceStakeHolder",
                schema: "Workflows",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StakeHolderUserID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    WorkflowInstanceId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkflowInstanceStakeHolder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkflowInstanceStakeHolder_Users_StakeHolderUserID",
                        column: x => x.StakeHolderUserID,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkflowInstanceStakeHolder_WorkflowInstance_WorkflowInstanceId",
                        column: x => x.WorkflowInstanceId,
                        principalSchema: "Workflows",
                        principalTable: "WorkflowInstance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HistoriqueAffectationPersonnel",
                schema: "RH",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonnelAffecteUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DateAction = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEffetAffectation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PosteSourceId = table.Column<int>(type: "int", nullable: false),
                    PosteDestinationId = table.Column<int>(type: "int", nullable: false),
                    NoteAffectation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoriqueAffectationPersonnel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoriqueAffectationPersonnel_Poste_PosteDestinationId",
                        column: x => x.PosteDestinationId,
                        principalSchema: "RH",
                        principalTable: "Poste",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HistoriqueAffectationPersonnel_Poste_PosteSourceId",
                        column: x => x.PosteSourceId,
                        principalSchema: "RH",
                        principalTable: "Poste",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HistoriqueAffectationPersonnel_Users_PersonnelAffecteUserId",
                        column: x => x.PersonnelAffecteUserId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProfilPoste",
                schema: "RH",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfilId = table.Column<int>(type: "int", nullable: false),
                    PosteId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfilPoste", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfilPoste_Poste_PosteId",
                        column: x => x.PosteId,
                        principalSchema: "RH",
                        principalTable: "Poste",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProfilPoste_Profils_ProfilId",
                        column: x => x.ProfilId,
                        principalSchema: "RH",
                        principalTable: "Profils",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkflowInstanceActionData",
                schema: "Workflows",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WokflowsInstanceActionId = table.Column<long>(type: "bigint", nullable: false),
                    ActionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkflowInstanceActionData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkflowInstanceActionData_WorkflowInstanceActions_WokflowsInstanceActionId",
                        column: x => x.WokflowsInstanceActionId,
                        principalSchema: "Workflows",
                        principalTable: "WorkflowInstanceActions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkflowInstanceActionFile",
                schema: "Workflows",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActionFileRecordedByUserID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    WorkflowInstanceActionsId = table.Column<long>(type: "bigint", nullable: false),
                    ActionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUploaded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileContent = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    MIMEType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkflowInstanceActionFile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkflowInstanceActionFile_Users_ActionFileRecordedByUserID",
                        column: x => x.ActionFileRecordedByUserID,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkflowInstanceActionFile_WorkflowInstanceActions_WorkflowInstanceActionsId",
                        column: x => x.WorkflowInstanceActionsId,
                        principalSchema: "Workflows",
                        principalTable: "WorkflowInstanceActions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkflowInstanceActionNote",
                schema: "Workflows",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActionNoteTakedByUserID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    WorkflowInstanceActionId = table.Column<long>(type: "bigint", nullable: false),
                    WorkflowInstanceActionsId = table.Column<long>(type: "bigint", nullable: true),
                    ActionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkflowInstanceActionNote", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkflowInstanceActionNote_Users_ActionNoteTakedByUserID",
                        column: x => x.ActionNoteTakedByUserID,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkflowInstanceActionNote_WorkflowInstanceActions_WorkflowInstanceActionsId",
                        column: x => x.WorkflowInstanceActionsId,
                        principalSchema: "Workflows",
                        principalTable: "WorkflowInstanceActions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Groupement_IdTypeGroupement",
                schema: "RH",
                table: "Groupement",
                column: "IdTypeGroupement");

            migrationBuilder.CreateIndex(
                name: "IX_HistoriqueAffectationPersonnel_PersonnelAffecteUserId",
                schema: "RH",
                table: "HistoriqueAffectationPersonnel",
                column: "PersonnelAffecteUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoriqueAffectationPersonnel_PosteDestinationId",
                schema: "RH",
                table: "HistoriqueAffectationPersonnel",
                column: "PosteDestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoriqueAffectationPersonnel_PosteSourceId",
                schema: "RH",
                table: "HistoriqueAffectationPersonnel",
                column: "PosteSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Poste_IdGroupement",
                schema: "RH",
                table: "Poste",
                column: "IdGroupement");

            migrationBuilder.CreateIndex(
                name: "IX_Poste_PosteActualOwnerUserId",
                schema: "RH",
                table: "Poste",
                column: "PosteActualOwnerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Poste_PosteSuperieurId",
                schema: "RH",
                table: "Poste",
                column: "PosteSuperieurId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfilPoste_PosteId",
                schema: "RH",
                table: "ProfilPoste",
                column: "PosteId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfilPoste_ProfilId",
                schema: "RH",
                table: "ProfilPoste",
                column: "ProfilId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowInstance_WorkflowId",
                schema: "Workflows",
                table: "WorkflowInstance",
                column: "WorkflowId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowInstance_WorkflowInstantiatorUserId",
                schema: "Workflows",
                table: "WorkflowInstance",
                column: "WorkflowInstantiatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowInstanceActionData_WokflowsInstanceActionId",
                schema: "Workflows",
                table: "WorkflowInstanceActionData",
                column: "WokflowsInstanceActionId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowInstanceActionFile_ActionFileRecordedByUserID",
                schema: "Workflows",
                table: "WorkflowInstanceActionFile",
                column: "ActionFileRecordedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowInstanceActionFile_WorkflowInstanceActionsId",
                schema: "Workflows",
                table: "WorkflowInstanceActionFile",
                column: "WorkflowInstanceActionsId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowInstanceActionNote_ActionNoteTakedByUserID",
                schema: "Workflows",
                table: "WorkflowInstanceActionNote",
                column: "ActionNoteTakedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowInstanceActionNote_WorkflowInstanceActionsId",
                schema: "Workflows",
                table: "WorkflowInstanceActionNote",
                column: "WorkflowInstanceActionsId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowInstanceActions_ActionExecutedByUserID",
                schema: "Workflows",
                table: "WorkflowInstanceActions",
                column: "ActionExecutedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowInstanceActions_WorkflowInstanceId",
                schema: "Workflows",
                table: "WorkflowInstanceActions",
                column: "WorkflowInstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowInstanceStakeHolder_StakeHolderUserID",
                schema: "Workflows",
                table: "WorkflowInstanceStakeHolder",
                column: "StakeHolderUserID");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowInstanceStakeHolder_WorkflowInstanceId",
                schema: "Workflows",
                table: "WorkflowInstanceStakeHolder",
                column: "WorkflowInstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_Workflows_WorkflowOwnerUserID",
                schema: "Workflows",
                table: "Workflows",
                column: "WorkflowOwnerUserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistoriqueAffectationPersonnel",
                schema: "RH");

            migrationBuilder.DropTable(
                name: "ProfilPoste",
                schema: "RH");

            migrationBuilder.DropTable(
                name: "WorkflowInstanceActionData",
                schema: "Workflows");

            migrationBuilder.DropTable(
                name: "WorkflowInstanceActionFile",
                schema: "Workflows");

            migrationBuilder.DropTable(
                name: "WorkflowInstanceActionNote",
                schema: "Workflows");

            migrationBuilder.DropTable(
                name: "WorkflowInstanceStakeHolder",
                schema: "Workflows");

            migrationBuilder.DropTable(
                name: "Poste",
                schema: "RH");

            migrationBuilder.DropTable(
                name: "Profils",
                schema: "RH");

            migrationBuilder.DropTable(
                name: "WorkflowInstanceActions",
                schema: "Workflows");

            migrationBuilder.DropTable(
                name: "Groupement",
                schema: "RH");

            migrationBuilder.DropTable(
                name: "WorkflowInstance",
                schema: "Workflows");

            migrationBuilder.DropTable(
                name: "TypeGroupement",
                schema: "RH");

            migrationBuilder.DropTable(
                name: "Workflows",
                schema: "Workflows");

            migrationBuilder.DropColumn(
                name: "DateDepart",
                schema: "Identity",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DateEmbauche",
                schema: "Identity",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "JoursDeCongeRestantAvant",
                schema: "Identity",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Matricule",
                schema: "Identity",
                table: "Users");
        }
    }
}
