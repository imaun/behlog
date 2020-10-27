using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Behlog.Storage.SqlServer.Migrations
{
    public partial class InitDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Security.Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Security.Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Security.Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(maxLength: 1000, nullable: false),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(maxLength: 100, nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 1000, nullable: false),
                    Status = table.Column<int>(nullable: false, defaultValue: 1),
                    WebUrl = table.Column<string>(maxLength: 2000, nullable: true),
                    Phone = table.Column<string>(maxLength: 100, nullable: true),
                    RegisterDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Security.Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "System.Languages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 1000, nullable: false),
                    LangKey = table.Column<string>(maxLength: 20, nullable: false),
                    Status = table.Column<int>(nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_System.Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "System.Layouts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 1000, nullable: false),
                    Name = table.Column<string>(maxLength: 1000, nullable: false),
                    Description = table.Column<string>(maxLength: 4000, nullable: true),
                    Author = table.Column<string>(maxLength: 1000, nullable: true),
                    AuthorEmail = table.Column<string>(maxLength: 2000, nullable: false),
                    AuthorWebUrl = table.Column<string>(maxLength: 2000, nullable: true),
                    Path = table.Column<string>(maxLength: 2000, nullable: false),
                    OrderNumber = table.Column<int>(nullable: false, defaultValue: 1),
                    Status = table.Column<int>(nullable: false, defaultValue: 1),
                    IsRtl = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_System.Layouts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "System.PostTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 500, nullable: false),
                    Description = table.Column<string>(maxLength: 2000, nullable: true),
                    Slug = table.Column<string>(maxLength: 1000, nullable: false),
                    Status = table.Column<int>(nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_System.PostTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "System.Tags",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 1000, nullable: false),
                    Slug = table.Column<string>(maxLength: 2000, nullable: false),
                    Description = table.Column<string>(maxLength: 4000, nullable: true),
                    Status = table.Column<int>(nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_System.Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Security.Role_Claims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Security.Role_Claims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Security.Role_Claims_Security.Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Security.Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Security.User_Claims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Security.User_Claims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Security.User_Claims_Security.Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Security.Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Security.User_Roles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Security.User_Roles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_Security.User_Roles_Security.Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Security.Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Security.User_Roles_Security.Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Security.Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Security.User_Tokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Security.User_Tokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_Security.User_Tokens_Security.Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Security.Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "System.UserMeta",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<Guid>(nullable: false),
                    ModifierUserId = table.Column<Guid>(nullable: true),
                    Title = table.Column<string>(maxLength: 1000, nullable: true),
                    MetaKey = table.Column<string>(maxLength: 255, nullable: false),
                    MetaValue = table.Column<string>(maxLength: 4000, nullable: true),
                    Category = table.Column<string>(maxLength: 255, nullable: true),
                    LangId = table.Column<int>(nullable: true),
                    Status = table.Column<int>(nullable: false, defaultValue: 1),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_System.UserMeta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_System.UserMeta_System.Languages_LangId",
                        column: x => x.LangId,
                        principalTable: "System.Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_System.UserMeta_Security.Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Security.Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "System.Websites",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Title = table.Column<string>(maxLength: 1000, nullable: false),
                    Description = table.Column<string>(maxLength: 4000, nullable: true),
                    Keywords = table.Column<string>(maxLength: 2000, nullable: true),
                    Url = table.Column<string>(maxLength: 2000, nullable: true),
                    Status = table.Column<int>(nullable: false, defaultValue: 1),
                    OwnerId = table.Column<Guid>(nullable: false),
                    DefaultLangId = table.Column<int>(nullable: false),
                    LayoutId = table.Column<int>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_System.Websites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_System.Websites_System.Languages_DefaultLangId",
                        column: x => x.DefaultLangId,
                        principalTable: "System.Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_System.Websites_System.Layouts_LayoutId",
                        column: x => x.LayoutId,
                        principalTable: "System.Layouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_System.Websites_Security.Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Security.Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Content.Files",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<Guid>(nullable: false),
                    ModifierUserId = table.Column<Guid>(nullable: true),
                    Title = table.Column<string>(maxLength: 2000, nullable: true),
                    FilePath = table.Column<string>(maxLength: 4000, nullable: true),
                    FileType = table.Column<int>(nullable: false),
                    Extension = table.Column<string>(maxLength: 20, nullable: true),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    Url = table.Column<string>(maxLength: 4000, nullable: true),
                    Status = table.Column<int>(nullable: false),
                    WebsiteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Content.Files", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Content.Files_System.Websites_WebsiteId",
                        column: x => x.WebsiteId,
                        principalTable: "System.Websites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Feature.Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SiteId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 1000, nullable: true),
                    Email = table.Column<string>(maxLength: 2000, nullable: false),
                    Phone = table.Column<string>(maxLength: 100, nullable: true),
                    Message = table.Column<string>(maxLength: 4000, nullable: true),
                    Ip = table.Column<string>(maxLength: 100, nullable: false),
                    UserAgent = table.Column<string>(maxLength: 100, nullable: true),
                    SentDate = table.Column<DateTime>(nullable: false),
                    WebsiteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feature.Contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Feature.Contacts_System.Websites_WebsiteId",
                        column: x => x.WebsiteId,
                        principalTable: "System.Websites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Feature.Forms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<Guid>(nullable: false),
                    ModifierUserId = table.Column<Guid>(nullable: true),
                    Title = table.Column<string>(maxLength: 1000, nullable: false),
                    Name = table.Column<string>(maxLength: 1000, nullable: false),
                    WebsiteId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feature.Forms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Feature.Forms_System.Websites_WebsiteId",
                        column: x => x.WebsiteId,
                        principalTable: "System.Websites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Feature.Website_Visits",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SessionId = table.Column<string>(maxLength: 1000, nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    AbseloutUrl = table.Column<string>(maxLength: 4000, nullable: true),
                    UrlReferrer = table.Column<string>(maxLength: 4000, nullable: true),
                    UserId = table.Column<int>(nullable: true),
                    IP = table.Column<string>(maxLength: 100, nullable: true),
                    UserAgent = table.Column<string>(maxLength: 100, nullable: true),
                    OsPlatform = table.Column<string>(maxLength: 100, nullable: true),
                    Country = table.Column<string>(maxLength: 100, nullable: true),
                    City = table.Column<string>(maxLength: 100, nullable: true),
                    Region = table.Column<string>(maxLength: 100, nullable: true),
                    Description = table.Column<string>(maxLength: 2000, nullable: true),
                    WebsiteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feature.Website_Visits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Feature.Website_Visits_System.Websites_WebsiteId",
                        column: x => x.WebsiteId,
                        principalTable: "System.Websites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Security.User_Logins",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoginProvider = table.Column<string>(nullable: true),
                    ProviderKey = table.Column<string>(nullable: true),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    UserAgent = table.Column<string>(maxLength: 255, nullable: true),
                    IP = table.Column<string>(maxLength: 100, nullable: true),
                    ReferUrl = table.Column<string>(maxLength: 4000, nullable: true),
                    LoginTime = table.Column<DateTime>(nullable: false),
                    WebsiteId = table.Column<int>(nullable: false),
                    ExtraInfo = table.Column<string>(maxLength: 4000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Security.User_Logins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Security.User_Logins_Security.Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Security.Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Security.User_Logins_System.Websites_WebsiteId",
                        column: x => x.WebsiteId,
                        principalTable: "System.Websites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "System.Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 1000, nullable: false),
                    Description = table.Column<string>(maxLength: 2000, nullable: true),
                    Slug = table.Column<string>(maxLength: 2000, nullable: false),
                    PostTypeId = table.Column<int>(nullable: false),
                    ParentId = table.Column<int>(nullable: true),
                    LangId = table.Column<int>(nullable: false),
                    TreePath = table.Column<string>(maxLength: 4000, nullable: true),
                    WebsiteId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_System.Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_System.Categories_System.Languages_LangId",
                        column: x => x.LangId,
                        principalTable: "System.Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_System.Categories_System.PostTypes_PostTypeId",
                        column: x => x.PostTypeId,
                        principalTable: "System.PostTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_System.Categories_System.Websites_WebsiteId",
                        column: x => x.WebsiteId,
                        principalTable: "System.Websites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "System.Menu_Items",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 2000, nullable: false),
                    Description = table.Column<string>(maxLength: 4000, nullable: true),
                    Url = table.Column<string>(maxLength: 4000, nullable: true),
                    ParentId = table.Column<int>(nullable: true),
                    Action = table.Column<string>(maxLength: 1000, nullable: true),
                    Controller = table.Column<string>(maxLength: 1000, nullable: true),
                    Parameters = table.Column<string>(maxLength: 2000, nullable: true),
                    Status = table.Column<int>(nullable: false, defaultValue: 1),
                    WebsiteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_System.Menu_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_System.Menu_Items_System.Websites_WebsiteId",
                        column: x => x.WebsiteId,
                        principalTable: "System.Websites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "System.Website_Options",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WebsiteId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 1000, nullable: false),
                    Option_Key = table.Column<string>(maxLength: 255, nullable: false),
                    Option_Value = table.Column<string>(maxLength: 4000, nullable: true),
                    Category = table.Column<string>(maxLength: 255, nullable: true),
                    OrderNum = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false, defaultValue: 1),
                    Description = table.Column<string>(maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_System.Website_Options", x => x.Id);
                    table.ForeignKey(
                        name: "FK_System.Website_Options_System.Websites_WebsiteId",
                        column: x => x.WebsiteId,
                        principalTable: "System.Websites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Feature.Form_Fields",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<Guid>(nullable: false),
                    ModifierUserId = table.Column<Guid>(nullable: true),
                    Title = table.Column<string>(maxLength: 1000, nullable: true),
                    Name = table.Column<string>(maxLength: 1000, nullable: false),
                    FormId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 2000, nullable: true),
                    FieldType = table.Column<int>(nullable: false),
                    Required = table.Column<bool>(nullable: false),
                    OrderNum = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feature.Form_Fields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Feature.Form_Fields_Feature.Forms_FormId",
                        column: x => x.FormId,
                        principalTable: "Feature.Forms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Content.Links",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<Guid>(nullable: false),
                    ModifierUserId = table.Column<Guid>(nullable: true),
                    Title = table.Column<string>(maxLength: 1000, nullable: false),
                    Url = table.Column<string>(maxLength: 4000, nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    Target = table.Column<string>(maxLength: 100, nullable: true),
                    Description = table.Column<string>(maxLength: 2000, nullable: true),
                    Status = table.Column<int>(nullable: false),
                    WebsiteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Content.Links", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Content.Links_System.Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "System.Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Content.Links_System.Websites_WebsiteId",
                        column: x => x.WebsiteId,
                        principalTable: "System.Websites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Content.Posts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<Guid>(nullable: false),
                    ModifierUserId = table.Column<Guid>(nullable: true),
                    Title = table.Column<string>(maxLength: 2000, nullable: false),
                    Slug = table.Column<string>(maxLength: 2000, nullable: true),
                    Body = table.Column<string>(type: "nTEXT", nullable: true),
                    Summary = table.Column<string>(maxLength: 2000, nullable: true),
                    PublishDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    Commenting = table.Column<bool>(nullable: false),
                    PostTypeId = table.Column<int>(nullable: false),
                    Password = table.Column<string>(maxLength: 100, nullable: true),
                    LangId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    CoverPhoto = table.Column<string>(maxLength: 2000, nullable: true),
                    ParentId = table.Column<int>(nullable: true),
                    CategoryPath = table.Column<string>(maxLength: 4000, nullable: true),
                    AltTitle = table.Column<string>(maxLength: 2000, nullable: true),
                    LayoutId = table.Column<int>(nullable: true),
                    OrderNumber = table.Column<int>(nullable: false),
                    WebsiteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Content.Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Content.Posts_System.Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "System.Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Content.Posts_Security.Users_CreatorUserId",
                        column: x => x.CreatorUserId,
                        principalTable: "Security.Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Content.Posts_System.Languages_LangId",
                        column: x => x.LangId,
                        principalTable: "System.Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Content.Posts_System.Layouts_LayoutId",
                        column: x => x.LayoutId,
                        principalTable: "System.Layouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Content.Posts_Security.Users_ModifierUserId",
                        column: x => x.ModifierUserId,
                        principalTable: "Security.Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Content.Posts_System.PostTypes_PostTypeId",
                        column: x => x.PostTypeId,
                        principalTable: "System.PostTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Content.Posts_System.Websites_WebsiteId",
                        column: x => x.WebsiteId,
                        principalTable: "System.Websites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Feature.Form_Field_Items",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<Guid>(nullable: false),
                    ModifierUserId = table.Column<Guid>(nullable: true),
                    FormFieldId = table.Column<long>(nullable: false),
                    Title = table.Column<string>(maxLength: 1000, nullable: false),
                    Value = table.Column<string>(maxLength: 1000, nullable: true),
                    Index = table.Column<int>(nullable: false),
                    OrderNum = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feature.Form_Field_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Feature.Form_Field_Items_Feature.Form_Fields_FormFieldId",
                        column: x => x.FormFieldId,
                        principalTable: "Feature.Form_Fields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Content.Comments",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 1000, nullable: false),
                    PostId = table.Column<int>(nullable: false),
                    Email = table.Column<string>(maxLength: 2000, nullable: true),
                    WebUrl = table.Column<string>(maxLength: 2000, nullable: true),
                    Body = table.Column<string>(maxLength: 4000, nullable: false),
                    IP = table.Column<string>(maxLength: 100, nullable: true),
                    UserAgent = table.Column<string>(maxLength: 200, nullable: true),
                    SessionId = table.Column<string>(maxLength: 2000, nullable: false),
                    Status = table.Column<int>(nullable: false),
                    ParentId = table.Column<long>(nullable: true),
                    UserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Content.Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Content.Comments_Content.Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Content.Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Content.Comments_Security.Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Security.Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Content.Post_Files",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<Guid>(nullable: false),
                    ModifierUserId = table.Column<Guid>(nullable: true),
                    PostId = table.Column<int>(nullable: false),
                    FileId = table.Column<long>(nullable: false),
                    OrderNum = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Content.Post_Files", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Content.Post_Files_Content.Files_FileId",
                        column: x => x.FileId,
                        principalTable: "Content.Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Content.Post_Files_Content.Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Content.Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Content.Post_Likes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostId = table.Column<int>(nullable: false),
                    SessionId = table.Column<string>(maxLength: 2000, nullable: false),
                    UserId = table.Column<Guid>(nullable: true),
                    IP = table.Column<string>(maxLength: 100, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Content.Post_Likes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Content.Post_Likes_Content.Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Content.Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Content.Post_Likes_Security.Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Security.Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Content.Post_Meta",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<Guid>(nullable: false),
                    ModifierUserId = table.Column<Guid>(nullable: true),
                    Title = table.Column<string>(maxLength: 1000, nullable: true),
                    MetaKey = table.Column<string>(maxLength: 1000, nullable: false),
                    MetaValue = table.Column<string>(maxLength: 4000, nullable: true),
                    Category = table.Column<string>(maxLength: 1000, nullable: true),
                    LangId = table.Column<int>(nullable: true),
                    PostId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Content.Post_Meta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Content.Post_Meta_System.Languages_LangId",
                        column: x => x.LangId,
                        principalTable: "System.Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Content.Post_Meta_Content.Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Content.Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Content.Post_Tags",
                columns: table => new
                {
                    PostId = table.Column<int>(nullable: false),
                    TagId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Content.Post_Tags", x => new { x.PostId, x.TagId });
                    table.ForeignKey(
                        name: "FK_Content.Post_Tags_Content.Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Content.Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Content.Post_Tags_System.Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "System.Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Feature.Post_Visits",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SessionId = table.Column<string>(maxLength: 1000, nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    AbseloutUrl = table.Column<string>(maxLength: 4000, nullable: true),
                    UrlReferrer = table.Column<string>(maxLength: 4000, nullable: true),
                    UserId = table.Column<int>(nullable: true),
                    IP = table.Column<string>(maxLength: 100, nullable: true),
                    UserAgent = table.Column<string>(maxLength: 100, nullable: true),
                    OsPlatform = table.Column<string>(maxLength: 100, nullable: true),
                    Country = table.Column<string>(maxLength: 100, nullable: true),
                    City = table.Column<string>(maxLength: 100, nullable: true),
                    Region = table.Column<string>(maxLength: 100, nullable: true),
                    Description = table.Column<string>(maxLength: 2000, nullable: true),
                    PostId = table.Column<int>(nullable: false),
                    PostTitle = table.Column<string>(maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feature.Post_Visits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Feature.Post_Visits_Content.Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Content.Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Feature.Form_Field_Values",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FormFieldId = table.Column<long>(nullable: false),
                    TextValue = table.Column<string>(maxLength: 4000, nullable: true),
                    IntValue = table.Column<int>(nullable: true),
                    DecValue = table.Column<decimal>(nullable: true),
                    DateValue = table.Column<DateTime>(nullable: true),
                    FileValue = table.Column<byte[]>(nullable: true),
                    FormFieldItemId = table.Column<long>(nullable: true),
                    SelectedValueIndex = table.Column<int>(nullable: true),
                    SelectedValue = table.Column<string>(maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feature.Form_Field_Values", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Feature.Form_Field_Values_Feature.Form_Fields_FormFieldId",
                        column: x => x.FormFieldId,
                        principalTable: "Feature.Form_Fields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Feature.Form_Field_Values_Feature.Form_Field_Items_FormFieldItemId",
                        column: x => x.FormFieldItemId,
                        principalTable: "Feature.Form_Field_Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Content.Comments_PostId",
                table: "Content.Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Content.Comments_UserId",
                table: "Content.Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Content.Files_WebsiteId",
                table: "Content.Files",
                column: "WebsiteId");

            migrationBuilder.CreateIndex(
                name: "IX_Content.Links_CategoryId",
                table: "Content.Links",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Content.Links_WebsiteId",
                table: "Content.Links",
                column: "WebsiteId");

            migrationBuilder.CreateIndex(
                name: "IX_Content.Post_Files_FileId",
                table: "Content.Post_Files",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_Content.Post_Files_PostId",
                table: "Content.Post_Files",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Content.Post_Likes_PostId",
                table: "Content.Post_Likes",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Content.Post_Likes_UserId",
                table: "Content.Post_Likes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Content.Post_Meta_LangId",
                table: "Content.Post_Meta",
                column: "LangId");

            migrationBuilder.CreateIndex(
                name: "IX_Content.Post_Meta_PostId",
                table: "Content.Post_Meta",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Content.Post_Tags_TagId",
                table: "Content.Post_Tags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Content.Posts_CategoryId",
                table: "Content.Posts",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Content.Posts_CreatorUserId",
                table: "Content.Posts",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Content.Posts_LangId",
                table: "Content.Posts",
                column: "LangId");

            migrationBuilder.CreateIndex(
                name: "IX_Content.Posts_LayoutId",
                table: "Content.Posts",
                column: "LayoutId");

            migrationBuilder.CreateIndex(
                name: "IX_Content.Posts_ModifierUserId",
                table: "Content.Posts",
                column: "ModifierUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Content.Posts_PostTypeId",
                table: "Content.Posts",
                column: "PostTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Content.Posts_WebsiteId",
                table: "Content.Posts",
                column: "WebsiteId");

            migrationBuilder.CreateIndex(
                name: "IX_Feature.Contacts_WebsiteId",
                table: "Feature.Contacts",
                column: "WebsiteId");

            migrationBuilder.CreateIndex(
                name: "IX_Feature.Form_Field_Items_FormFieldId",
                table: "Feature.Form_Field_Items",
                column: "FormFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_Feature.Form_Field_Values_FormFieldId",
                table: "Feature.Form_Field_Values",
                column: "FormFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_Feature.Form_Field_Values_FormFieldItemId",
                table: "Feature.Form_Field_Values",
                column: "FormFieldItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Feature.Form_Fields_FormId",
                table: "Feature.Form_Fields",
                column: "FormId");

            migrationBuilder.CreateIndex(
                name: "IX_Feature.Forms_WebsiteId",
                table: "Feature.Forms",
                column: "WebsiteId");

            migrationBuilder.CreateIndex(
                name: "IX_Feature.Post_Visits_PostId",
                table: "Feature.Post_Visits",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Feature.Website_Visits_WebsiteId",
                table: "Feature.Website_Visits",
                column: "WebsiteId");

            migrationBuilder.CreateIndex(
                name: "IX_Security.Role_Claims_RoleId",
                table: "Security.Role_Claims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Security.Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Security.User_Claims_UserId",
                table: "Security.User_Claims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Security.User_Logins_UserId",
                table: "Security.User_Logins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Security.User_Logins_WebsiteId",
                table: "Security.User_Logins",
                column: "WebsiteId");

            migrationBuilder.CreateIndex(
                name: "IX_Security.User_Roles_RoleId",
                table: "Security.User_Roles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Security.Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Security.Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_System.Categories_LangId",
                table: "System.Categories",
                column: "LangId");

            migrationBuilder.CreateIndex(
                name: "IX_System.Categories_PostTypeId",
                table: "System.Categories",
                column: "PostTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_System.Categories_WebsiteId",
                table: "System.Categories",
                column: "WebsiteId");

            migrationBuilder.CreateIndex(
                name: "IX_System.Menu_Items_WebsiteId",
                table: "System.Menu_Items",
                column: "WebsiteId");

            migrationBuilder.CreateIndex(
                name: "IX_System.UserMeta_LangId",
                table: "System.UserMeta",
                column: "LangId");

            migrationBuilder.CreateIndex(
                name: "IX_System.UserMeta_UserId",
                table: "System.UserMeta",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_System.Website_Options_WebsiteId",
                table: "System.Website_Options",
                column: "WebsiteId");

            migrationBuilder.CreateIndex(
                name: "IX_System.Websites_DefaultLangId",
                table: "System.Websites",
                column: "DefaultLangId");

            migrationBuilder.CreateIndex(
                name: "IX_System.Websites_LayoutId",
                table: "System.Websites",
                column: "LayoutId");

            migrationBuilder.CreateIndex(
                name: "IX_System.Websites_OwnerId",
                table: "System.Websites",
                column: "OwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Content.Comments");

            migrationBuilder.DropTable(
                name: "Content.Links");

            migrationBuilder.DropTable(
                name: "Content.Post_Files");

            migrationBuilder.DropTable(
                name: "Content.Post_Likes");

            migrationBuilder.DropTable(
                name: "Content.Post_Meta");

            migrationBuilder.DropTable(
                name: "Content.Post_Tags");

            migrationBuilder.DropTable(
                name: "Feature.Contacts");

            migrationBuilder.DropTable(
                name: "Feature.Form_Field_Values");

            migrationBuilder.DropTable(
                name: "Feature.Post_Visits");

            migrationBuilder.DropTable(
                name: "Feature.Website_Visits");

            migrationBuilder.DropTable(
                name: "Security.Role_Claims");

            migrationBuilder.DropTable(
                name: "Security.User_Claims");

            migrationBuilder.DropTable(
                name: "Security.User_Logins");

            migrationBuilder.DropTable(
                name: "Security.User_Roles");

            migrationBuilder.DropTable(
                name: "Security.User_Tokens");

            migrationBuilder.DropTable(
                name: "System.Menu_Items");

            migrationBuilder.DropTable(
                name: "System.UserMeta");

            migrationBuilder.DropTable(
                name: "System.Website_Options");

            migrationBuilder.DropTable(
                name: "Content.Files");

            migrationBuilder.DropTable(
                name: "System.Tags");

            migrationBuilder.DropTable(
                name: "Feature.Form_Field_Items");

            migrationBuilder.DropTable(
                name: "Content.Posts");

            migrationBuilder.DropTable(
                name: "Security.Roles");

            migrationBuilder.DropTable(
                name: "Feature.Form_Fields");

            migrationBuilder.DropTable(
                name: "System.Categories");

            migrationBuilder.DropTable(
                name: "Feature.Forms");

            migrationBuilder.DropTable(
                name: "System.PostTypes");

            migrationBuilder.DropTable(
                name: "System.Websites");

            migrationBuilder.DropTable(
                name: "System.Languages");

            migrationBuilder.DropTable(
                name: "System.Layouts");

            migrationBuilder.DropTable(
                name: "Security.Users");
        }
    }
}
