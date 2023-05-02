using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatRealTime.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AjusteModelagem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_AspNetUsers_Userid",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "Text",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Messages");

            migrationBuilder.RenameColumn(
                name: "dateTime",
                table: "Messages",
                newName: "Timestamp");

            migrationBuilder.RenameColumn(
                name: "Userid",
                table: "Messages",
                newName: "FromUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_Userid",
                table: "Messages",
                newName: "IX_Messages_FromUserId");

            migrationBuilder.RenameColumn(
                name: "Discriminator",
                table: "AspNetUsers",
                newName: "FullName");

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Messages",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ToRoomId",
                table: "Messages",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ToUserId",
                table: "Messages",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Avatar",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AdminId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_AspNetUsers_AdminId",
                        column: x => x.AdminId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ToRoomId",
                table: "Messages",
                column: "ToRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ToUserId",
                table: "Messages",
                column: "ToUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_AdminId",
                table: "Rooms",
                column: "AdminId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_AspNetUsers_FromUserId",
                table: "Messages",
                column: "FromUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_AspNetUsers_ToUserId",
                table: "Messages",
                column: "ToUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Rooms_ToRoomId",
                table: "Messages",
                column: "ToRoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_AspNetUsers_FromUserId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_AspNetUsers_ToUserId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Rooms_ToRoomId",
                table: "Messages");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Messages_ToRoomId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_ToUserId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "Content",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "ToRoomId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "ToUserId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "Avatar",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "Timestamp",
                table: "Messages",
                newName: "dateTime");

            migrationBuilder.RenameColumn(
                name: "FromUserId",
                table: "Messages",
                newName: "Userid");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_FromUserId",
                table: "Messages",
                newName: "IX_Messages_Userid");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "AspNetUsers",
                newName: "Discriminator");

            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_AspNetUsers_Userid",
                table: "Messages",
                column: "Userid",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
