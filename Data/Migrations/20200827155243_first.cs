using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MicrobiologyLab.Data.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Researcher",
                columns: table => new
                {
                    rid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    reseacher_name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Researcher", x => x.rid);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true),
                    role = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Accident",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Id = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: true),
                    time = table.Column<DateTime>(nullable: false),
                    type = table.Column<string>(nullable: true),
                    damages = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accident", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accident_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Assesment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TraineeName = table.Column<string>(nullable: true),
                    StudentName = table.Column<string>(nullable: true),
                    quality = table.Column<int>(nullable: false),
                    quantity = table.Column<int>(nullable: false),
                    work_habits = table.Column<int>(nullable: false),
                    communication = table.Column<int>(nullable: false),
                    attitude = table.Column<int>(nullable: false),
                    professionalism = table.Column<int>(nullable: false),
                    leadership = table.Column<int>(nullable: false),
                    User_Id = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assesment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assesment_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AttendanceAssistant",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Arrival_Time = table.Column<DateTime>(nullable: false),
                    Leaving_Time = table.Column<DateTime>(nullable: false),
                    date = table.Column<DateTime>(nullable: false),
                    User_Id = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendanceAssistant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttendanceAssistant_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AttendanceHK",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hour_1 = table.Column<DateTime>(nullable: false),
                    Hour_2 = table.Column<DateTime>(nullable: false),
                    date = table.Column<DateTime>(nullable: false),
                    User_Id = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendanceHK", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttendanceHK_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AttendanceM2",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Arrv_Time = table.Column<DateTime>(nullable: false),
                    Leav_Time = table.Column<DateTime>(nullable: false),
                    date = table.Column<DateTime>(nullable: false),
                    User_Id = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendanceM2", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttendanceM2_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AttendancePHD",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Arrv_Time = table.Column<DateTime>(nullable: false),
                    Leav_Time = table.Column<DateTime>(nullable: false),
                    date = table.Column<DateTime>(nullable: false),
                    User_Id = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendancePHD", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttendancePHD_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AttendancePHDSt",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Arrv_Time = table.Column<DateTime>(nullable: false),
                    Leav_Time = table.Column<DateTime>(nullable: false),
                    date = table.Column<DateTime>(nullable: false),
                    User_Id = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendancePHDSt", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttendancePHDSt_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AttendanceTrainee",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Arrv_Time = table.Column<DateTime>(nullable: false),
                    Leav_Time = table.Column<DateTime>(nullable: false),
                    date = table.Column<DateTime>(nullable: false),
                    User_Id = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendanceTrainee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttendanceTrainee_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BorrowPermission",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Id = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: true),
                    Pos = table.Column<string>(nullable: true),
                    Pro_name = table.Column<string>(nullable: true),
                    Borr_Object = table.Column<string>(nullable: true),
                    quantity = table.Column<int>(nullable: false),
                    Return_Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BorrowPermission", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BorrowPermission_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Collaboration",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Id = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: true),
                    Col_name = table.Column<string>(nullable: true),
                    institute = table.Column<string>(nullable: true),
                    proj_Title = table.Column<string>(nullable: true),
                    Compounds = table.Column<string>(nullable: true),
                    Position = table.Column<string>(nullable: true),
                    Test = table.Column<string>(nullable: true),
                    date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collaboration", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Collaboration_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Comp_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    num = table.Column<long>(nullable: false),
                    Fax = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    Add = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Comp_Id);
                    table.ForeignKey(
                        name: "FK_Company_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FreeForm",
                columns: table => new
                {
                    ff_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Id = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: true),
                    acceptance = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FreeForm", x => x.ff_Id);
                    table.ForeignKey(
                        name: "FK_FreeForm_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InternshipRequest",
                columns: table => new
                {
                    intr_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    student_id = table.Column<int>(nullable: false),
                    phone_number = table.Column<string>(nullable: false),
                    email = table.Column<string>(nullable: false),
                    photo = table.Column<string>(nullable: false),
                    place = table.Column<string>(nullable: false),
                    fundingDuration = table.Column<string>(nullable: false),
                    signature = table.Column<string>(nullable: false),
                    id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternshipRequest", x => x.intr_id);
                    table.ForeignKey(
                        name: "FK_InternshipRequest_User_id",
                        column: x => x.id,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MeetingRR",
                columns: table => new
                {
                    mrrId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    hour = table.Column<string>(nullable: false),
                    date = table.Column<DateTime>(nullable: false),
                    objective = table.Column<string>(nullable: false),
                    summary = table.Column<string>(nullable: false),
                    id = table.Column<int>(nullable: false),
                    MeetingRRmrrId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetingRR", x => x.mrrId);
                    table.ForeignKey(
                        name: "FK_MeetingRR_MeetingRR_MeetingRRmrrId",
                        column: x => x.MeetingRRmrrId,
                        principalTable: "MeetingRR",
                        principalColumn: "mrrId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MeetingRR_User_id",
                        column: x => x.id,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MembershipRequest",
                columns: table => new
                {
                    mr_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    signature = table.Column<string>(nullable: false),
                    id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembershipRequest", x => x.mr_id);
                    table.ForeignKey(
                        name: "FK_MembershipRequest_User_id",
                        column: x => x.id,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PrintingPermission",
                columns: table => new
                {
                    printing_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    page_number = table.Column<int>(nullable: false),
                    coloredOrNot = table.Column<int>(nullable: false),
                    id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrintingPermission", x => x.printing_id);
                    table.ForeignKey(
                        name: "FK_PrintingPermission_User_id",
                        column: x => x.id,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    proj_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    funding_organism = table.Column<string>(nullable: false),
                    funding_duration = table.Column<string>(nullable: false),
                    fund_amount = table.Column<string>(nullable: false),
                    from = table.Column<string>(nullable: false),
                    to = table.Column<string>(nullable: false),
                    reasearchAssistantFees = table.Column<string>(nullable: false),
                    congress = table.Column<int>(nullable: false),
                    fieldFees = table.Column<int>(nullable: false),
                    publicationAndPatentFees = table.Column<int>(nullable: false),
                    consumables = table.Column<int>(nullable: false),
                    machinesAndEquipements = table.Column<int>(nullable: false),
                    others = table.Column<int>(nullable: false),
                    id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.proj_id);
                    table.ForeignKey(
                        name: "FK_Project_User_id",
                        column: x => x.id,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rotation",
                columns: table => new
                {
                    rot_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    entrancePermission = table.Column<string>(nullable: false),
                    photosAndDemandLetter = table.Column<string>(nullable: false),
                    inventory = table.Column<string>(nullable: false),
                    cafeteriaFees = table.Column<string>(nullable: false),
                    eventsAndCeremonies = table.Column<string>(nullable: false),
                    stockUpdates = table.Column<string>(nullable: false),
                    orderingConsumables = table.Column<string>(nullable: false),
                    month = table.Column<string>(nullable: false),
                    year = table.Column<string>(nullable: false),
                    id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rotation", x => x.rot_id);
                    table.ForeignKey(
                        name: "FK_Rotation_User_id",
                        column: x => x.id,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrainingPreRegistration",
                columns: table => new
                {
                    tpr_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    speciality = table.Column<string>(nullable: true),
                    year = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    phone_number = table.Column<string>(nullable: true),
                    duration = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingPreRegistration", x => x.tpr_id);
                    table.ForeignKey(
                        name: "FK_TrainingPreRegistration_User_user_id",
                        column: x => x.user_id,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkPermission",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    work = table.Column<string>(nullable: true),
                    schedule = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkPermission", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WorkPermission_User_user_id",
                        column: x => x.user_id,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Biowaste",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comp_Id = table.Column<int>(nullable: false),
                    CompanyComp_Id = table.Column<int>(nullable: true),
                    Box_num = table.Column<int>(nullable: false),
                    weight = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Biowaste", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Biowaste_Company_CompanyComp_Id",
                        column: x => x.CompanyComp_Id,
                        principalTable: "Company",
                        principalColumn: "Comp_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IncomingProduct",
                columns: table => new
                {
                    pr_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: false),
                    quantity = table.Column<int>(nullable: false),
                    weight = table.Column<float>(nullable: false),
                    exdate = table.Column<DateTime>(nullable: false),
                    additionnalNotes = table.Column<string>(nullable: false),
                    arrdate = table.Column<DateTime>(nullable: false),
                    id = table.Column<int>(nullable: false),
                    comp_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncomingProduct", x => x.pr_id);
                    table.ForeignKey(
                        name: "FK_IncomingProduct_Company_comp_id",
                        column: x => x.comp_id,
                        principalTable: "Company",
                        principalColumn: "Comp_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IncomingProduct_User_id",
                        column: x => x.id,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    ol_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_name = table.Column<string>(nullable: false),
                    supervisor_name = table.Column<string>(nullable: false),
                    project_name = table.Column<string>(nullable: false),
                    quantity = table.Column<int>(nullable: false),
                    code = table.Column<string>(nullable: false),
                    unit_price = table.Column<string>(nullable: false),
                    funding_duration = table.Column<string>(nullable: false),
                    refrigerationOrNot = table.Column<int>(nullable: false),
                    specifity_notes = table.Column<string>(nullable: false),
                    expiry_date = table.Column<DateTime>(nullable: false),
                    comp_id = table.Column<int>(nullable: false),
                    id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.ol_id);
                    table.ForeignKey(
                        name: "FK_Order_Company_comp_id",
                        column: x => x.comp_id,
                        principalTable: "Company",
                        principalColumn: "Comp_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_User_id",
                        column: x => x.id,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MeetingPresence",
                columns: table => new
                {
                    mpre_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: false),
                    mrrId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetingPresence", x => x.mpre_id);
                    table.ForeignKey(
                        name: "FK_MeetingPresence_MeetingRR_mrrId",
                        column: x => x.mrrId,
                        principalTable: "MeetingRR",
                        principalColumn: "mrrId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Project_Collaboration",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    project_id = table.Column<int>(nullable: false),
                    collaboration_id = table.Column<int>(nullable: false),
                    Projectproj_id = table.Column<int>(nullable: true),
                    CollaborationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project_Collaboration", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Project_Collaboration_Collaboration_CollaborationId",
                        column: x => x.CollaborationId,
                        principalTable: "Collaboration",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Project_Collaboration_Project_Projectproj_id",
                        column: x => x.Projectproj_id,
                        principalTable: "Project",
                        principalColumn: "proj_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Project_Researcher",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    project_id = table.Column<int>(nullable: false),
                    researcher_id = table.Column<int>(nullable: false),
                    Projectproj_id = table.Column<int>(nullable: true),
                    Researcherrid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project_Researcher", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Project_Researcher_Project_Projectproj_id",
                        column: x => x.Projectproj_id,
                        principalTable: "Project",
                        principalColumn: "proj_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Project_Researcher_Researcher_Researcherrid",
                        column: x => x.Researcherrid,
                        principalTable: "Researcher",
                        principalColumn: "rid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Experiment",
                columns: table => new
                {
                    Exp_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<int>(nullable: false),
                    biowasteId = table.Column<int>(nullable: true),
                    Project = table.Column<string>(nullable: true),
                    Superv = table.Column<int>(nullable: false),
                    Desc = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experiment", x => x.Exp_Id);
                    table.ForeignKey(
                        name: "FK_Experiment_Biowaste_biowasteId",
                        column: x => x.biowasteId,
                        principalTable: "Biowaste",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MachinesInventory",
                columns: table => new
                {
                    mid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    furniture_name = table.Column<string>(nullable: false),
                    quantity_micro = table.Column<int>(nullable: false),
                    quantity_mol = table.Column<int>(nullable: false),
                    quantity_cell = table.Column<int>(nullable: false),
                    quantity_myco = table.Column<int>(nullable: false),
                    quantity_storage = table.Column<int>(nullable: false),
                    quantity_refrig = table.Column<int>(nullable: false),
                    quantity_meeting = table.Column<int>(nullable: false),
                    total = table.Column<int>(nullable: false),
                    id = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: true),
                    pr_id = table.Column<int>(nullable: true),
                    incomingProductpr_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachinesInventory", x => x.mid);
                    table.ForeignKey(
                        name: "FK_MachinesInventory_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MachinesInventory_IncomingProduct_incomingProductpr_id",
                        column: x => x.incomingProductpr_id,
                        principalTable: "IncomingProduct",
                        principalColumn: "pr_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OpeningAndClosing",
                columns: table => new
                {
                    oc_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    opening_time = table.Column<DateTime>(nullable: false),
                    closing_time = table.Column<DateTime>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    IncomingProductpr_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpeningAndClosing", x => x.oc_id);
                    table.ForeignKey(
                        name: "FK_OpeningAndClosing_IncomingProduct_IncomingProductpr_id",
                        column: x => x.IncomingProductpr_id,
                        principalTable: "IncomingProduct",
                        principalColumn: "pr_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ConsumedMaterials",
                columns: table => new
                {
                    Con_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Exp_Id = table.Column<int>(nullable: false),
                    ExperimentExp_Id = table.Column<int>(nullable: true),
                    Proj_Id = table.Column<int>(nullable: false),
                    Projectproj_id = table.Column<int>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumedMaterials", x => x.Con_Id);
                    table.ForeignKey(
                        name: "FK_ConsumedMaterials_Experiment_ExperimentExp_Id",
                        column: x => x.ExperimentExp_Id,
                        principalTable: "Experiment",
                        principalColumn: "Exp_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ConsumedMaterials_Project_Projectproj_id",
                        column: x => x.Projectproj_id,
                        principalTable: "Project",
                        principalColumn: "proj_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MachinesReservation",
                columns: table => new
                {
                    machResId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    machine_name = table.Column<string>(nullable: false),
                    date = table.Column<DateTime>(nullable: false),
                    ResOrNot = table.Column<int>(nullable: false),
                    ex_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachinesReservation", x => x.machResId);
                    table.ForeignKey(
                        name: "FK_MachinesReservation_Experiment_ex_id",
                        column: x => x.ex_id,
                        principalTable: "Experiment",
                        principalColumn: "Exp_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User_OpeningClosing",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    project_id = table.Column<int>(nullable: false),
                    openingclosing_id = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: true),
                    OpeningAndClosingoc_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_OpeningClosing", x => x.ID);
                    table.ForeignKey(
                        name: "FK_User_OpeningClosing_OpeningAndClosing_OpeningAndClosingoc_id",
                        column: x => x.OpeningAndClosingoc_id,
                        principalTable: "OpeningAndClosing",
                        principalColumn: "oc_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_OpeningClosing_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RequiredMaterial",
                columns: table => new
                {
                    reqmat_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name1 = table.Column<string>(nullable: false),
                    quantity = table.Column<int>(nullable: false),
                    ex_id = table.Column<int>(nullable: false),
                    ConsumedMaterialsCon_Id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequiredMaterial", x => x.reqmat_id);
                    table.ForeignKey(
                        name: "FK_RequiredMaterial_ConsumedMaterials_ConsumedMaterialsCon_Id",
                        column: x => x.ConsumedMaterialsCon_Id,
                        principalTable: "ConsumedMaterials",
                        principalColumn: "Con_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RequiredMaterial_Experiment_ex_id",
                        column: x => x.ex_id,
                        principalTable: "Experiment",
                        principalColumn: "Exp_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BacterialStock",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Box_Name = table.Column<string>(nullable: true),
                    Bacteria_Name = table.Column<string>(nullable: true),
                    x = table.Column<int>(nullable: false),
                    y = table.Column<int>(nullable: false),
                    Con_Id = table.Column<int>(nullable: false),
                    ConsumedMaterialsCon_Id = table.Column<int>(nullable: true),
                    Pr_Id = table.Column<int>(nullable: false),
                    IncomingProductpr_id = table.Column<int>(nullable: true),
                    Req_Id = table.Column<int>(nullable: false),
                    RequiredMaterialreqmat_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BacterialStock", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BacterialStock_ConsumedMaterials_ConsumedMaterialsCon_Id",
                        column: x => x.ConsumedMaterialsCon_Id,
                        principalTable: "ConsumedMaterials",
                        principalColumn: "Con_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BacterialStock_IncomingProduct_IncomingProductpr_id",
                        column: x => x.IncomingProductpr_id,
                        principalTable: "IncomingProduct",
                        principalColumn: "pr_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BacterialStock_RequiredMaterial_RequiredMaterialreqmat_id",
                        column: x => x.RequiredMaterialreqmat_id,
                        principalTable: "RequiredMaterial",
                        principalColumn: "reqmat_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ConsumablesInventory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fur_Name = table.Column<string>(nullable: true),
                    Quantity_micro = table.Column<int>(nullable: false),
                    Quantity_mol = table.Column<int>(nullable: false),
                    Quantity_cell = table.Column<int>(nullable: false),
                    Quantity_myco = table.Column<int>(nullable: false),
                    Quantity_storage = table.Column<int>(nullable: false),
                    Quantity_Refrig = table.Column<int>(nullable: false),
                    Quantity_meeting = table.Column<int>(nullable: false),
                    Total = table.Column<int>(nullable: false),
                    Req_Id = table.Column<int>(nullable: false),
                    RequiredMaterialreqmat_id = table.Column<int>(nullable: true),
                    Pr_Id = table.Column<int>(nullable: false),
                    IncomingProductpr_id = table.Column<int>(nullable: true),
                    User_Id = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumablesInventory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConsumablesInventory_IncomingProduct_IncomingProductpr_id",
                        column: x => x.IncomingProductpr_id,
                        principalTable: "IncomingProduct",
                        principalColumn: "pr_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ConsumablesInventory_RequiredMaterial_RequiredMaterialreqmat_id",
                        column: x => x.RequiredMaterialreqmat_id,
                        principalTable: "RequiredMaterial",
                        principalColumn: "reqmat_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ConsumablesInventory_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Freezer_20",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Con_Id = table.Column<int>(nullable: false),
                    ConsumedMaterialsCon_Id = table.Column<int>(nullable: true),
                    Req_Id = table.Column<int>(nullable: false),
                    RequiredMaterialreqmat_id = table.Column<int>(nullable: true),
                    Pr_Id = table.Column<int>(nullable: false),
                    IncomingProductpr_id = table.Column<int>(nullable: true),
                    Box_Name = table.Column<string>(nullable: true),
                    Box_Type = table.Column<string>(nullable: true),
                    Level_num = table.Column<int>(nullable: false),
                    Side = table.Column<string>(nullable: true),
                    Lev_Side = table.Column<string>(nullable: true),
                    Cons = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Freezer_20", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Freezer_20_ConsumedMaterials_ConsumedMaterialsCon_Id",
                        column: x => x.ConsumedMaterialsCon_Id,
                        principalTable: "ConsumedMaterials",
                        principalColumn: "Con_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Freezer_20_IncomingProduct_IncomingProductpr_id",
                        column: x => x.IncomingProductpr_id,
                        principalTable: "IncomingProduct",
                        principalColumn: "pr_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Freezer_20_RequiredMaterial_RequiredMaterialreqmat_id",
                        column: x => x.RequiredMaterialreqmat_id,
                        principalTable: "RequiredMaterial",
                        principalColumn: "reqmat_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Freezer_80",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Con_Id = table.Column<int>(nullable: false),
                    ConsumedMaterialsCon_Id = table.Column<int>(nullable: true),
                    Req_Id = table.Column<int>(nullable: false),
                    RequiredMaterialreqmat_id = table.Column<int>(nullable: true),
                    Pr_Id = table.Column<int>(nullable: false),
                    IncomingProductpr_id = table.Column<int>(nullable: true),
                    Box_Name = table.Column<string>(nullable: true),
                    Box_Type = table.Column<string>(nullable: true),
                    Level_num = table.Column<int>(nullable: false),
                    Side = table.Column<string>(nullable: true),
                    Lev_Side = table.Column<string>(nullable: true),
                    Col7 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Freezer_80", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Freezer_80_ConsumedMaterials_ConsumedMaterialsCon_Id",
                        column: x => x.ConsumedMaterialsCon_Id,
                        principalTable: "ConsumedMaterials",
                        principalColumn: "Con_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Freezer_80_IncomingProduct_IncomingProductpr_id",
                        column: x => x.IncomingProductpr_id,
                        principalTable: "IncomingProduct",
                        principalColumn: "pr_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Freezer_80_RequiredMaterial_RequiredMaterialreqmat_id",
                        column: x => x.RequiredMaterialreqmat_id,
                        principalTable: "RequiredMaterial",
                        principalColumn: "reqmat_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FurnituresInventory",
                columns: table => new
                {
                    fid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    furniture_name = table.Column<string>(nullable: false),
                    quantity_micro = table.Column<int>(nullable: false),
                    quantity_mol = table.Column<int>(nullable: false),
                    quantity_cell = table.Column<int>(nullable: false),
                    quantity_myco = table.Column<int>(nullable: false),
                    quantity_storage = table.Column<int>(nullable: false),
                    quantity_refrig = table.Column<int>(nullable: false),
                    quantity_meeting = table.Column<int>(nullable: false),
                    total = table.Column<int>(nullable: false),
                    id = table.Column<int>(nullable: false),
                    pr_id = table.Column<int>(nullable: false),
                    reqmat_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FurnituresInventory", x => x.fid);
                    table.ForeignKey(
                        name: "FK_FurnituresInventory_User_id",
                        column: x => x.id,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FurnituresInventory_IncomingProduct_pr_id",
                        column: x => x.pr_id,
                        principalTable: "IncomingProduct",
                        principalColumn: "pr_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FurnituresInventory_RequiredMaterial_reqmat_id",
                        column: x => x.reqmat_id,
                        principalTable: "RequiredMaterial",
                        principalColumn: "reqmat_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemsInventory",
                columns: table => new
                {
                    iid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    item_name = table.Column<string>(nullable: false),
                    quantity_micro = table.Column<int>(nullable: false),
                    quantity_mol = table.Column<int>(nullable: false),
                    quantity_cell = table.Column<int>(nullable: false),
                    quantity_myco = table.Column<int>(nullable: false),
                    quantity_storage = table.Column<int>(nullable: false),
                    quantity_refrig = table.Column<int>(nullable: false),
                    quantity_meeting = table.Column<int>(nullable: false),
                    total = table.Column<int>(nullable: false),
                    id = table.Column<int>(nullable: false),
                    pr_id = table.Column<int>(nullable: false),
                    reqmat_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemsInventory", x => x.iid);
                    table.ForeignKey(
                        name: "FK_ItemsInventory_User_id",
                        column: x => x.id,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemsInventory_IncomingProduct_pr_id",
                        column: x => x.pr_id,
                        principalTable: "IncomingProduct",
                        principalColumn: "pr_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemsInventory_RequiredMaterial_reqmat_id",
                        column: x => x.reqmat_id,
                        principalTable: "RequiredMaterial",
                        principalColumn: "reqmat_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MachinesTC",
                columns: table => new
                {
                    mtcId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: false),
                    ConsumablesInventoryId = table.Column<int>(nullable: true),
                    ItemsInventoryiid = table.Column<int>(nullable: true),
                    MachinesInventorymid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachinesTC", x => x.mtcId);
                    table.ForeignKey(
                        name: "FK_MachinesTC_ConsumablesInventory_ConsumablesInventoryId",
                        column: x => x.ConsumablesInventoryId,
                        principalTable: "ConsumablesInventory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MachinesTC_ItemsInventory_ItemsInventoryiid",
                        column: x => x.ItemsInventoryiid,
                        principalTable: "ItemsInventory",
                        principalColumn: "iid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MachinesTC_MachinesInventory_MachinesInventorymid",
                        column: x => x.MachinesInventorymid,
                        principalTable: "MachinesInventory",
                        principalColumn: "mid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TestingAndCalibration",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    mtc_id = table.Column<int>(nullable: false),
                    user_id = table.Column<int>(nullable: false),
                    student_name = table.Column<string>(nullable: true),
                    date = table.Column<DateTime>(nullable: false),
                    next_check = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestingAndCalibration", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TestingAndCalibration_MachinesTC_mtc_id",
                        column: x => x.mtc_id,
                        principalTable: "MachinesTC",
                        principalColumn: "mtcId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TestingAndCalibration_User_user_id",
                        column: x => x.user_id,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accident_UserId",
                table: "Accident",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Assesment_UserId",
                table: "Assesment",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceAssistant_UserId",
                table: "AttendanceAssistant",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceHK_UserId",
                table: "AttendanceHK",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceM2_UserId",
                table: "AttendanceM2",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AttendancePHD_UserId",
                table: "AttendancePHD",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AttendancePHDSt_UserId",
                table: "AttendancePHDSt",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceTrainee_UserId",
                table: "AttendanceTrainee",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BacterialStock_ConsumedMaterialsCon_Id",
                table: "BacterialStock",
                column: "ConsumedMaterialsCon_Id");

            migrationBuilder.CreateIndex(
                name: "IX_BacterialStock_IncomingProductpr_id",
                table: "BacterialStock",
                column: "IncomingProductpr_id");

            migrationBuilder.CreateIndex(
                name: "IX_BacterialStock_RequiredMaterialreqmat_id",
                table: "BacterialStock",
                column: "RequiredMaterialreqmat_id");

            migrationBuilder.CreateIndex(
                name: "IX_Biowaste_CompanyComp_Id",
                table: "Biowaste",
                column: "CompanyComp_Id");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowPermission_UserId",
                table: "BorrowPermission",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Collaboration_UserId",
                table: "Collaboration",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Company_UserId",
                table: "Company",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsumablesInventory_IncomingProductpr_id",
                table: "ConsumablesInventory",
                column: "IncomingProductpr_id");

            migrationBuilder.CreateIndex(
                name: "IX_ConsumablesInventory_RequiredMaterialreqmat_id",
                table: "ConsumablesInventory",
                column: "RequiredMaterialreqmat_id");

            migrationBuilder.CreateIndex(
                name: "IX_ConsumablesInventory_UserId",
                table: "ConsumablesInventory",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsumedMaterials_ExperimentExp_Id",
                table: "ConsumedMaterials",
                column: "ExperimentExp_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ConsumedMaterials_Projectproj_id",
                table: "ConsumedMaterials",
                column: "Projectproj_id");

            migrationBuilder.CreateIndex(
                name: "IX_Experiment_biowasteId",
                table: "Experiment",
                column: "biowasteId");

            migrationBuilder.CreateIndex(
                name: "IX_FreeForm_UserId",
                table: "FreeForm",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Freezer_20_ConsumedMaterialsCon_Id",
                table: "Freezer_20",
                column: "ConsumedMaterialsCon_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Freezer_20_IncomingProductpr_id",
                table: "Freezer_20",
                column: "IncomingProductpr_id");

            migrationBuilder.CreateIndex(
                name: "IX_Freezer_20_RequiredMaterialreqmat_id",
                table: "Freezer_20",
                column: "RequiredMaterialreqmat_id");

            migrationBuilder.CreateIndex(
                name: "IX_Freezer_80_ConsumedMaterialsCon_Id",
                table: "Freezer_80",
                column: "ConsumedMaterialsCon_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Freezer_80_IncomingProductpr_id",
                table: "Freezer_80",
                column: "IncomingProductpr_id");

            migrationBuilder.CreateIndex(
                name: "IX_Freezer_80_RequiredMaterialreqmat_id",
                table: "Freezer_80",
                column: "RequiredMaterialreqmat_id");

            migrationBuilder.CreateIndex(
                name: "IX_FurnituresInventory_id",
                table: "FurnituresInventory",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_FurnituresInventory_pr_id",
                table: "FurnituresInventory",
                column: "pr_id");

            migrationBuilder.CreateIndex(
                name: "IX_FurnituresInventory_reqmat_id",
                table: "FurnituresInventory",
                column: "reqmat_id");

            migrationBuilder.CreateIndex(
                name: "IX_IncomingProduct_comp_id",
                table: "IncomingProduct",
                column: "comp_id");

            migrationBuilder.CreateIndex(
                name: "IX_IncomingProduct_id",
                table: "IncomingProduct",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_InternshipRequest_id",
                table: "InternshipRequest",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_ItemsInventory_id",
                table: "ItemsInventory",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_ItemsInventory_pr_id",
                table: "ItemsInventory",
                column: "pr_id");

            migrationBuilder.CreateIndex(
                name: "IX_ItemsInventory_reqmat_id",
                table: "ItemsInventory",
                column: "reqmat_id");

            migrationBuilder.CreateIndex(
                name: "IX_MachinesInventory_UserId",
                table: "MachinesInventory",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MachinesInventory_incomingProductpr_id",
                table: "MachinesInventory",
                column: "incomingProductpr_id");

            migrationBuilder.CreateIndex(
                name: "IX_MachinesReservation_ex_id",
                table: "MachinesReservation",
                column: "ex_id");

            migrationBuilder.CreateIndex(
                name: "IX_MachinesTC_ConsumablesInventoryId",
                table: "MachinesTC",
                column: "ConsumablesInventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MachinesTC_ItemsInventoryiid",
                table: "MachinesTC",
                column: "ItemsInventoryiid");

            migrationBuilder.CreateIndex(
                name: "IX_MachinesTC_MachinesInventorymid",
                table: "MachinesTC",
                column: "MachinesInventorymid");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingPresence_mrrId",
                table: "MeetingPresence",
                column: "mrrId");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingRR_MeetingRRmrrId",
                table: "MeetingRR",
                column: "MeetingRRmrrId");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingRR_id",
                table: "MeetingRR",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_MembershipRequest_id",
                table: "MembershipRequest",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_OpeningAndClosing_IncomingProductpr_id",
                table: "OpeningAndClosing",
                column: "IncomingProductpr_id");

            migrationBuilder.CreateIndex(
                name: "IX_Order_comp_id",
                table: "Order",
                column: "comp_id");

            migrationBuilder.CreateIndex(
                name: "IX_Order_id",
                table: "Order",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_PrintingPermission_id",
                table: "PrintingPermission",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_Project_id",
                table: "Project",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_Project_Collaboration_CollaborationId",
                table: "Project_Collaboration",
                column: "CollaborationId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_Collaboration_Projectproj_id",
                table: "Project_Collaboration",
                column: "Projectproj_id");

            migrationBuilder.CreateIndex(
                name: "IX_Project_Researcher_Projectproj_id",
                table: "Project_Researcher",
                column: "Projectproj_id");

            migrationBuilder.CreateIndex(
                name: "IX_Project_Researcher_Researcherrid",
                table: "Project_Researcher",
                column: "Researcherrid");

            migrationBuilder.CreateIndex(
                name: "IX_RequiredMaterial_ConsumedMaterialsCon_Id",
                table: "RequiredMaterial",
                column: "ConsumedMaterialsCon_Id");

            migrationBuilder.CreateIndex(
                name: "IX_RequiredMaterial_ex_id",
                table: "RequiredMaterial",
                column: "ex_id");

            migrationBuilder.CreateIndex(
                name: "IX_Rotation_id",
                table: "Rotation",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_TestingAndCalibration_mtc_id",
                table: "TestingAndCalibration",
                column: "mtc_id");

            migrationBuilder.CreateIndex(
                name: "IX_TestingAndCalibration_user_id",
                table: "TestingAndCalibration",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingPreRegistration_user_id",
                table: "TrainingPreRegistration",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_User_OpeningClosing_OpeningAndClosingoc_id",
                table: "User_OpeningClosing",
                column: "OpeningAndClosingoc_id");

            migrationBuilder.CreateIndex(
                name: "IX_User_OpeningClosing_UserId",
                table: "User_OpeningClosing",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkPermission_user_id",
                table: "WorkPermission",
                column: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accident");

            migrationBuilder.DropTable(
                name: "Assesment");

            migrationBuilder.DropTable(
                name: "AttendanceAssistant");

            migrationBuilder.DropTable(
                name: "AttendanceHK");

            migrationBuilder.DropTable(
                name: "AttendanceM2");

            migrationBuilder.DropTable(
                name: "AttendancePHD");

            migrationBuilder.DropTable(
                name: "AttendancePHDSt");

            migrationBuilder.DropTable(
                name: "AttendanceTrainee");

            migrationBuilder.DropTable(
                name: "BacterialStock");

            migrationBuilder.DropTable(
                name: "BorrowPermission");

            migrationBuilder.DropTable(
                name: "FreeForm");

            migrationBuilder.DropTable(
                name: "Freezer_20");

            migrationBuilder.DropTable(
                name: "Freezer_80");

            migrationBuilder.DropTable(
                name: "FurnituresInventory");

            migrationBuilder.DropTable(
                name: "InternshipRequest");

            migrationBuilder.DropTable(
                name: "MachinesReservation");

            migrationBuilder.DropTable(
                name: "MeetingPresence");

            migrationBuilder.DropTable(
                name: "MembershipRequest");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "PrintingPermission");

            migrationBuilder.DropTable(
                name: "Project_Collaboration");

            migrationBuilder.DropTable(
                name: "Project_Researcher");

            migrationBuilder.DropTable(
                name: "Rotation");

            migrationBuilder.DropTable(
                name: "TestingAndCalibration");

            migrationBuilder.DropTable(
                name: "TrainingPreRegistration");

            migrationBuilder.DropTable(
                name: "User_OpeningClosing");

            migrationBuilder.DropTable(
                name: "WorkPermission");

            migrationBuilder.DropTable(
                name: "MeetingRR");

            migrationBuilder.DropTable(
                name: "Collaboration");

            migrationBuilder.DropTable(
                name: "Researcher");

            migrationBuilder.DropTable(
                name: "MachinesTC");

            migrationBuilder.DropTable(
                name: "OpeningAndClosing");

            migrationBuilder.DropTable(
                name: "ConsumablesInventory");

            migrationBuilder.DropTable(
                name: "ItemsInventory");

            migrationBuilder.DropTable(
                name: "MachinesInventory");

            migrationBuilder.DropTable(
                name: "RequiredMaterial");

            migrationBuilder.DropTable(
                name: "IncomingProduct");

            migrationBuilder.DropTable(
                name: "ConsumedMaterials");

            migrationBuilder.DropTable(
                name: "Experiment");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "Biowaste");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
