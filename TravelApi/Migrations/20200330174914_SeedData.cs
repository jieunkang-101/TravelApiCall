using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelApi.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Landmark",
                table: "Destinations",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Destinations",
                columns: new[] { "DestinationId", "City", "Country", "Landmark" },
                values: new object[,]
                {
                    { 1, "Paris", "France", "Louvre Museum" },
                    { 2, "Sydney", "Australia", "Opera House" },
                    { 3, "Portland", "USA", "Pittock Mansion" },
                    { 4, "Bangkok", "Thailand", "Temple of the Emerald Buddha" },
                    { 5, "Seoul", "Korea", "Gyeongbokgung Palace" }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "ReviewId", "Description", "DestinationId", "Rating", "UserName" },
                values: new object[,]
                {
                    { 1, "Amazing architecture! Plan to spend a whole day here if you are really into art. There are so many halls to see. There is also a line to see the Mona Lisa and you have to be quick to take your picture with the painting.", 1, 5.0, "user1" },
                    { 2, "I loved this place. If your are an art lover, this place is a paradise for you. One day is not enough to visit the entire museum. But still you can visit the main attractions including the famous Mona Lisa.", 1, 4.7000000000000002, "user2" },
                    { 3, "Wow! Sydney Opera House is absolutely FABULOUS! What an elegant, gorgeous, impressive display of truly artistic architecture.  The beauty of this site is enhanced with each different view. ", 2, 5.0, "user2" },
                    { 4, "This was a great way to get to know the city of Portland! It was fascinating to learn about one of the first wealthy families to live there. The mansion is really cool and the hike through forest park is a fun way to get there! ", 3, 4.5999999999999996, "user1" },
                    { 5, "It is one of the best places on South Korea to see the old architecture of a palace. Even traditional events are demonstrate times to time. The most interesting thing in this place is that you can take photographs with soldiers with traditional costumes.", 5, 4.7999999999999998, "user3" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Destinations",
                keyColumn: "DestinationId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Destinations",
                keyColumn: "DestinationId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Destinations",
                keyColumn: "DestinationId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Destinations",
                keyColumn: "DestinationId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Destinations",
                keyColumn: "DestinationId",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "Landmark",
                table: "Destinations");
        }
    }
}
