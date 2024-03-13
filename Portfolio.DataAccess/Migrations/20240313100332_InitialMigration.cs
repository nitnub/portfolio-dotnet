using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Portfolio.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Biographies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageAltText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageFooter = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Biographies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GuestActions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuestActions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Logos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HTML = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageAltText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GitUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Port = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    DemoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectLogos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    LogoId = table.Column<int>(type: "int", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectLogos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectLogos_Logos_LogoId",
                        column: x => x.LogoId,
                        principalTable: "Logos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectLogos_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Videos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToolTip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Videos_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Biographies",
                columns: new[] { "Id", "Image", "ImageAltText", "ImageFooter", "Text" },
                values: new object[] { 1, "joshua_tree-header.jpg", "nick at joshua tree national park", "Hiking at&nbsp;\r\n                        <a class=\"link\" href=\"https://www.nps.gov/jotr/index.htm\"\r\n                           onclick=\"Navigate('https://www.nps.gov/jotr/index.htm')\">\r\n                            Joshua Tree National Park\r\n                        </a>", "<h1 id=\"bio-header\" class=\"intro-header\">\r\n                            Hello!\r\n                        </h1>\r\n                        <p>\r\n                            Welcome to my portfolio page. My name is Nick and I am a\r\n                            customer-focused developer with 12 years of implementation, regulatory\r\n                            compliance, and product management experience in the healthcare\r\n                            informatics space. In 2022, after many years of working closely with\r\n                            engineering teams developing and enhancing Electronic Health Record\r\n                            systems at GE, AZZLY, and most recently athenahealth, I decided to\r\n                            finally start on my journey to full-time software development. A\r\n                            little more about me:\r\n                        </p>\r\n                        <ul>\r\n                            <li>Collaborative problem solver.</li>\r\n                            <li>\r\n                                Interested in developing end-to-end solutions that create real\r\n                                customer value.\r\n                            </li>\r\n                            <li>\r\n                                Over a decade of experience in the healthcare informatics space and\r\n                                excited to take these \"lessons-learned\" into other industries.\r\n                            </li>\r\n                            <li>\r\n                                Projects will be posted below and under the username\r\n                                <a href=\"https://github.com/nitnub\" \r\n                                   onclick=\"Navigate('https://github.com/nitnub')\" class=\"link\">\r\n                                    nitnub\r\n                                </a>\r\n                                on GitHub.\r\n                            </li>\r\n                        </ul>\r\n                        <p>\r\n                            To get in touch about new projects or professional opportunities,\r\n                            please feel free to contact me via\r\n                            <a href=\"https://linkedin.com/in/nick-bryant-6b1a9579\"\r\n                               onclick=\"Navigate('https://linkedin.com/in/nick-bryant-6b1a9579')\"\r\n                                class=\"link\">\r\n                                LinkedIn\r\n                            </a>\r\n                            !\r\n                        </p>" });

            migrationBuilder.InsertData(
                table: "Logos",
                columns: new[] { "Id", "HTML", "Name" },
                values: new object[,]
                {
                    { 1, "<svg viewBox=\"0 0 128 128\">\r\n                        <path class=\"icon-dark\"\r\n                                fill=\"currentColor\"\r\n                                d=\"M117.5 33.5l.3-.2c-.6-1.1-1.5-2.1-2.4-2.6L67.1 2.9c-.8-.5-1.9-.7-3.1-.7-1.2 0-2.3.3-3.1.7l-48 27.9c-1.7 1-2.9 3.5-2.9 5.4v55.7c0 1.1.2 2.3.9 3.4l-.2.1c.5.8 1.2 1.5 1.9 1.9l48.2 27.9c.8.5 1.9.7 3.1.7 1.2 0 2.3-.3 3.1-.7l48-27.9c1.7-1 2.9-3.5 2.9-5.4V36.1c.1-.8 0-1.7-.4-2.6zm-53.5 70c-21.8 0-39.5-17.7-39.5-39.5S42.2 24.5 64 24.5c14.7 0 27.5 8.1 34.3 20l-13 7.5C81.1 44.5 73.1 39.5 64 39.5c-13.5 0-24.5 11-24.5 24.5s11 24.5 24.5 24.5c9.1 0 17.1-5 21.3-12.4l12.9 7.6c-6.8 11.8-19.6 19.8-34.2 19.8zM115 62h-3.2l-.9 4h4.1v5h-5l-1.2 6h-4.9l1.2-6h-3.8l-1.2 6h-4.8l1.2-6H94v-5h3.5l.9-4H94v-5h5.3l1.2-6h4.9l-1.2 6h3.8l1.2-6h4.8l-1.2 6h2.2v5zm-12.7 4h3.8l.9-4h-3.8z\"></path>\r\n                    </svg>", "C#" },
                    { 2, "<svg viewBox=\"0 0 128 128\" fill=\"currentColor\">\r\n                        <path class=\"icon-dark\" d=\"M61.195 0h4.953c12.918.535 25.688 4.89 36.043 12.676 9.809 7.289 17.473 17.437 21.727 28.906 2.441 6.387 3.664 13.18 4.082 19.992v4.211c-.414 11.293-3.664 22.52-9.73 32.082-6.801 10.895-16.922 19.73-28.727 24.828A64.399 64.399 0 0165.082 128h-2.144c-11.735-.191-23.41-3.66-33.297-9.992-11.196-7.113-20.114-17.785-25.028-30.117C1.891 81.19.441 74.02 0 66.812v-4.957c.504-14.39 5.953-28.609 15.41-39.496C23.168 13.31 33.5 6.48 44.887 2.937 50.172 1.27 55.676.41 61.195 0M25.191 37.523c-.03 12.153-.011 24.305-.011 36.454 1.43.011 2.86.011 4.293.011-.075-10.433.101-20.863-.106-31.293.48.907.918 1.84 1.465 2.707C37.035 54.91 43.105 64.5 49.309 74c1.738-.023 3.476-.023 5.214.004-.003-12.16-.007-24.32.004-36.48a308.076 308.076 0 00-4.25-.012c.075 10.32-.136 20.64.125 30.949-6.507-10.352-13.101-20.645-19.695-30.945a370.85 370.85 0 00-5.516.007m38.844-.011c-.129 12.16-.004 24.32-.047 36.476 6.469-.015 12.938.024 19.41-.02a83.36 83.36 0 01.024-3.952c-5.012-.016-10.027.007-15.043-.02-.074-4.21-.004-8.426-.04-12.637 4.395-.078 8.79.012 13.18-.047-.011-1.277-.011-2.554-.019-3.832-4.387.141-8.773-.054-13.164.012.012-4.023.02-8.05.02-12.078 4.699 0 9.398-.02 14.093.012-.008-1.301 0-2.606.016-3.906-6.145-.016-12.29-.008-18.43-.008m22.602.054c.004 1.266.004 2.528.008 3.79 3.488-.04 6.972.109 10.46.035-.023 10.863.004 21.718-.011 32.574 1.46.043 2.93.035 4.39-.09-.12-5.992.118-11.988-.156-17.977.067-2.699-.07-5.394.117-8.09.106-2.14-.277-4.277-.035-6.417 3.516.047 7.035.015 10.55.015a59.774 59.774 0 01.075-3.832c-8.469-.105-16.937-.094-25.398-.008M13.55 69.094c-1.977.91-2.106 4.023-.149 5.027 1.72 1.18 4.305-.371 4.227-2.41.133-2.004-2.29-3.688-4.078-2.617m29.23 15.289c-4.277 3.469-4.226 11.195.5 14.25 2.668 1.695 6.102 1.344 8.922.215.012-.621.027-1.239.05-1.86-2.671 1.395-6.41 1.68-8.675-.61-2.965-3.237-2.297-9.269 1.613-11.476 2.211-1.164 4.907-.824 7.086.239-.007-.66-.004-1.32 0-1.98-3.097-1.099-6.922-1.04-9.496 1.222m17.207 2.71c-1.89.22-3.758 1.22-4.633 2.966-1.253 2.496-1.109 5.867.864 7.96 2.035 2.297 5.945 2.32 8.18.297 2.425-2.308 2.699-6.468.757-9.164-1.148-1.629-3.273-2.183-5.168-2.058m17.887 2.722c-1.66 2.883-1.332 7.25 1.598 9.211 2.183 1.22 4.933.832 7.074-.308-.004-.617.004-1.235.031-1.848-1.687 1.07-3.937 1.856-5.812.777-1.309-.722-1.704-2.257-1.914-3.625 2.875-.039 5.746-.082 8.625-.074-.075-1.828-.118-3.894-1.45-5.308-2.199-2.43-6.644-1.657-8.152 1.175m-8.414-2.336v12.008c.652 0 1.312 0 1.973.004.023-2.195-.04-4.394.023-6.594.016-1.27.527-2.558 1.484-3.414.801-.605 1.883-.27 2.801-.246-.012-.636-.02-1.27-.023-1.902-1.793-.398-3.336.652-4.242 2.117-.02-.633-.04-1.266-.051-1.894-.656-.024-1.313-.051-1.965-.079zm0 0\"></path>\r\n                        <path class=\"icon-dark\" d=\"M58.758 89.223c1.652-.805 4.023-.41 4.945 1.3 1.05 1.887 1.027 4.383-.137 6.211-1.52 2.286-5.527 1.786-6.523-.742-1.008-2.258-.617-5.484 1.715-6.77zm0 0M79.04 92.414c.046-1.574 1.144-3.137 2.726-3.48.976-.164 2.097.007 2.773.793.672.714.813 1.714.98 2.64-2.16.012-4.32-.031-6.48.047zm0 0\"></path>\r\n                    </svg>", ".NET" },
                    { 3, "<svg viewBox=\"0 0 128 128\" fill=\"currentColor\">\r\n                        <path class=\"icon-dark\" d=\"M35.387 71.79L32.5 70.128l32.152-55.43 2.883 1.656zm0 0\"></path>\r\n                        <path class=\"icon-dark\" d=\"M31.84 65.7h64.3v3.32h-64.3zm0 0\"></path>\r\n                        <path class=\"icon-dark\" d=\"M65.273 86.05l-32.16-18.484 1.664-2.875 32.164 18.485zm0 0M93.215 37.871L61.05 19.387l1.668-2.871L94.879 35zm0 0\"></path>\r\n                        <path class=\"icon-dark\" d=\"M34.785 37.86l-1.664-2.872 32.164-18.484 1.664 2.871zm0 0\"></path>\r\n                        <path class=\"icon-dark\" d=\"M92.621 71.79L60.47 16.354l2.886-1.656 32.153 55.43zm0 0M34.39 32.79h3.333v36.968H34.39zm0 0\"></path>\r\n                        <path class=\"icon-dark\" d=\"M90.277 32.79h3.332v36.968h-3.332zm0 0\"></path>\r\n                        <path class=\"icon-dark\" d=\"M64.707 84.645l-1.457-2.508 27.973-16.078 1.457 2.507zm0 0\"></path>\r\n                        <path class=\"icon-dark\" d=\"M98.027 70.836c-1.925 3.34-6.222 4.477-9.574 2.559a6.962 6.962 0 01-2.57-9.532c1.926-3.34 6.222-4.476 9.574-2.558 3.375 1.937 4.52 6.195 2.57 9.53M42.098 38.684c-1.926 3.336-6.223 4.476-9.575 2.558a6.967 6.967 0 01-2.57-9.535c1.926-3.336 6.223-4.477 9.574-2.559 3.352 1.942 4.496 6.196 2.57 9.536M29.973 70.836c-1.93-3.336-.785-7.594 2.57-9.531 3.352-1.918 7.629-.782 9.574 2.558 1.93 3.336.785 7.594-2.57 9.532-3.371 1.918-7.649.78-9.574-2.56M85.902 38.684c-1.925-3.34-.78-7.594 2.57-9.536 3.352-1.918 7.63-.777 9.575 2.559 1.93 3.34.785 7.594-2.57 9.535-3.352 1.918-7.649.778-9.575-2.558M64 90.402c-3.875 0-7.008-3.117-7.008-6.976 0-3.856 3.133-6.973 7.008-6.973s7.008 3.117 7.008 6.973c0 3.836-3.133 6.976-7.008 6.976M64 26.094c-3.875 0-7.008-3.117-7.008-6.977 0-3.855 3.133-6.972 7.008-6.972s7.008 3.117 7.008 6.972c0 3.86-3.133 6.977-7.008 6.977M106.625 121.508a.604.604 0 01-.45-.168.606.606 0 01-.171-.45v-18.464c0-.188.058-.34.172-.453a.604.604 0 01.449-.168h.54c.187 0 .339.054.452.168a.613.613 0 01.168.453v17.394h9.758c.207 0 .367.055.48.168.114.114.168.274.168.477v.426a.604.604 0 01-.168.449c-.113.113-.273.168-.48.168zm0 0M100.094 123.336a.704.704 0 01-.535-.238 8.22 8.22 0 01-.368-.407l-1.246-1.718c-1.129.543-2.449.816-3.957.816-1.566 0-2.894-.277-3.988-.828-1.094-.555-1.934-1.41-2.516-2.563-.586-1.156-.906-2.613-.96-4.378-.02-.844-.032-1.633-.032-2.364 0-.73.012-1.52.031-2.363.055-1.746.395-3.195 1.016-4.352.621-1.152 1.484-2.011 2.59-2.574 1.101-.562 2.387-.844 3.86-.844 1.468 0 2.753.282 3.859.844 1.101.563 1.968 1.422 2.601 2.574.63 1.157.965 2.606 1.004 4.352a57.2 57.2 0 01.055 2.363c0 .73-.02 1.52-.055 2.364-.094 2.683-.785 4.656-2.066 5.914l1.812 2.53a.41.41 0 01.055.099c.02.046.027.117.027.21a.535.535 0 01-.168.395.541.541 0 01-.394.168zm-6.106-3.234c1.621 0 2.953-.489 4-1.465 1.047-.977 1.606-2.563 1.684-4.758.035-.844.055-1.586.055-2.223 0-.636-.02-1.379-.055-2.222-.04-1.465-.309-2.657-.809-3.575-.5-.921-1.168-1.59-2.008-2.015-.835-.422-1.793-.633-2.867-.633-1.058 0-2.004.21-2.843.633-.84.426-1.508 1.094-2.008 2.015-.5.918-.778 2.11-.832 3.575-.02.843-.032 1.586-.032 2.222 0 .637.012 1.38.032 2.223.074 2.195.64 3.781 1.695 4.758 1.055.976 2.383 1.465 3.988 1.465zm0 0M70.855 121.508a.604.604 0 01-.449-.168.606.606 0 01-.172-.45v-18.75c0-.187.059-.335.172-.449a.604.604 0 01.45-.168h.48c.191 0 .34.055.453.168a.606.606 0 01.172.45v6.671a6.13 6.13 0 011.852-1.601c.726-.414 1.69-.621 2.898-.621 1.281 0 2.352.277 3.207.832.86.55 1.5 1.3 1.926 2.25.422.95.636 2.023.636 3.223v7.996a.606.606 0 01-.171.449.607.607 0 01-.454.168h-.48a.613.613 0 01-.453-.168.604.604 0 01-.168-.45v-7.855c0-1.5-.367-2.68-1.102-3.531-.738-.856-1.812-1.281-3.226-1.281-1.336 0-2.414.425-3.235 1.28-.82.852-1.23 2.032-1.23 3.532v7.856a.606.606 0 01-.172.449.607.607 0 01-.453.168zm0 0M54.43 126.855a.607.607 0 01-.453-.168.606.606 0 01-.172-.449v-18.746c0-.187.058-.34.172-.453a.607.607 0 01.453-.168h.48c.188 0 .34.055.453.168a.613.613 0 01.168.453v1.32c.473-.636 1.09-1.167 1.852-1.59.765-.421 1.73-.632 2.898-.632 1.114 0 2.047.191 2.801.578a5.114 5.114 0 011.836 1.531c.473.64.82 1.352 1.047 2.14.226.79.347 1.595.367 2.423.02.281.027.59.027.93 0 .335-.007.644-.027.925a9.539 9.539 0 01-.367 2.422c-.227.79-.574 1.5-1.047 2.14a5.114 5.114 0 01-1.836 1.532c-.754.387-1.687.578-2.8.578-1.169 0-2.134-.215-2.9-.648-.76-.43-1.378-.957-1.85-1.575v6.672a.604.604 0 01-.169.45.613.613 0 01-.453.167zm5.683-6.699c1.11 0 1.989-.242 2.63-.73a4.097 4.097 0 001.386-1.914c.281-.79.441-1.633.48-2.535a26.44 26.44 0 000-1.575 8.613 8.613 0 00-.48-2.535 4.117 4.117 0 00-1.387-1.914c-.64-.488-1.52-.73-2.629-.73-1.074 0-1.941.254-2.601.757a4.528 4.528 0 00-1.457 1.903 6.899 6.899 0 00-.524 2.293c-.02.281-.027.648-.027 1.097 0 .45.008.817.027 1.098.02.75.192 1.492.524 2.223a4.508 4.508 0 001.5 1.832c.668.488 1.52.73 2.558.73zm0 0M42.582 121.79a5.595 5.595 0 01-2.504-.563 5.079 5.079 0 01-1.851-1.508 3.436 3.436 0 01-.707-2.125c0-1.274.52-2.297 1.554-3.067 1.035-.77 2.383-1.265 4.043-1.492l4.469-.617v-.988c0-.993-.309-1.778-.918-2.348-.613-.574-1.59-.86-2.93-.86-.98 0-1.77.192-2.375.579-.601.383-1.015.886-1.242 1.504-.094.28-.273.422-.539.422h-.45c-.226 0-.386-.059-.484-.184a.687.687 0 01-.14-.434c0-.265.101-.593.297-.984.199-.395.504-.785.922-1.172.414-.383.949-.707 1.609-.969.66-.261 1.46-.394 2.402-.394 1.114 0 2.032.148 2.758.45.727.3 1.293.69 1.7 1.167.402.48.69 1.012.859 1.59.172.582.254 1.156.254 1.719v9.375a.604.604 0 01-.168.449.613.613 0 01-.453.168h-.481a.613.613 0 01-.453-.168.604.604 0 01-.168-.45v-1.324a4.776 4.776 0 01-.961 1.012c-.414.34-.95.625-1.598.86-.652.234-1.465.351-2.445.351zm.281-1.634c.867 0 1.66-.187 2.375-.562.715-.375 1.285-.953 1.711-1.73.426-.778.637-1.759.637-2.942v-.957l-3.648.508c-1.547.203-2.715.562-3.508 1.066-.79.508-1.188 1.145-1.188 1.914 0 .621.18 1.129.54 1.524.359.39.816.687 1.37.882.555.2 1.125.297 1.711.297zm0 0M29.629 121.508a.613.613 0 01-.453-.168.62.62 0 01-.168-.45v-13.37c0-.188.058-.344.168-.465a.594.594 0 01.453-.184h.453c.188 0 .344.063.469.184a.633.633 0 01.183.465v1.293a3.224 3.224 0 011.47-1.461c.64-.32 1.433-.48 2.374-.48h1.047c.188 0 .34.054.453.167a.613.613 0 01.168.453v.39c0 .192-.055.34-.168.454a.613.613 0 01-.453.168H34.41c-1.133 0-2.027.328-2.687.984-.66.657-.989 1.551-.989 2.676v8.727a.586.586 0 01-.183.449.67.67 0 01-.469.168zm0 0M17.387 121.79c-1.621 0-2.985-.313-4.086-.942a6.24 6.24 0 01-2.516-2.633c-.578-1.125-.89-2.422-.95-3.883-.019-.848-.026-1.738-.026-2.676 0-.937.007-1.828.027-2.676.059-1.48.371-2.78.95-3.898a6.237 6.237 0 012.53-2.617c1.11-.63 2.47-.942 4.07-.942 1.302 0 2.415.192 3.337.579.925.382 1.68.863 2.261 1.433.586.574 1.02 1.149 1.301 1.73.285.583.434 1.07.453 1.465a.446.446 0 01-.14.407.64.64 0 01-.453.156h-.622c-.171 0-.293-.043-.367-.125-.078-.086-.152-.23-.226-.438a5.107 5.107 0 00-.95-1.675c-.44-.535-1.035-.977-1.78-1.32-.743-.348-1.684-.524-2.813-.524-1.68 0-3.04.457-4.086 1.367-1.047.91-1.606 2.426-1.684 4.547a78.247 78.247 0 000 5.066c.078 2.102.637 3.61 1.684 4.532 1.047.918 2.406 1.379 4.086 1.379 1.113 0 2.11-.211 2.996-.633a4.726 4.726 0 002.094-1.946c.507-.87.761-1.984.761-3.332v-1.437H18.32a.594.594 0 01-.453-.184.654.654 0 01-.168-.465v-.394c0-.203.055-.363.168-.477a.613.613 0 01.453-.168h6.051c.207 0 .367.055.48.168.114.114.169.274.169.477v2.48c0 1.5-.297 2.825-.891 3.97a6.353 6.353 0 01-2.602 2.671c-1.14.637-2.52.957-4.14.957zm0 0\"></path>\r\n                    </svg>", "GraphQL" },
                    { 4, "<svg viewBox=\"0 0 128 128\" fill=\"currentColor\">\r\n                        <path class=\"icon-dark\" d=\"M2 1v125h125V1H2zm66.119 106.513c-1.845 3.749-5.367 6.212-9.448 7.401-6.271 1.44-12.269.619-16.731-2.059-2.986-1.832-5.318-4.652-6.901-7.901l9.52-5.83c.083.035.333.487.667 1.071 1.214 2.034 2.261 3.474 4.319 4.485 2.022.69 6.461 1.131 8.175-2.427 1.047-1.81.714-7.628.714-14.065C58.433 78.073 58.48 68 58.48 58h11.709c0 11 .06 21.418 0 32.152.025 6.58.596 12.446-2.07 17.361zm48.574-3.308c-4.07 13.922-26.762 14.374-35.83 5.176-1.916-2.165-3.117-3.296-4.26-5.795 4.819-2.772 4.819-2.772 9.508-5.485 2.547 3.915 4.902 6.068 9.139 6.949 5.748.702 11.531-1.273 10.234-7.378-1.333-4.986-11.77-6.199-18.873-11.531-7.211-4.843-8.901-16.611-2.975-23.335 1.975-2.487 5.343-4.343 8.877-5.235l3.688-.477c7.081-.143 11.507 1.727 14.756 5.355.904.916 1.642 1.904 3.022 4.045-3.772 2.404-3.76 2.381-9.163 5.879-1.154-2.486-3.069-4.046-5.093-4.724-3.142-.952-7.104.083-7.926 3.403-.285 1.023-.226 1.975.227 3.665 1.273 2.903 5.545 4.165 9.377 5.926 11.031 4.474 14.756 9.271 15.672 14.981.882 4.916-.213 8.105-.38 8.581z\"></path>\r\n                    </svg>", "JavaScript" },
                    { 5, "<svg viewBox=\"0 0 128 128\" fill=\"currentColor\">\r\n                        <path class=\"icon-dark\" d=\"M0 51.098V76.86h4.422V56.604L20.73 76.87h27.694v-4.113H30.553v-6.801h14.37v-4.113h-14.37v-6.621h17.87v-4.116H26.13v4.116h.002V76.68L5.527 51.098H0zm85.09.01v4.115h9.03v21.65h4.42v-21.65h8.847v-4.116H85.09zm-31.322.011 20.73 25.764h5.803L69.936 64.01l10.35-12.871-5.79.01-7.459 9.261-7.48-9.29h-5.79zm70.158 14.598c-.761 0-1.445.128-2.051.394-.602.263-1.078.633-1.426 1.108-.35.476-.525 1.032-.525 1.664 0 .77.258 1.384.78 1.847.517.464 1.227.809 2.124 1.036l1.24.312a7.02 7.02 0 0 1 1.026.334 1.91 1.91 0 0 1 .683.461 1.034 1.034 0 0 1 .248.697 1.25 1.25 0 0 1-.283.803 1.77 1.77 0 0 1-.76.535 3.11 3.11 0 0 1-1.132.192 3.24 3.24 0 0 1-1.116-.182 1.902 1.902 0 0 1-.804-.557 1.63 1.63 0 0 1-.352-.931h-1.941c.027.71.216 1.316.566 1.812s.836.873 1.46 1.13c.62.26 1.357.39 2.202.39.875 0 1.619-.136 2.233-.4.617-.27 1.088-.643 1.414-1.118.327-.479.488-1.028.488-1.658 0-.466-.09-.872-.266-1.217a2.726 2.726 0 0 0-.72-.887 4.227 4.227 0 0 0-1.028-.607 7.09 7.09 0 0 0-1.19-.385l-1.02-.25a6.975 6.975 0 0 1-.667-.195 2.82 2.82 0 0 1-.597-.285 1.304 1.304 0 0 1-.43-.418 1.037 1.037 0 0 1-.158-.58 1.21 1.21 0 0 1 .238-.717c.156-.21.385-.376.678-.5a2.771 2.771 0 0 1 1.056-.184c.585 0 1.062.126 1.43.383a1.424 1.424 0 0 1 .623 1.07h1.9a2.775 2.775 0 0 0-.513-1.607c-.333-.466-.792-.833-1.377-1.096-.584-.265-1.26-.394-2.033-.394zm-7.998.144v7.55c-.003.377-.062.697-.176.954a1.25 1.25 0 0 1-.506.584c-.218.133-.488.2-.803.2-.29 0-.546-.057-.771-.17a1.247 1.247 0 0 1-.522-.481 1.474 1.474 0 0 1-.195-.75h-1.963c0 .661.147 1.213.447 1.656a2.768 2.768 0 0 0 1.211 1.002 4.22 4.22 0 0 0 1.72.34c.697 0 1.311-.134 1.835-.4a2.97 2.97 0 0 0 1.236-1.149c.293-.499.444-1.093.448-1.787v-7.549h-1.961zm-53.332.059-8.844 10.982h5.805l5.937-7.38-2.898-3.602zm45.785 8.498c-.324 0-.6.112-.83.336a1.07 1.07 0 0 0-.344.807 1.082 1.082 0 0 0 .344.818c.23.225.506.336.83.336a1.105 1.105 0 0 0 .574-.156c.177-.101.318-.24.428-.416a1.115 1.115 0 0 0 .166-.582 1.097 1.097 0 0 0-.354-.807 1.133 1.133 0 0 0-.814-.336z\"></path>\r\n                    </svg>", "Next.js" },
                    { 6, "<svg viewBox=\"0 0 128 128\" fill=\"currentColor\">\r\n                        <path class=\"icon-dark\" d=\"M123.258 76.784c-.45-2.918-2.901-4.829-5.752-4.958-1.032-.047-2.08.061-3.109.192-1.243.158-2.471.438-3.711.623-.857.128-1.726.187-2.582.275l-.021-.111c1.598-3.018 3.263-6.003 4.775-9.064 1.159-2.348 2.151-4.781 3.176-7.194 1.696-3.998 3.051-8.12 4.173-12.309 1.075-4.011 1.995-8.066 2.284-12.227.116-1.662.196-3.331.187-4.995-.008-1.327-.151-2.656-.284-3.979-.15-1.516-.608-2.953-1.242-4.336-.836-1.822-2.132-3.317-3.496-4.737-1.092-1.137-2.293-2.173-3.484-3.208-1.698-1.477-3.607-2.656-5.59-3.703a32.18 32.18 0 00-7.09-2.75c-1.493-.381-3.02-.664-4.532-.966-.544-.11-1.089-.337-1.633-.337H85.086c-.37 0-.737.191-1.11.233-2.452.273-4.875.735-7.228 1.464-.88.273-1.684.101-2.52.024-.641-.059-1.271-.231-1.912-.263-2.442-.122-4.887-.301-7.328-.275-2.339.024-4.654.409-6.918 1.052-1.895.538-3.749 1.195-5.447 2.191-.727.426-1.303.346-2.055.129-2.527-.729-5.072-1.414-7.639-1.989-1.6-.358-3.245-.536-4.879-.707a57.214 57.214 0 00-4.718-.294c-1.538-.033-3.087-.032-4.618.104a30.16 30.16 0 00-7.158 1.513 23.813 23.813 0 00-7.086 3.865c-2.167 1.715-3.905 3.809-5.303 6.2-1.473 2.523-2.483 5.224-3.111 8.061-.34 1.537-.555 3.117-.788 4.678-.073.486.732.972-.268 1.456v6.794c1 .452.208.903.266 1.356.139 1.089.262 2.187.446 3.268.291 1.711.636 3.417.988 5.117a324.86 324.86 0 001.546 7.111c.396 1.72.847 3.43 1.319 5.131.721 2.598 1.431 5.201 2.246 7.77.757 2.387 1.624 4.74 2.484 7.093 1.191 3.255 2.617 6.405 4.327 9.424 1.479 2.614 3.169 5.062 5.436 7.076 1.494 1.327 3.157 2.347 5.093 2.857 1.521.4 3.067.448 4.624.129a10.979 10.979 0 004.824-2.311c.163-.134.342-.236.535.01.735.931 1.719 1.552 2.748 2.089 2.777 1.448 5.803 1.882 8.877 2.059.744.043 1.496-.064 2.246-.085 1.461-.04 2.881-.325 4.278-.729.732-.212 1.447-.481 2.192-.732.039.793.089 1.557.112 2.321l.104 4.166c.019.634.044 1.27.103 1.901.151 1.627.299 3.255.493 4.877.135 1.118.275 2.245.538 3.336a38.176 38.176 0 002.158 6.428 13.81 13.81 0 003.9 5.185c2.22 1.836 4.822 2.619 7.632 2.764 1.162.061 2.357.004 3.501-.204a49.01 49.01 0 005.387-1.275c3.591-1.084 6.695-2.956 9.014-5.981 1.32-1.724 2.404-3.589 3.1-5.648.574-1.701 1.115-3.419 1.545-5.16.34-1.372.508-2.787.715-4.188.137-.927.219-1.863.305-2.797.14-1.517.283-3.033.384-4.553.07-1.058.067-2.121.109-3.181.013-.323.065-.644.095-.966.028-.298.178-.401.482-.396 1.071.016 2.144.044 3.212-.004 1.197-.054 2.405-.105 3.583-.303a56.542 56.542 0 004.99-1.067c1.943-.508 3.725-1.418 5.44-2.455 1.998-1.207 3.819-2.623 5.297-4.447 1.285-1.591 1.894-3.43 1.584-5.438zm-3.412.982c-.066.915-.485 1.699-1.093 2.369-2.869 3.163-6.468 5.082-10.585 6.027-1.564.358-3.178.544-4.779.692a32.093 32.093 0 01-4.114.097c-1.006-.038-2.004-.268-3.032-.416-.103.94-.201 1.919-.32 2.896l-.479 3.745c-.145 1.187-.258 2.378-.407 3.564-.146 1.151-.328 2.298-.481 3.449-.143 1.072-.248 2.149-.407 3.219-.245 1.64-.479 3.284-.799 4.911-.384 1.945-.973 3.829-1.934 5.583-1.172 2.141-2.834 3.772-4.949 4.98-2.18 1.246-4.563 1.894-6.979 2.436-1.71.384-3.472.447-5.204.291-3.004-.272-5.568-1.557-7.506-3.886-1.85-2.223-3.102-4.771-3.55-7.655a63.102 63.102 0 01-.491-4.136 108.067 108.067 0 01-.299-4.62 250.203 250.203 0 01-.197-5.871c-.053-2.406-.07-4.812-.104-7.218l-.006-.092c-1.224.734-2.427 1.538-3.703 2.2a12.392 12.392 0 01-4.798 1.353c-1.318.1-2.653.191-3.965.086-2.151-.173-4.3-.51-6.226-1.569-.781-.43-1.596-.953-2.134-1.64-1.29-1.646-.672-3.726 1.273-4.727 1.344-.693 2.811-.982 4.268-1.319a44.368 44.368 0 003.761-1.029c1.222-.4 1.993-1.391 2.754-2.363l1.206-1.551c-.503-.053-.977-.107-1.451-.151-1.439-.136-2.812-.532-4.125-1.114-1.124-.497-1.141-.551-1.965.343-1.376 1.494-2.714 3.023-4.062 4.542-.992 1.117-1.978 2.241-2.965 3.361-.978 1.108-1.894 2.279-2.947 3.31-1.564 1.531-3.449 2.452-5.698 2.348-1.443-.066-2.764-.572-3.952-1.399-2.452-1.708-4.104-4.097-5.608-6.606-1.927-3.215-3.406-6.64-4.672-10.159-.876-2.432-1.756-4.866-2.521-7.333-.831-2.681-1.56-5.396-2.277-8.11a157.373 157.373 0 01-1.482-6.182 216.117 216.117 0 01-1.464-7.079c-.298-1.599-.471-3.221-.712-4.831-.325-2.17-.385-4.36-.267-6.539.105-1.963.387-3.921.667-5.871.388-2.698 1.277-5.244 2.556-7.648.783-1.473 1.755-2.812 2.879-4.056 1.845-2.042 4.078-3.518 6.562-4.626 1.736-.774 3.57-1.24 5.439-1.604 2.774-.54 5.573-.519 8.373-.461 1.224.025 2.443.248 3.666.369 2.633.262 5.214.816 7.762 1.5 1.857.498 3.676 1.143 5.518 1.703.185.056.456.051.607-.048 2.496-1.629 5.224-2.704 8.125-3.319 1.101-.233 2.237-.335 3.363-.407 1.369-.087 2.749-.167 4.115-.088 1.642.094 3.276.336 4.908.56.792.108 1.565.383 2.359.458.38.036.783-.242 1.185-.335 2.049-.473 4.089-1 6.156-1.374 1.539-.278 3.111-.409 4.676-.499 1.745-.1 3.503-.173 5.247-.089a36.66 36.66 0 016.555.923c2.677.623 5.245 1.528 7.686 2.784 1.824.938 3.558 2.026 5.119 3.364 1.023.878 2.07 1.745 2.994 2.723 1.14 1.206 2.303 2.413 3.018 3.958.538 1.165.922 2.371 1.028 3.647.132 1.586.292 3.178.277 4.766-.014 1.519-.221 3.037-.368 4.552-.334 3.454-1.085 6.833-1.997 10.167a116.972 116.972 0 01-2.589 8.17c-.879 2.481-1.893 4.917-2.918 7.343a80.07 80.07 0 01-2.458 5.303c-1.677 3.286-3.421 6.538-5.438 9.633-.348.535-.678 1.083-1.018 1.629.88.594 1.877.803 2.881.911.955.104 1.929.166 2.883.095 1.527-.113 3.049-.331 4.567-.544 1.504-.21 2.978-.638 4.522-.525 1.542.112 2.645 1.284 2.54 2.729zm-22.013-3.353c-.655-.846-1.323-1.682-1.964-2.538-1.006-1.344-1.729-2.845-2.455-4.353-.688-1.429-1.532-2.782-2.257-4.195-1.265-2.465-2.553-4.922-3.718-7.435-1.465-3.157-2.62-6.426-2.984-9.923-.154-1.48-.193-2.958.106-4.424.479-2.341 1.702-4.172 3.758-5.428 1.907-1.165 4.032-1.541 6.209-1.659 1.351-.073 2.708-.013 4.11-.013l-.047-.237c-.872-1.823-1.687-3.677-2.641-5.457-1.346-2.512-3.068-4.777-4.986-6.877-1.421-1.555-2.96-2.998-4.646-4.273-1.658-1.255-3.405-2.376-5.269-3.293-2.223-1.093-4.538-1.938-6.967-2.477-2.334-.518-4.683-.835-7.077-.861-2.042-.022-4.071.07-6.06.531-3.002.695-5.748 1.931-8.137 3.933a21.143 21.143 0 00-3.517 3.77c-1.196 1.643-2.161 3.417-2.986 5.277-1.132 2.552-1.909 5.208-2.44 7.938-.266 1.361-.474 2.734-.686 4.106-.074.48-.08.971-.123 1.521.369-.192.635-.34.907-.472l.885-.397c2.993-1.369 6.094-2.25 9.427-2.149 1.416.043 2.771.323 4.03.943 2.415 1.191 3.828 3.216 4.442 5.779.424 1.769.714 3.573.996 5.372.221 1.405.447 2.825.473 4.242.037 2.071-.068 4.146-.181 6.216a17.386 17.386 0 01-1.08 5.146c-1.12 2.993-2.368 5.937-3.534 8.913-.385.983-.681 2.001-1.045 3.082.562 0 1.018-.004 1.474.002.178.003.36.008.532.049 1.34.316 2.502.923 3.455 1.954 1.271 1.372 1.938 2.973 1.972 4.826.019 1.027-.089 2.057-.084 3.084.021 4.786.057 9.572.097 14.357.007.782.046 1.565.102 2.346.117 1.635.235 3.271.395 4.902.112 1.157.268 2.312.451 3.461.259 1.628 1 3.077 1.841 4.462.724 1.191 1.665 2.203 2.905 2.901 2.107 1.186 4.376 1.285 6.663.848 1.545-.295 3.062-.769 4.562-1.258a10.128 10.128 0 003.937-2.354c1.051-1.019 1.797-2.261 2.3-3.632.976-2.659 1.28-5.459 1.684-8.237.151-1.04.282-2.083.42-3.125.157-1.186.316-2.371.468-3.556.112-.883.214-1.768.322-2.651.154-1.268.317-2.535.464-3.804.113-.981.209-1.966.309-2.949.129-1.256.268-2.512.379-3.77.086-.955.051-1.927.22-2.864.311-1.718 1.123-3.18 2.646-4.125.637-.395 1.356-.655 2.063-.989l-.12-.186zm-57.597-7.052a17.526 17.526 0 01-1.354-5.622c-.128-1.825.089-3.643.276-5.46.182-1.76.333-3.528.386-5.296.088-2.906-.108-5.808-.247-8.712-.084-1.729.117-3.479.271-5.212.139-1.561.312-3.126.607-4.664.495-2.581 1.152-5.125 2.086-7.591.887-2.338 1.906-4.615 3.345-6.665.986-1.406 2.105-2.72 3.18-4.094l-.319-.113c-3.498-1.111-7.053-1.979-10.709-2.358-1.729-.179-3.464-.284-5.198-.387-.532-.032-1.072.04-1.606.091-1.322.126-2.66.176-3.961.424-2.214.421-4.338 1.129-6.305 2.282-1.766 1.035-3.249 2.373-4.491 3.978-1.372 1.772-2.295 3.776-2.958 5.913-.783 2.521-1.156 5.115-1.257 7.733-.088 2.295-.132 4.603.264 6.889.295 1.702.492 3.422.817 5.117.443 2.311.918 4.617 1.467 6.904.785 3.274 1.569 6.553 2.499 9.787.89 3.099 1.894 6.17 2.982 9.204.89 2.476 1.919 4.906 3.003 7.304.706 1.562 1.561 3.065 2.457 4.528.953 1.553 2.037 3.027 3.508 4.154 1.856 1.423 3.293 1.644 5.179.083.808-.669 1.491-1.495 2.194-2.282 1.117-1.25 2.195-2.534 3.307-3.788 1.416-1.598 2.85-3.179 4.273-4.769.301-.336.59-.682.883-1.022l-.484-.425a17.695 17.695 0 01-4.095-5.931zm53.688-47.569a61.488 61.488 0 013.309 4.204c2 2.809 3.598 5.842 4.775 9.087.521 1.43.937 2.874.751 4.439-.129 1.096-.118 2.208-.215 3.31-.081.917-.226 1.829-.345 2.743-.178 1.378-.436 2.752-.513 4.136-.073 1.317.003 2.648.086 3.968.084 1.341.265 2.676.388 4.015.139 1.518.326 3.036.369 4.557.035 1.249-.076 2.506-.185 3.753-.13 1.502-.511 2.956-1.079 4.351-.399.982-.876 1.934-1.327 2.917l.181.192.275.213.277-.496a93.621 93.621 0 006.222-11.493 186.333 186.333 0 003.287-7.766c1.624-4.064 2.909-8.242 3.903-12.503.446-1.913.787-3.855 1.09-5.797.236-1.518.433-3.054.477-4.586.047-1.625-.043-3.263-.193-4.884-.112-1.224-.414-2.456-1.181-3.451-1.233-1.602-2.564-3.134-4.201-4.346-1.378-1.021-2.751-2.068-4.23-2.927-2.345-1.36-4.883-2.266-7.535-2.883-2.588-.603-5.21-.863-7.849-.918-1.556-.033-3.119.134-4.672.28-1.407.132-2.805.357-4.222.543 1.52.855 3.019 1.615 4.433 2.511 2.973 1.883 5.637 4.149 7.924 6.831zM55.299 72.514c.961-3.073 2.27-6.007 3.538-8.959 1.028-2.394 1.59-4.916 1.777-7.506.093-1.277.067-2.57.004-3.851a44.628 44.628 0 00-.392-4.259c-.266-1.801-.569-3.603-.995-5.371-.462-1.913-1.627-3.245-3.623-3.736-1.216-.299-2.424-.287-3.653-.093-3.002.473-5.75 1.579-8.31 3.199-.515.326-.798.589-.709 1.328.188 1.565.229 3.155.222 4.735-.01 2.236-.105 4.472-.19 6.707-.028.728-.133 1.452-.211 2.177-.12 1.11-.351 2.219-.344 3.327.007 1.142.124 2.311.401 3.417.88 3.507 2.744 6.377 5.799 8.402 1.879 1.245 3.958 1.873 6.24 1.992.155-.524.293-1.019.446-1.509zm-3.586-30.087c-.402-.844-.172-1.543.76-1.867.227-.08.461-.165.697-.188.324-.032.654-.008.982-.008 1.182.006 2.319.171 3.295.923.626.482.794 1.122.389 1.779-.575.932-1.452 1.4-2.529 1.49-1.697.141-2.888-.65-3.594-2.129zm47.04-.308c.136-1.124.245-2.251.384-3.375.056-.452-.182-.574-.561-.585-1.192-.033-2.384-.075-3.576-.097-1.344-.024-2.652.192-3.896.703-1.38.568-2.431 1.478-2.86 2.98a9.042 9.042 0 00-.293 3.41 20.11 20.11 0 001.193 5.176c.834 2.221 1.707 4.441 2.75 6.569 1.413 2.881 3.012 5.67 4.513 8.507.401.757.738 1.547 1.156 2.431a13.783 13.783 0 001.351-5.622c.041-1.61-.088-3.227-.182-4.838-.059-.986-.198-1.966-.294-2.95-.134-1.371-.337-2.741-.368-4.115-.031-1.397.068-2.802.188-4.197.113-1.338.334-2.665.495-3.997zm-2.689-1.082c-.443 1.223-1.39 1.913-2.618 2.116-1.145.188-2.148-.235-2.894-1.148-.531-.65-.328-1.42.468-1.859.914-.506 1.919-.634 3.104-.711.322.059.807.108 1.268.24.669.189.916.692.672 1.362zm-35.422 37.66c-.655-.535-1.521-.566-2.144.021-.773.73-1.453 1.565-2.133 2.388-.785.951-1.521 1.94-2.534 2.677-1.474 1.071-3.192 1.515-4.919 1.935-1.373.334-2.752.644-4.129.965l-.017.178c.409.189.805.425 1.231.56 2.1.665 4.236.996 6.455.808 1.602-.136 3.128-.485 4.574-1.171 1.99-.943 3.521-2.437 4.823-4.175.218-.29.317-.719.343-1.093.089-1.321-.582-2.303-1.55-3.093zm51.751.526c-1.69.181-3.382.373-5.077.47-.818.047-1.648-.109-2.474-.176-1.385-.112-2.737-.42-3.908-1.16-.678-.427-1.241-.475-1.961-.233-1.028.346-1.867.872-2.115 1.986-.169.753-.23 1.533-.298 2.304-.013.136.157.386.287.42.793.209 1.59.456 2.401.529.996.09 2.01.061 3.013.011 1.083-.054 2.173-.124 3.24-.304 2.515-.422 4.948-1.11 7.109-2.536.779-.515 1.551-1.041 2.325-1.562l-.064-.11c-.826.123-1.648.273-2.478.361z\"></path>\r\n                    </svg>", "PostgreSQL" },
                    { 7, "<svg viewBox=\"0 0 128 128\" fill=\"currentColor\">\r\n                        <path class=\"icon-dark\" d=\"M.3 71.2c-.4-.7-.4-1.5 0-2.1l14.4-23.6c.8-1.3 2.7-1.2 3.4.2l13.1 28.7c.5 1.1 0 2.3-1.2 2.6L9.6 83.2c-.9.3-1.7-.1-2.2-.8zm11 6.6c-.1.5.4 1 .9.8l14.1-4.2c.4-.1.7-.6.5-1l-9.1-21.1c-.3-.6-1.2-.5-1.4.2zM69 59.4h4.1v14.8H69zm-.1-3.8q0-2 2.1-2 2.2 0 2.2 2 0 .9-.5 1.4-.6.6-1.7.6-2.1 0-2.1-2zm56.3 18.6-.8-2h-.1q-1 1.3-2 1.8-1.1.5-2.9.5-2.1 0-3.3-1.2-1.2-1.3-1.2-3.5 0-2.4 1.6-3.5 1.7-1.1 5-1.2l2.5-.1v-.7q0-2.2-2.3-2.2-1.7 0-4.1 1.1l-1.3-2.8q2.5-1.3 5.6-1.3 3 0 4.6 1.3 1.5 1.3 1.5 3.9v9.9zm-1.2-6.9-1.5.1q-1.8 0-2.6.6-.9.6-.9 1.8 0 1.7 2 1.7 1.4 0 2.2-.8.8-.8.8-2.1zm-20.8 6.8h-4.1v-8.6q0-1.6-.5-2.4-.5-.8-1.7-.8-1.5 0-2.2 1.1-.7 1.1-.7 3.8v6.9h-4V59.3h3l.6 1.9h.2q.6-1 1.7-1.6 1.1-.6 2.6-.6 3.3 0 4.5 2.2h.3q.6-1 1.8-1.6 1.1-.6 2.6-.6 2.5 0 3.8 1.3 1.2 1.3 1.2 4.2v9.6h-4v-8.6q0-1.6-.5-2.4-.6-.8-1.7-.8-1.5 0-2.2 1-.7 1.1-.7 3.4zm-22.3.3q-1.6 0-2.7-.3-1.1-.2-2.1-.6v-3.3q1.1.5 2.5.8 1.4.4 2.5.4 2.2 0 2.2-1.3 0-.4-.3-.7-.3-.3-1-.7-.8-.4-1.9-.9-1.7-.7-2.5-1.3-.8-.6-1.2-1.4-.4-.8-.4-2 0-1.9 1.6-3 1.5-1.1 4.3-1.1 2.6 0 5.2 1.2l-1.3 2.9q-1.1-.5-2-.8-1-.3-2-.3-1.8 0-1.8 1 0 .5.6.9t2.5 1.2q1.7.7 2.6 1.3.8.6 1.1 1.4.4.8.4 1.9 0 2.3-1.6 3.5-1.5 1.2-4.7 1.2zM66.6 62.9q-.5-.1-1.2-.1-1.9 0-3 1t-1.1 2.8v7.5h-4V59.3h3.1l.6 2.5h.2q.6-1.3 1.8-2 1.2-.8 2.5-.8.9 0 1.4.1zm-11.9-2.1q0 3.1-1.9 4.8-2 1.6-5.6 1.6h-1.7v6.9h-4.1V54.7h6.2q3.5 0 5.3 1.6 1.8 1.5 1.8 4.5zm-9.2 3.1h1.3q1.9 0 2.9-.8.9-.7.9-2.2 0-1.4-.8-2.1-.8-.7-2.5-.7h-1.8z\"></path>\r\n                    </svg>", "Prisma" },
                    { 8, "<svg viewBox=\"0 0 128 128\" fill=\"currentColor\">\r\n                        <g>\r\n                            <circle class=\"icon-dark\" cx=\"64\" cy=\"64\" r=\"11.4\"></circle>\r\n                            <path class=\"icon-dark\" d=\"M107.3 45.2c-2.2-.8-4.5-1.6-6.9-2.3.6-2.4 1.1-4.8 1.5-7.1 2.1-13.2-.2-22.5-6.6-26.1-1.9-1.1-4-1.6-6.4-1.6-7 0-15.9 5.2-24.9 13.9-9-8.7-17.9-13.9-24.9-13.9-2.4 0-4.5.5-6.4 1.6-6.4 3.7-8.7 13-6.6 26.1.4 2.3.9 4.7 1.5 7.1-2.4.7-4.7 1.4-6.9 2.3C8.2 50 1.4 56.6 1.4 64s6.9 14 19.3 18.8c2.2.8 4.5 1.6 6.9 2.3-.6 2.4-1.1 4.8-1.5 7.1-2.1 13.2.2 22.5 6.6 26.1 1.9 1.1 4 1.6 6.4 1.6 7.1 0 16-5.2 24.9-13.9 9 8.7 17.9 13.9 24.9 13.9 2.4 0 4.5-.5 6.4-1.6 6.4-3.7 8.7-13 6.6-26.1-.4-2.3-.9-4.7-1.5-7.1 2.4-.7 4.7-1.4 6.9-2.3 12.5-4.8 19.3-11.4 19.3-18.8s-6.8-14-19.3-18.8zM92.5 14.7c4.1 2.4 5.5 9.8 3.8 20.3-.3 2.1-.8 4.3-1.4 6.6-5.2-1.2-10.7-2-16.5-2.5-3.4-4.8-6.9-9.1-10.4-13 7.4-7.3 14.9-12.3 21-12.3 1.3 0 2.5.3 3.5.9zM81.3 74c-1.8 3.2-3.9 6.4-6.1 9.6-3.7.3-7.4.4-11.2.4-3.9 0-7.6-.1-11.2-.4-2.2-3.2-4.2-6.4-6-9.6-1.9-3.3-3.7-6.7-5.3-10 1.6-3.3 3.4-6.7 5.3-10 1.8-3.2 3.9-6.4 6.1-9.6 3.7-.3 7.4-.4 11.2-.4 3.9 0 7.6.1 11.2.4 2.2 3.2 4.2 6.4 6 9.6 1.9 3.3 3.7 6.7 5.3 10-1.7 3.3-3.4 6.6-5.3 10zm8.3-3.3c1.5 3.5 2.7 6.9 3.8 10.3-3.4.8-7 1.4-10.8 1.9 1.2-1.9 2.5-3.9 3.6-6 1.2-2.1 2.3-4.2 3.4-6.2zM64 97.8c-2.4-2.6-4.7-5.4-6.9-8.3 2.3.1 4.6.2 6.9.2 2.3 0 4.6-.1 6.9-.2-2.2 2.9-4.5 5.7-6.9 8.3zm-18.6-15c-3.8-.5-7.4-1.1-10.8-1.9 1.1-3.3 2.3-6.8 3.8-10.3 1.1 2 2.2 4.1 3.4 6.1 1.2 2.2 2.4 4.1 3.6 6.1zm-7-25.5c-1.5-3.5-2.7-6.9-3.8-10.3 3.4-.8 7-1.4 10.8-1.9-1.2 1.9-2.5 3.9-3.6 6-1.2 2.1-2.3 4.2-3.4 6.2zM64 30.2c2.4 2.6 4.7 5.4 6.9 8.3-2.3-.1-4.6-.2-6.9-.2-2.3 0-4.6.1-6.9.2 2.2-2.9 4.5-5.7 6.9-8.3zm22.2 21l-3.6-6c3.8.5 7.4 1.1 10.8 1.9-1.1 3.3-2.3 6.8-3.8 10.3-1.1-2.1-2.2-4.2-3.4-6.2zM31.7 35c-1.7-10.5-.3-17.9 3.8-20.3 1-.6 2.2-.9 3.5-.9 6 0 13.5 4.9 21 12.3-3.5 3.8-7 8.2-10.4 13-5.8.5-11.3 1.4-16.5 2.5-.6-2.3-1-4.5-1.4-6.6zM7 64c0-4.7 5.7-9.7 15.7-13.4 2-.8 4.2-1.5 6.4-2.1 1.6 5 3.6 10.3 6 15.6-2.4 5.3-4.5 10.5-6 15.5C15.3 75.6 7 69.6 7 64zm28.5 49.3c-4.1-2.4-5.5-9.8-3.8-20.3.3-2.1.8-4.3 1.4-6.6 5.2 1.2 10.7 2 16.5 2.5 3.4 4.8 6.9 9.1 10.4 13-7.4 7.3-14.9 12.3-21 12.3-1.3 0-2.5-.3-3.5-.9zM96.3 93c1.7 10.5.3 17.9-3.8 20.3-1 .6-2.2.9-3.5.9-6 0-13.5-4.9-21-12.3 3.5-3.8 7-8.2 10.4-13 5.8-.5 11.3-1.4 16.5-2.5.6 2.3 1 4.5 1.4 6.6zm9-15.6c-2 .8-4.2 1.5-6.4 2.1-1.6-5-3.6-10.3-6-15.6 2.4-5.3 4.5-10.5 6-15.5 13.8 4 22.1 10 22.1 15.6 0 4.7-5.8 9.7-15.7 13.4z\"></path>\r\n                        </g>\r\n                    </svg>", "React" },
                    { 9, "<svg viewBox=\"0 0 128 128\" fill=\"currentColor\">\r\n                        <path class=\"icon-dark\" d=\"M6.2 52.7c6.7 3.2 43.7 18.1 49.5 20.9 5.8 2.8 10 2.8 17.4-1 7.4-3.9 42.2-18.1 48.9-21.6 3.4-1.8 4.9-3.2 4.9-4.4V34.1c0-1.3-1.7-2.4-5-3.6-6.5-2.4-41.1-16.1-47.7-18.6-6.6-2.4-9.3-2.3-17.1.5C49.3 15.2 12.6 29.6 6 32.2c-3.2 1.3-5 2.4-5 3.7H.8v12.7c.2 1.2 2.1 2.5 5.4 4.1zm60.4 1.8l-20.3-8.4 29.1-4.5-8.8 12.9zm44.1-20l-17.2 6.8-1.9.7-17.2-6.8 19.1-7.5 17.2 6.8zM60.1 22l-2.8-5.2 8.8 3.4 8.3-2.7-2.2 5.4 8.4 3.2-10.9 1.1-2.4 5.9-3.9-6.5-12.6-1.1 9.3-3.5zm-21.7 7.3c8.6 0 15.6 2.7 15.6 6s-7 6-15.6 6-15.6-2.7-15.6-6 7-6 15.6-6zM122 59.8c-6.7 3.5-41.4 17.8-48.8 21.6-7.4 3.9-11.5 3.8-17.3 1-5.8-2.8-43-17.7-49.6-20.9C2.9 59.9 1 58.6 1 57.3V70c0 1.3 1.9 2.6 5.2 4.2 6.7 3.2 43.7 18.1 49.5 20.9 5.8 2.8 10 2.8 17.4-1 7.4-3.9 42.2-18.1 48.9-21.6 3.4-1.8 4.9-3.2 4.9-4.4V55.6c0 1.1-1.6 2.5-4.9 4.2zm0 20.7c-6.7 3.5-41.4 17.8-48.8 21.6-7.4 3.9-11.5 3.8-17.3 1-5.8-2.8-43-17.7-49.6-20.9C2.9 80.7 1 79.3 1 78v12.7c0 1.3 1.9 2.6 5.2 4.2 6.7 3.2 43.7 18.1 49.5 20.9 5.8 2.8 10 2.8 17.4-1 7.4-3.9 42.2-18.1 48.9-21.6 3.4-1.8 4.9-3.2 4.9-4.4V76.3c0 1.2-1.6 2.5-4.9 4.2z\"></path>\r\n                    </svg>", "Redis" },
                    { 10, "<svg viewBox=\"0 0 128 128\" fill=\"currentColor\">\r\n                        <path class=\"icon-dark\" d=\"M52.935 0v.002c-.426-.058-7.306 2.42-11.742 4.223-5.988 2.44-10.636 4.766-13.504 6.78-.926.657-2.054 1.75-2.475 2.37l-.007-.021a1.424 1.424 0 0 0-.069.148c-.022.04-.052.086-.066.12a1.812 1.812 0 0 0-.115.66l.064.06c.017.207.065.44.168.695.252.62.988 1.376 1.822 2.15 0 0 8.621 8.409 9.668 9.61 4.766 5.503 6.84 10.927 7.034 18.406.117 4.805-.796 9.03-3.063 13.932-4.03 8.796-12.535 18.504-25.652 29.276l.199-.067c-.09.072-.208.174-.295.242-1.57 1.24-3.896 3.565-5.078 5.038-1.764 2.209-3.157 4.553-3.758 6.355-1.066 3.255-.543 6.548 1.51 9.59 2.636 3.875 7.887 7.83 14.01 10.521 3.12 1.377 8.368 3.14 12.322 4.127 6.567 1.667 19.28 3.469 26.273 3.739 1.414.059 3.312.059 3.39 0 .155-.097 1.241-2.168 2.501-4.744 4.3-8.778 7.399-17.013 9.086-24.047 1.007-4.262 1.801-9.94 2.324-16.663.136-1.88.194-8.177.078-10.308-.175-3.487-.483-6.316-.968-9.086a4.17 4.17 0 0 1-.07-.573c15.578-4.628 32.768-8.821 44.187-10.568l1.764-.271-.272-.428c-1.55-2.403-2.615-3.894-3.894-5.483-3.72-4.61-8.233-8.349-13.756-11.449-7.595-4.244-17.419-7.557-29.858-10.018-2.344-.465-7.495-1.357-11.68-1.996l-.39-.699c-2.287-4.03-4.805-9.027-6.278-12.398-1.142-2.616-2.228-5.639-2.828-7.809C53.187.098 53.15.02 52.935 0Zm-.31.988h.02c.018.02.095.564.173 1.203.33 2.712.931 5.328 1.881 8.157.716 2.13.716 2.015-.117 1.763-1.976-.542-10.83-2.072-17.244-2.964-1.027-.135-1.899-.271-1.899-.291-.077-.078 4.63-2.537 6.703-3.506 2.654-1.22 9.94-4.265 10.483-4.362ZM33.947 9.67l.756.252c4.108 1.395 14.434 3.373 20.13 3.838.64.058 1.182.115 1.2.115.02.02-.52.31-1.219.639-2.75 1.376-5.775 3.061-7.867 4.36-.476.296-.912.546-1.127.648a1193.726 1193.726 0 0 1-1.932-.315l-1.824-1.787a803.536 803.536 0 0 0-7.11-6.84zm-.775.602 2.732 3.41c1.492 1.88 3.003 3.72 3.332 4.127.291.359.503.622.543.7-1.935-.337-4.006-.708-5.6-1.052-1.163-.252-3.39-.775-5.134-1.375-.18-.07-.385-.146-.58-.219v-.205c.02-1.3 1.666-3.238 4.455-5.213zm23.173 4.646c.015-.007.03-.006.04.004.077 0 .172.172.404.695.66 1.453 2.715 5.367 3.219 6.123l.064.104a1193.726 1193.726 0 0 1-10.977-1.79 2.86 2.86 0 0 1 .372-.232c2.035-1.124 4.088-2.557 5.91-4.088.445-.368.851-.715.93-.773a.097.097 0 0 1 .038-.043zm-26.138 3.275c.019-.018.329.1.736.235a50.336 50.336 0 0 0 2.81.851 142.909 142.909 0 0 0 2.557.678c1.162.29 2.132.563 2.15.563.137.136 2.094 6.394 2.753 8.797.252.91.446 1.685.427 1.685-.02.02-.234-.31-.486-.756-2.267-3.99-5.851-8.04-9.998-11.297-.542-.387-.95-.736-.95-.756zm9.513 2.618c0 .038 0 .02.02.02.098 0 .524.057 1.047.173 3.293.736 9.203 1.86 12.98 2.5.64.097 1.143.214 1.143.252 0 .04-.23.175-.522.33-.64.33-3.217 1.86-4.07 2.44-2.15 1.435-4.087 2.983-5.482 4.378a79.99 79.99 0 0 1-1.047 1.028s-.115-.33-.213-.737c-.697-2.694-2.15-6.684-3.469-9.494-.213-.445-.387-.852-.387-.89zm16.8 3.215c.115.04.31.699.697 2.152a31.732 31.732 0 0 1 .93 8.873c-.04.814-.079 1.57-.118 1.668l-.057.191-1.007-.33c-2.073-.658-5.444-1.645-8.33-2.459-1.648-.446-2.985-.852-2.985-.89 0-.117 2.403-2.52 3.43-3.43 1.956-1.725 7.264-5.832 7.44-5.775zm1.335.195c.058-.058 8.024 1.316 11.647 2.014 2.694.523 6.607 1.338 6.84 1.435.115.04-.291.269-1.59.852-5.115 2.305-8.914 4.38-12.692 6.898-.988.66-1.822 1.201-1.84 1.201-.02 0-.039-.562-.039-1.24 0-3.681-.734-7.401-2.091-10.54-.136-.31-.254-.601-.235-.62zm20.596 4.068c.058.057-.193 1.629-.426 2.559-.698 2.887-2.576 7.17-4.88 11.2-.409.716-.778 1.297-.817 1.316-.038.02-.558-.273-1.16-.622-2.247-1.318-4.806-2.555-7.596-3.718-.775-.33-1.454-.601-1.473-.641-.136-.115 6.104-4.242 9.397-6.219 2.617-1.589 6.879-3.952 6.955-3.875zm1.475.233c.174 0 3.7.968 5.54 1.511 4.554 1.356 9.784 3.275 13.194 4.825l1.414.638-.986.233c-8.33 1.918-15.463 4.129-22.342 6.918-.562.233-1.066.425-1.104.425-.039 0 .157-.444.409-.986 2.073-4.399 3.408-8.991 3.738-12.906.019-.368.079-.658.137-.658zm-35.11 8.06c.058-.058 2.751.582 4.205.989 2.21.62 6.899 2.19 6.899 2.304 0 .02-.525.466-1.145 1.008-2.538 2.112-4.98 4.341-7.906 7.17-.871.833-1.606 1.51-1.645 1.51-.04 0-.059-.115-.04-.27.445-3.255.35-7.44-.27-11.683-.06-.543-.117-1.009-.098-1.028zm56.596.059c.038.039-1.24 2.052-2.055 3.195-1.162 1.667-2.867 3.877-6.722 8.72a1289.46 1289.46 0 0 0-5.076 6.413c-.775.969-1.415 1.783-1.436 1.783-.018 0-.27-.35-.541-.775-2.17-3.256-4.767-6.103-7.848-8.66a44.534 44.534 0 0 0-1.431-1.164c-.214-.155-.39-.31-.39-.33 0-.057 3.294-1.472 5.794-2.479 4.38-1.783 10.345-3.913 14.822-5.29 2.344-.735 4.844-1.452 4.883-1.413zm1.492.387c.077-.02.543.214 1.104.543 4.709 2.693 9.32 6.162 12.963 9.726 1.027 1.008 3.564 3.641 3.525 3.66 0 0-.891.08-1.937.157-8.157.62-18.6 2.343-28.635 4.765-.68.155-1.28.291-1.319.291-.038 0 .716-.756 1.666-1.666 5.89-5.677 8.583-9.261 11.76-15.656.446-.948.834-1.762.873-1.82zm-43.148 4.418c.27.058 2.788 1.239 4.687 2.189 1.744.871 4.361 2.266 4.496 2.383.02.019-.91.503-2.054 1.066a135.033 135.033 0 0 0-10.018 5.522c-.93.562-1.704 1.027-1.723 1.027-.078 0-.058-.078.465-1.027 1.744-3.177 3.14-6.975 3.934-10.676.077-.29.155-.484.213-.484zm-2.52.464c.058.058-.6 2.442-1.008 3.74-.795 2.46-2.131 5.54-3.43 7.866-.31.542-.775 1.338-1.027 1.783l-.484.774-1.084-1.045c-1.26-1.22-2.287-1.978-3.604-2.657-.524-.27-.93-.502-.93-.54 0-.156 3.314-3.159 5.852-5.329 1.82-1.57 5.657-4.65 5.715-4.592zm15.404 6.336.95.62c2.17 1.414 4.726 3.295 6.683 4.94 1.104.91 3.235 2.83 3.662 3.294l.233.252-1.57.447c-8.874 2.46-15.733 4.649-23.735 7.594-.892.33-1.647.6-1.705.6-.116 0-.213.096 1.783-1.745 5.115-4.707 9.65-9.898 13.022-14.955zm-4.05 1.008c.04.04-2.614 3.777-4.203 5.889-1.9 2.519-5.272 6.743-7.598 9.494-.968 1.144-1.8 2.092-1.84 2.111-.058.02-.078-.27-.078-.716 0-2.344-.599-4.844-1.645-6.975-.446-.891-.523-1.104-.425-1.201.368-.33 6.004-3.545 9.568-5.463 2.404-1.28 6.163-3.177 6.22-3.139zM44.1 55.26c.057 0 .502.233 1.007.504a21.28 21.28 0 0 1 3.332 2.248c.04.038-.464.446-1.123.93-1.84 1.317-4.63 3.43-6.258 4.728-1.705 1.356-1.763 1.394-1.57 1.104 1.28-1.957 1.92-3.062 2.598-4.477a36.066 36.066 0 0 0 1.627-4.05c.155-.56.347-.987.386-.987zm6.53 5.113c.097-.018.213.157.735.932 1.104 1.647 1.957 3.857 2.17 5.639l.039.386-2.654 1.028c-4.747 1.84-9.126 3.662-12.09 5.02a217.067 217.067 0 0 0-3.237 1.548c-.95.484-1.724.853-1.724.834 0-.02.6-.465 1.336-1.008 5.794-4.204 10.813-8.816 14.572-13.427.407-.484.775-.93.813-.95zm-3.003.737v.002c.078.077-2.132 2.576-3.643 4.107-3.74 3.816-7.441 6.801-12.033 9.707-.582.368-1.104.697-1.162.735-.135.078.038-.116 2.054-2.305a52.694 52.694 0 0 0 3.352-3.97c.736-.95.871-1.086 1.937-1.84 2.85-2.056 9.418-6.513 9.495-6.436zm25.974 2.3c.274 1.057.78 6.126.918 9.481.04.795.019 1.318-.021 1.318-.154 0-3.273-1.84-5.5-3.236-1.93-1.215-5.579-3.634-6.18-4.113a358.495 358.495 0 0 1 10.783-3.45zm-12.867 4.192c.254.11.635.32 1.404.795 3.991 2.5 9.418 5.522 11.743 6.53.716.31.793.193-.854 1.318-3.526 2.402-7.924 4.765-13.31 7.148-.95.426-1.745.756-1.764.756-.04 0 .077-.486.232-1.067 1.297-4.825 2.036-9.705 2.075-13.619.01-.977.014-1.46.039-1.707l.435-.154zm-2.965 1.055c.094.476.021 4.368-.127 5.494a49.361 49.361 0 0 1-1.78 8.428c-.214.717-.41 1.319-.448 1.357-.078.097-2.732-2.5-3.604-3.508-1.51-1.744-2.692-3.486-3.564-5.191-.404-.79-.987-2.205-1.055-2.518a345.346 345.346 0 0 1 8.592-3.355c.617-.232 1.343-.473 1.986-.707zm-12.603 4.9c.047.069.163.327.271.652.62 1.685 2.013 4.165 3.215 5.754 1.318 1.744 3.043 3.605 4.477 4.825.465.387.89.756.949.814.116.117.155.097-3.004 1.299-3.66 1.395-7.652 2.79-12.225 4.262a609.84 609.84 0 0 0-3.275 1.066c-.175.058-.114-.04.389-.834 2.267-3.544 5.714-10.5 7.652-15.422.33-.853.659-1.706.717-1.9.027-.095.066-.15.103-.211l.73-.305zm-4.01 1.7c-.132.39-.973 2.151-1.842 3.853-1.88 3.663-3.933 7.267-6.684 11.646-.466.755-.91 1.453-.97 1.53-.096.136-.135.098-.446-.502-.659-1.3-1.2-2.965-1.492-4.496-.29-1.511-.232-4.146.098-5.774.15-.717.216-.987.36-1.16a225.041 225.041 0 0 1 10.976-5.098zm33.479 1.2v.813c0 4.321-.465 10.25-1.143 14.57-.116.756-.213 1.377-.232 1.397 0 0-.563-.156-1.221-.35a49.985 49.985 0 0 1-8.912-3.816c-1.88-1.027-4.61-2.714-4.533-2.791.019-.02.832-.445 1.78-.95 3.799-1.975 7.441-4.107 10.6-6.22 1.182-.794 2.963-2.071 3.35-2.42zm-48.048 5.737c.074.004.052.163-.062.851a27.507 27.507 0 0 0-.213 2.07c-.155 2.83.31 4.925 1.705 7.792.388.794.698 1.453.678 1.472-.135.117-12.962 3.875-16.992 4.979-1.201.33-2.247.62-2.325.639-.136.04-.155.021-.097-.309.446-2.848 2.617-6.568 5.64-9.707 2.014-2.093 3.622-3.314 6.373-4.883.921-.524 2.066-1.163 3.057-1.71.737-.401 1.484-.799 2.236-1.194zm30.221 5.404h.002c.02-.02.483.232 1.045.56 4.147 2.404 9.921 4.633 14.842 5.776l.445.096-.619.35c-2.576 1.433-11.045 4.96-19.705 8.195-1.26.465-2.498.93-2.73 1.027-.233.097-.448.155-.448.135 0-.02.35-.698.795-1.531 2.422-4.534 4.863-10.055 6.104-13.891.155-.368.25-.697.27-.717zm-3.08 1.006h.002c.02.02-.136.428-.33.893-1.686 4.088-3.895 8.545-6.724 13.543-.716 1.28-1.317 2.306-1.336 2.306-.02 0-.601-.35-1.3-.775-4.106-2.52-7.75-5.62-10.132-8.623l-.35-.426 1.764-.484c6.316-1.724 11.684-3.584 17.012-5.87.756-.31 1.375-.564 1.394-.564zm19.143 6.686c.02.446-.967 4.437-1.781 7.324-.678 2.422-1.26 4.32-2.327 7.672-.464 1.474-.87 2.693-.89 2.693-.02 0-.135-.018-.252-.056-5.754-1.047-10.908-2.501-15.752-4.438-1.356-.543-3.293-1.415-3.41-1.512-.038-.039 1.124-.581 2.597-1.22 8.816-3.856 17.96-8.235 21.1-10.114.368-.233.657-.35.715-.35zM28.677 96.8c.04.04-2.423 3.585-5.87 8.41-1.203 1.686-2.597 3.661-3.12 4.397a77.468 77.468 0 0 0-1.764 2.596l-.814 1.261-.871-.738c-1.027-.853-2.809-2.673-3.604-3.68-1.666-2.073-2.791-4.264-3.236-6.26-.214-.93-.214-1.394-.02-1.45a1459.308 1459.308 0 0 1 10.31-2.424 861.655 861.655 0 0 0 6.935-1.627c1.124-.271 2.035-.485 2.054-.485zm2.479.95.621.697c2.79 3.12 5.637 5.425 9.086 7.44.62.35 1.086.659 1.047.679-.135.096-11.974 4.3-17.457 6.2a462.503 462.503 0 0 1-5.639 1.956c-.019 0-.194-.117-.387-.252l-.35-.252.563-.814c1.82-2.635 4.107-5.521 9.086-11.528zm15.463 11.062c.019-.02.87.29 1.918.68 2.519.949 4.513 1.55 7.187 2.228 3.294.833 8.061 1.646 10.872 1.88.426.037.657.076.58.134-.136.077-2.985 1.028-5.077 1.686-3.333 1.047-13.504 4.05-21.797 6.433a218.736 218.736 0 0 1-2.925.834c-.194.038-.834-.138-.834-.215 0-.038.465-.638 1.027-1.297 2.79-3.333 5.561-7.054 7.867-10.58.64-.969 1.182-1.764 1.182-1.783zm-3.412.098h.002c.019.02-1.357 2.227-3.76 6.025-1.026 1.608-2.17 3.432-2.576 4.07-.388.62-.971 1.59-1.3 2.131l-.56.987-.29-.076c-.699-.195-5.601-1.919-6.9-2.442a48.226 48.226 0 0 1-4.513-2.072c-1.55-.834-3.487-2.074-3.332-2.113.038-.02 2.692-.736 5.889-1.608 8.485-2.306 13.194-3.642 16.275-4.611.562-.175 1.046-.311 1.065-.291zm24.123 5.656h.021c.077.195-3.063 8.913-4.207 11.664-.25.62-.348.776-.484.756-.33-.02-4.881-.657-7.652-1.064-4.824-.736-12.925-2.15-14.958-2.616l-.464-.097 2.886-.659c6.2-1.395 9.184-2.15 12.207-3.08a86.251 86.251 0 0 0 11.413-4.4c.6-.27 1.102-.483 1.238-.502z\"></path>\r\n                    </svg>", "Microsoft SQL Server" },
                    { 11, "<svg viewBox=\"0 0 128 128\">\r\n                        <path class=\"icon-dark\"\r\n                                fill=\"currentColor\"\r\n                                d=\"M2 63.91v62.5h125v-125H2zm100.73-5a15.56 15.56 0 017.82 4.5 20.58 20.58 0 013 4c0 .16-5.4 3.81-8.69 5.85-.12.08-.6-.44-1.13-1.23a7.09 7.09 0 00-5.87-3.53c-3.79-.26-6.23 1.73-6.21 5a4.58 4.58 0 00.54 2.34c.83 1.73 2.38 2.76 7.24 4.86 8.95 3.85 12.78 6.39 15.16 10 2.66 4 3.25 10.46 1.45 15.24-2 5.2-6.9 8.73-13.83 9.9a38.32 38.32 0 01-9.52-.1A23 23 0 0180 109.19c-1.15-1.27-3.39-4.58-3.25-4.82a9.34 9.34 0 011.15-.73l4.6-2.64 3.59-2.08.75 1.11a16.78 16.78 0 004.74 4.54c4 2.1 9.46 1.81 12.16-.62a5.43 5.43 0 00.69-6.92c-1-1.39-3-2.56-8.59-5-6.45-2.78-9.23-4.5-11.77-7.24a16.48 16.48 0 01-3.43-6.25 25 25 0 01-.22-8c1.33-6.23 6-10.58 12.82-11.87a31.66 31.66 0 019.49.26zm-29.34 5.24v5.12H57.16v46.23H45.65V69.26H29.38v-5a49.19 49.19 0 01.14-5.16c.06-.08 10-.12 22-.1h21.81z\"\r\n                    </svg>", "TypeScript" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Active", "DemoUrl", "Description", "GitUrl", "Image", "ImageAltText", "Order", "Port", "Title" },
                values: new object[,]
                {
                    { 1, true, "https://restaurants.nickbryant.dev", "A mock e-commerce site that allows users to order one or more dishes from a variety of restaurants. This project utilizes NextJS, GraphQL + Prisma, Redis cache and Stripe for payment.", "https://github.com/nitnub/restaurant", "restaurant-app.jpg", "Restaurant app landing page", 1, "3501", "Restaurant App" },
                    { 2, true, "https://auth.nickbryant.dev/api-docs", "An authentication REST project that is used by some of my other projects to authenticate users. Utilizes JWTs.", "https://github.com/nitnub/auth-server", "auth-server.jpg", "Auth server documentation", 2, "4000", "Auth REST Server" },
                    { 3, true, "https://werdle.nickbryant.dev", "A clone of the popular word game Wordle. Users can customize the word length and the number of turns allowed. In this version, guesses are not checked against the dictionary, so feel free to guess with a non-word! This project was built in React.", "https://github.com/nitnub/werdle", "werdle.png", "Werdle game board", 3, "3601", "Werdle" },
                    { 4, true, "", "This is an in-progress full stack project that will allow users to track food allergies. Integrates with USDA API resources and FODMAP data to help narrow down the source(s) of idiopathic reactions.", "https://github.com/nitnub/food-tracker", "food-app.png", "API Call", 4, "9001", "Food App" },
                    { 5, false, "https://nitnub-bad-bank-project.s3.amazonaws.com/index.htm", "\"Bad\" (non-secure) bank assignment for the introductory section of a coding camp I attended. For this project, I opted to utilizes React, React-Bootstrap styling, Formik forms, and Yup form validation.", "https://github.com/nitnub/bad-bank-react", "bad-bank.png", "Bad Bank app landing page", 5, "1100", "Bad Bank" },
                    { 100, true, "https://nickbryant.dev", "The page you are viewing right now! This ASP.NET Core MVC project consists of this \"Guest\" view as well as an \"Admin\" area for dynamically updating content.", "https://github.com/nitnub/portfolio-dotnet", "portfolio-project.jpg", "Portfolio Project Page", 999, "80", "Portfolio Page" }
                });

            migrationBuilder.InsertData(
                table: "ProjectLogos",
                columns: new[] { "Id", "LogoId", "Priority", "ProjectId" },
                values: new object[,]
                {
                    { 1, 11, 1, 1 },
                    { 2, 5, 2, 1 },
                    { 3, 3, 3, 1 },
                    { 4, 7, 4, 1 },
                    { 5, 9, 5, 1 },
                    { 6, 11, 1, 2 },
                    { 7, 4, 1, 3 },
                    { 8, 8, 2, 3 },
                    { 9, 11, 1, 4 },
                    { 10, 1, 1, 100 },
                    { 11, 2, 2, 100 },
                    { 12, 10, 3, 100 }
                });

            migrationBuilder.InsertData(
                table: "Videos",
                columns: new[] { "Id", "Active", "Description", "Order", "ProjectId", "Title", "ToolTip", "URL" },
                values: new object[,]
                {
                    { 1, true, "Architecture, Authentication, and App Diagram", 1, 1, "Overview", "Architecture, Authentication, and App Diagram", "https://youtu.be/00l_fB_QNcA" },
                    { 2, true, "Database and API", 2, 1, "Data & API", "Database and API", "https://youtu.be/NOsDenknUKc" },
                    { 3, true, "Deployment, Additional Features, Demo and Reflections", 3, 1, "Deployment", "Deployment, Additional Features, Demo and Reflections", "https://youtu.be/GImnGa9xLO4" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectLogos_LogoId",
                table: "ProjectLogos",
                column: "LogoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectLogos_ProjectId",
                table: "ProjectLogos",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Videos_ProjectId",
                table: "Videos",
                column: "ProjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Biographies");

            migrationBuilder.DropTable(
                name: "GuestActions");

            migrationBuilder.DropTable(
                name: "ProjectLogos");

            migrationBuilder.DropTable(
                name: "Videos");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Logos");

            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
