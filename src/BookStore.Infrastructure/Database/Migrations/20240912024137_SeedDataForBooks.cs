using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookStore.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataForBooks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "books");

            migrationBuilder.CreateTable(
                name: "books",
                schema: "books",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    author = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    price = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_books", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                schema: "books",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    customer_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    shipping_address_address_line = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    shipping_address_city = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    shipping_address_district = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    shipping_address_town = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_orders", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "outbox_message_consumers",
                schema: "books",
                columns: table => new
                {
                    outbox_message_id = table.Column<Guid>(type: "uuid", nullable: false),
                    handler_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_outbox_message_consumers", x => new { x.outbox_message_id, x.handler_name });
                });

            migrationBuilder.CreateTable(
                name: "outbox_messages",
                schema: "books",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    type = table.Column<string>(type: "text", nullable: false),
                    content = table.Column<string>(type: "jsonb", maxLength: 2000, nullable: false),
                    occurred_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    processed_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    error = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_outbox_messages", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "order_items",
                schema: "books",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    book_id = table.Column<Guid>(type: "uuid", nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    unit_price = table.Column<decimal>(type: "numeric", nullable: false),
                    description = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    order_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_order_items", x => x.id);
                    table.ForeignKey(
                        name: "fk_order_items_orders_order_id",
                        column: x => x.order_id,
                        principalSchema: "books",
                        principalTable: "orders",
                        principalColumn: "id");
                });

            migrationBuilder.InsertData(
                schema: "books",
                table: "books",
                columns: new[] { "id", "author", "description", "price", "quantity", "title" },
                values: new object[,]
                {
                    { new Guid("04294032-fc37-4496-9765-7f0506af3ba3"), "Ada Wolff", "Quas vel placeat consequatur eveniet sed.", 277961.158573621940000m, 47, "Walker - Jenkins" },
                    { new Guid("05643bc1-d4c8-41dc-86de-cc883163244d"), "Ada Wolff", "Quaerat quia itaque dolores iste aut.", 313926.253576961540000m, 85, "Kovacek Group" },
                    { new Guid("09045c0b-7e66-4c8a-a34c-f22b00d35fb3"), "Ada Wolff", "Sequi fugit neque eligendi quaerat ea impedit numquam.", 165849.845284121940000m, 96, "Hettinger and Sons" },
                    { new Guid("09dbf58d-6571-4ab8-8742-bcd5e5b640e8"), "Ada Wolff", "Autem sunt ut porro ullam velit magni provident deleniti enim.", 167357.02072762350000m, 10, "Willms - Dickinson" },
                    { new Guid("0ba88379-5978-4781-b606-29c8e9b82f66"), "Ada Wolff", "Fugit et enim iusto unde.", 150412.06732063630000m, 75, "Hayes and Sons" },
                    { new Guid("0bedccf1-83d5-43cc-9e0f-dc38c92ec598"), "Ada Wolff", "Perferendis a impedit suscipit rerum eum adipisci sunt est.", 361567.809807392640000m, 21, "Nader and Sons" },
                    { new Guid("12f460ff-6108-44ea-a07f-76154f1cafcb"), "Ada Wolff", "Aut itaque temporibus error distinctio.", 191176.727425578920000m, 88, "Leffler, Lubowitz and Gutkowski" },
                    { new Guid("13c872a3-ce46-45b6-890e-941e494bd63a"), "Ada Wolff", "Facilis culpa ad voluptates aut dolores recusandae repellat.", 52513.1593811928850000m, 46, "Spencer, Russel and Johnston" },
                    { new Guid("15304f31-e7d4-4320-9be9-67c30172731b"), "Ada Wolff", "Id eos aut.", 316202.149274137760000m, 29, "Kihn Inc" },
                    { new Guid("16ad399d-01c9-488d-9f19-b4ea77d02ee0"), "Ada Wolff", "Quasi et exercitationem temporibus est dolore aliquid ipsam deleniti voluptatem.", 491263.875154548080000m, 9, "Rutherford - Kuhn" },
                    { new Guid("17a3000a-56dc-4978-8b2d-680c64a7a71b"), "Ada Wolff", "At expedita optio veniam labore aut voluptatem et et.", 214116.124246382810000m, 65, "Pagac, Wiza and Wisozk" },
                    { new Guid("186d9987-6c2d-4e06-9ced-b1857c5879ca"), "Ada Wolff", "Sed voluptatem quos facilis veniam non voluptas eum.", 109748.115463217060000m, 17, "Oberbrunner - Kuhlman" },
                    { new Guid("1e4eae44-c9f9-4d81-b91d-0eb12d38f633"), "Ada Wolff", "Veritatis voluptas voluptatem.", 118186.81043001650000m, 65, "Hyatt, Walsh and Ortiz" },
                    { new Guid("1fcbb275-ae19-42d9-b0ca-0a11d0915ce9"), "Ada Wolff", "Ex quo dolore harum dolorem.", 177251.056328621090000m, 38, "Lowe, Block and Runte" },
                    { new Guid("22368f3c-852f-45d4-bbbc-f598f6323dfd"), "Ada Wolff", "Molestiae enim expedita consequatur ipsum quaerat.", 448621.092023483390000m, 54, "Dickinson - Kovacek" },
                    { new Guid("2246365c-45ff-4ffe-a164-2591f5db95e7"), "Ada Wolff", "Molestiae enim et neque dolores quia quidem a.", 17324.5099656659280000m, 97, "Wyman - Murray" },
                    { new Guid("23924fd3-0cb9-4138-b60f-cd51838248fe"), "Ada Wolff", "Iure provident dolores ullam modi qui sapiente.", 96355.11786745130000m, 40, "Howe LLC" },
                    { new Guid("2399fc82-8614-4406-812c-b1c740e64689"), "Ada Wolff", "Eum error soluta dolores.", 362760.076639698630000m, 57, "Conn - Stehr" },
                    { new Guid("298ff798-b18b-4d2f-8a68-be69463b9810"), "Ada Wolff", "Nulla dicta ad hic aut et accusantium aut.", 23042.1735633171150000m, 49, "Klein Group" },
                    { new Guid("2ec53d41-d2f5-4d2e-ba68-dbcb171a6369"), "Ada Wolff", "Est voluptas eum quibusdam sed eum mollitia odio voluptatibus.", 63696.433894266590000m, 15, "Franecki - Collier" },
                    { new Guid("2fcb66dd-cf23-46ba-aeef-783682d40569"), "Ada Wolff", "Quod ut in.", 294611.674540320960000m, 28, "Aufderhar and Sons" },
                    { new Guid("3121c1d9-d706-4cfb-a0fc-cb51ed8221a1"), "Ada Wolff", "Modi velit voluptates iusto quidem autem laborum nemo cum.", 274694.12509057910000m, 29, "Bode, Runte and Frami" },
                    { new Guid("3ba79888-9359-43dc-a35d-58189cd59798"), "Ada Wolff", "Omnis similique dolorem pariatur doloribus.", 420321.034741900940000m, 82, "Daniel - Tillman" },
                    { new Guid("3d1f7507-0636-4e79-a0df-e302db44d726"), "Ada Wolff", "Necessitatibus rem minus reprehenderit voluptas porro sunt in.", 489809.877154731760000m, 7, "Adams, Franecki and Howell" },
                    { new Guid("3ddeac80-9a58-4947-ab61-4a831f16ec90"), "Ada Wolff", "Voluptatem qui distinctio excepturi similique vero cum perferendis ut.", 81387.835514627170000m, 20, "Walsh and Sons" },
                    { new Guid("3de53ad0-490a-4a8d-b55c-2d6a54cb4669"), "Ada Wolff", "Distinctio asperiores voluptate id ea.", 454632.964585842060000m, 8, "Heidenreich - Yundt" },
                    { new Guid("3e5e7495-98fd-4cee-94c0-6661114ffcf0"), "Ada Wolff", "Odit perspiciatis ut.", 97810.202858201180000m, 4, "Gutmann - Huel" },
                    { new Guid("402498e7-1261-4038-b93f-fe6e988066a0"), "Ada Wolff", "Iste velit qui corrupti et assumenda dolore reiciendis eligendi consequatur.", 378463.794009723440000m, 57, "Reichert - Anderson" },
                    { new Guid("413be594-9727-44b5-8b54-4066cab6f64f"), "Ada Wolff", "Sit occaecati odio saepe dignissimos qui.", 49907.2725390503920000m, 64, "Abbott Inc" },
                    { new Guid("41a8f881-6ab6-4d8f-bf4a-dfe287cfe506"), "Ada Wolff", "Quod id cumque sunt veritatis iure dolores.", 291906.559471130440000m, 20, "Dibbert, Ratke and Breitenberg" },
                    { new Guid("442baf5f-8de7-43a3-9157-9f382122128e"), "Ada Wolff", "Facere et odio eius inventore.", 269572.392812313140000m, 18, "Heller - Mohr" },
                    { new Guid("45ee62df-729e-436d-af10-a5a6307fdb11"), "Ada Wolff", "Dicta et quisquam exercitationem quae dolor voluptatem est illum.", 220409.570898782640000m, 43, "Weber - Lueilwitz" },
                    { new Guid("534f1562-cc4d-463c-bed8-68971c2dbf52"), "Ada Wolff", "Ullam voluptas officia sed magni sunt.", 458515.326451720220000m, 2, "Huels Group" },
                    { new Guid("54df3fa3-8487-4ead-b792-481cc0b9ef5b"), "Ada Wolff", "Repellendus ut iusto totam.", 160314.457589416260000m, 21, "Parisian, Hegmann and Hahn" },
                    { new Guid("56600a9f-ae1f-4a28-b538-6b723f826e8e"), "Ada Wolff", "Quod ea reprehenderit porro id et reiciendis esse vel aut.", 189916.233294139790000m, 41, "Spinka, Hermann and Nolan" },
                    { new Guid("5b608510-fce5-4898-a671-8fcb29a9fa23"), "Ada Wolff", "Et impedit saepe at voluptatibus iusto et ipsa veritatis beatae.", 255634.008604724180000m, 18, "Schaefer - Stracke" },
                    { new Guid("5b771cb5-f827-49a2-8a15-c88740d3c6ce"), "Ada Wolff", "Nesciunt sint ea magnam nisi.", 480108.805522909910000m, 7, "Wiza - Hermiston" },
                    { new Guid("5d02b338-6b26-4d1c-9979-6e7d3273d180"), "Ada Wolff", "Quo eveniet dolorem at autem dolorem natus nam similique quod.", 294902.919568130710000m, 78, "Ledner LLC" },
                    { new Guid("5e3af6cd-d423-4996-bc44-1e98bd22493e"), "Ada Wolff", "Temporibus quasi est laborum sint praesentium cum aut ullam.", 487041.709256442330000m, 6, "Kunze Group" },
                    { new Guid("5f6c5620-9b88-444e-9828-e69a08e49f95"), "Ada Wolff", "Sunt et autem aut.", 147827.33430711840000m, 89, "Lindgren - Ledner" },
                    { new Guid("5ff6d6fe-6560-411c-9e67-667f97cdfed1"), "Ada Wolff", "Dolorem dolore et qui quibusdam quaerat quae.", 234142.982844102350000m, 37, "Shanahan and Sons" },
                    { new Guid("62df0e3d-0faf-4f02-a9c1-09194e932e8b"), "Ada Wolff", "Velit impedit ducimus fuga ipsum voluptas et sunt provident.", 496713.944360007840000m, 11, "Larkin - Ondricka" },
                    { new Guid("648d6519-50a3-486d-b622-91c091fff7c7"), "Ada Wolff", "Soluta esse nulla eum nostrum eum ipsam.", 305202.072864367690000m, 61, "Lind - Emard" },
                    { new Guid("6908533d-2930-4615-b0fa-156b37fa4fa4"), "Ada Wolff", "Architecto dolores repudiandae animi quia ut et totam dolorum.", 163519.65010055520000m, 55, "Robel, Rolfson and Pfannerstill" },
                    { new Guid("6a11803f-f576-4aa2-9a40-3bf0e1cfdd51"), "Ada Wolff", "Aliquam eaque quam.", 190021.227223901350000m, 92, "Kub - Effertz" },
                    { new Guid("6f269221-0266-4a5d-abdf-042e8e1f59b8"), "Ada Wolff", "Qui natus est consequatur quaerat molestiae sunt non est ab.", 278685.57211301050000m, 1, "Lakin, Waelchi and Waelchi" },
                    { new Guid("708d0815-de1b-41be-a787-d3753813e71b"), "Ada Wolff", "Nihil minus qui et eos consequuntur.", 261350.816021690420000m, 90, "Dibbert, Ruecker and Glover" },
                    { new Guid("728f67c6-db9d-4e3f-a788-17e76ceab0e6"), "Ada Wolff", "Et similique ut sunt.", 482581.427422184640000m, 6, "Dickens and Sons" },
                    { new Guid("7ad860be-2f30-4296-90eb-210ec204256e"), "Ada Wolff", "Officiis neque odio veritatis vel perspiciatis.", 404217.986041923260000m, 82, "Barrows - Bashirian" },
                    { new Guid("7b1bc506-b809-461a-9d37-af77402f019f"), "Ada Wolff", "Ut deleniti tempora officiis est molestiae.", 169601.50703325640000m, 73, "Wilderman Group" },
                    { new Guid("7f3343f9-70ef-4efd-8f3b-22f78fdec133"), "Ada Wolff", "Repudiandae incidunt est praesentium reiciendis autem mollitia rem eum.", 395511.066957433340000m, 52, "Jacobson - Ritchie" },
                    { new Guid("81be8f21-3c6f-43dd-a347-84ba8414d00f"), "Ada Wolff", "Labore expedita vel sunt aliquam qui sunt.", 17003.0384679475570000m, 86, "Boehm - Maggio" },
                    { new Guid("85446420-71da-487b-8dd5-2dd6dc9bd424"), "Ada Wolff", "Et facere nam et eligendi est consequatur pariatur ex.", 448824.934827247710000m, 4, "Emard LLC" },
                    { new Guid("87c5fb04-4ca9-4dcd-93c5-a4e930a99216"), "Ada Wolff", "Nulla commodi ut et dolorem aut.", 71356.176777882490000m, 25, "Kilback, Lubowitz and Moen" },
                    { new Guid("89931651-84e9-49fa-95ae-ce6da173bf08"), "Ada Wolff", "Nemo maxime rerum aperiam doloremque.", 138441.796654452190000m, 98, "Schneider - Cremin" },
                    { new Guid("8df9d56a-1e41-4c17-a4ea-b72ce761c4d0"), "Ada Wolff", "Repellat accusamus sunt ducimus quam sed voluptatem.", 129923.246928640680000m, 57, "Daugherty, Sanford and Boehm" },
                    { new Guid("9444eb2b-2521-4848-9204-8a8c02257f0d"), "Ada Wolff", "Aut eligendi occaecati quod possimus.", 148715.182450982620000m, 78, "Gislason, Nikolaus and Crooks" },
                    { new Guid("99187feb-1c17-48a9-8219-c63dffa0d48f"), "Ada Wolff", "Laboriosam eum eligendi tempore eum id recusandae.", 324835.320882912970000m, 9, "Considine LLC" },
                    { new Guid("9a67d25f-f9e6-4e34-a801-797f5175b164"), "Ada Wolff", "Debitis ut quos beatae officia modi omnis.", 358250.494325776980000m, 75, "Botsford LLC" },
                    { new Guid("9f21fe4c-33b1-4e9f-8186-14ab8a16c82b"), "Ada Wolff", "Harum quia in.", 69832.052212795940000m, 6, "Beatty - Rau" },
                    { new Guid("a23b81df-d3d4-417f-8cc3-dcf33da815e5"), "Ada Wolff", "Quibusdam voluptatem praesentium quia quia et repudiandae rerum nisi eum.", 454655.057894430320000m, 38, "Crona - Skiles" },
                    { new Guid("a4146eb7-ba21-4cb3-bb66-00db2136cce9"), "Ada Wolff", "Veritatis architecto ducimus excepturi molestias.", 180214.333148968640000m, 21, "Zulauf - Bogisich" },
                    { new Guid("a4356be6-75d8-4ae6-aa76-15f0003898e9"), "Ada Wolff", "Doloremque sed aperiam.", 216395.222447396360000m, 98, "Kuphal Group" },
                    { new Guid("a600982e-dda0-48c8-ad46-f76307ed1a0a"), "Ada Wolff", "Minima doloremque voluptas nam praesentium in beatae ab voluptatem.", 142674.948666946840000m, 47, "Howell, Raynor and King" },
                    { new Guid("ab6791c4-091d-4ae5-8280-0c05268ae627"), "Ada Wolff", "Culpa voluptatem reiciendis libero nisi rerum rerum molestiae inventore nostrum.", 279088.93361599760000m, 75, "Bins, Trantow and Ziemann" },
                    { new Guid("aee58f74-cad1-4519-8118-a67643614a64"), "Ada Wolff", "Autem sit praesentium et.", 108069.701596165110000m, 19, "Langworth - Larkin" },
                    { new Guid("b2c29a0f-742b-48fc-8138-5b1861831722"), "Ada Wolff", "Eum ducimus debitis est non placeat.", 155512.68845478610000m, 27, "Yundt - Wolf" },
                    { new Guid("b466825c-0ce3-403a-95eb-6f55870b86ae"), "Ada Wolff", "Itaque tempore similique ipsam magni dolorum deserunt repellat.", 227285.59016431820000m, 78, "Greenholt - Jenkins" },
                    { new Guid("ba7f576a-6d2d-4b38-b0a7-82d47f65d97e"), "Ada Wolff", "Eos rerum quas reprehenderit.", 425425.517337855780000m, 75, "Stroman, Tremblay and Hane" },
                    { new Guid("bce4d60a-6c1d-4a63-997a-369662da3d32"), "Ada Wolff", "Tempora nostrum totam architecto corporis.", 224539.574449453750000m, 3, "Murazik and Sons" },
                    { new Guid("c30f7cbb-c21f-4c79-8621-ba8d6e0e7564"), "Ada Wolff", "Consequatur natus et sint.", 38531.3753871328070000m, 35, "Wiegand, Emard and Osinski" },
                    { new Guid("c4c3b5e1-537a-4811-b777-6dc62eab3f38"), "Ada Wolff", "Facere voluptas ut quaerat et.", 249047.085268376420000m, 97, "Lesch, Hickle and Beier" },
                    { new Guid("c5126b75-790c-4f9d-89de-c624d1f58bdb"), "Ada Wolff", "Et quas et.", 167673.597666825240000m, 17, "Durgan - Stokes" },
                    { new Guid("c57b2738-32dc-4a69-819d-adaa1c90843c"), "Ada Wolff", "Possimus laudantium possimus optio in quis vitae totam et provident.", 364948.677320956460000m, 79, "Swaniawski LLC" },
                    { new Guid("c7b1e24f-00b9-4f36-80e3-6153deb37aae"), "Ada Wolff", "Commodi harum autem nostrum ut aut in.", 390486.87949016780000m, 76, "Crona, Mayer and Predovic" },
                    { new Guid("c9052ba3-ea24-489a-948e-36a6f7107d61"), "Ada Wolff", "Eum omnis debitis iusto veniam sit.", 298910.40159248050000m, 17, "Becker, Paucek and Luettgen" },
                    { new Guid("d0337f64-6b5f-4441-85a3-8b66d7af6081"), "Ada Wolff", "Reprehenderit quos earum explicabo qui quisquam ab.", 201782.840563912010000m, 97, "Goldner, Kihn and Lesch" },
                    { new Guid("d3299196-e82f-4783-8052-6d1824741696"), "Ada Wolff", "Odit laudantium aspernatur quibusdam et dolorum voluptates dolores amet.", 355193.111892211660000m, 82, "Dooley - Rempel" },
                    { new Guid("d6730603-d876-4e61-99d8-63a7a54d4f61"), "Ada Wolff", "Repudiandae est ut itaque atque corporis nulla quia quisquam.", 63524.470304850090000m, 2, "McClure - Mann" },
                    { new Guid("e08729b9-b7cb-4829-8aa1-a3d5b0b5101b"), "Ada Wolff", "Et rem ut quod ad.", 433937.269408614920000m, 22, "Mohr, Walter and O'Connell" },
                    { new Guid("e12d8e28-7740-44c5-9d01-21169a09b119"), "Ada Wolff", "Placeat laudantium rerum ullam.", 326527.408753681580000m, 51, "Lubowitz LLC" },
                    { new Guid("e25e9afb-d56f-4f7a-a811-ae42bb6868c9"), "Ada Wolff", "Est aperiam perferendis facere animi et asperiores delectus.", 108380.725888948510000m, 50, "Muller, Cremin and Mohr" },
                    { new Guid("e47a4328-f4af-485a-a839-3c5ec6206e94"), "Ada Wolff", "Nulla nulla sunt possimus officiis aut et veniam non.", 414534.646772227440000m, 92, "Lesch LLC" },
                    { new Guid("e4953520-54c4-4939-a39c-ee80b1d79eea"), "Ada Wolff", "Ut a suscipit eos labore omnis delectus magni.", 27769.1696938423850000m, 68, "Denesik - Buckridge" },
                    { new Guid("e5a7bec4-7dda-47f1-80bc-9cbc467dbbb2"), "Ada Wolff", "Rerum ut rerum autem dolore eum ut sed.", 20588.2311066940450000m, 56, "Kris, Mueller and D'Amore" },
                    { new Guid("e6ef2c8b-237f-403a-8855-9568d4973d69"), "Ada Wolff", "Quibusdam enim aperiam ut rerum amet.", 495444.020613707330000m, 36, "Hansen Inc" },
                    { new Guid("ea39d689-927b-4b9c-9cbf-8326e858cb78"), "Ada Wolff", "Ducimus rem exercitationem eaque.", 252560.942256966340000m, 54, "Lubowitz, Roberts and Streich" },
                    { new Guid("ef348e8f-692b-4255-8bcc-ea813a7b776c"), "Ada Wolff", "Iure accusamus perferendis dolor porro assumenda enim.", 396954.938815575690000m, 58, "Blick LLC" },
                    { new Guid("f040af7b-5773-4bcc-9805-fe168eb61d21"), "Ada Wolff", "Repellat voluptate eveniet doloribus voluptatum consequuntur vel molestias sapiente.", 304117.416945773050000m, 24, "Bernhard - Schaden" },
                    { new Guid("f13fe049-e013-44ae-a8fd-6c3cc5abd0a1"), "Ada Wolff", "Voluptas consequatur iste voluptas est ipsum ut aut deleniti et.", 449255.564420609510000m, 67, "Gusikowski, Zulauf and Monahan" },
                    { new Guid("f1a2e327-84c0-4dc0-9e8d-811d91a06dc6"), "Ada Wolff", "Nulla ipsa placeat est incidunt libero esse sunt.", 28476.3776278421480000m, 59, "Bernier, Hauck and Stracke" },
                    { new Guid("f3db1fb7-e535-40ba-851e-b670b290fd1b"), "Ada Wolff", "Nulla accusantium quaerat eos suscipit sit ea nam aliquid nihil.", 32111.2468335607590000m, 70, "Parker, Littel and Beier" },
                    { new Guid("f54633e6-99c9-4176-ac9b-bb861c429f95"), "Ada Wolff", "Nihil consequatur quia soluta est quas enim tenetur vel.", 93574.713479738810000m, 84, "Hackett - Corkery" },
                    { new Guid("f6656669-f9ad-4fc2-9787-3f98f63331a0"), "Ada Wolff", "Minima veritatis quo sit et aut officiis.", 438697.11145872520000m, 90, "Champlin - Grimes" },
                    { new Guid("f72bef9d-6720-4895-8e93-195c659a397e"), "Ada Wolff", "Consequatur sint dolorum quae ex perspiciatis consequatur expedita veniam.", 367495.902439792760000m, 68, "Hilpert Group" },
                    { new Guid("f815306f-c714-4a2a-9401-95f5530a02fd"), "Ada Wolff", "Reiciendis autem cum doloremque aut inventore.", 170654.753207806130000m, 18, "Carter Inc" },
                    { new Guid("fd65ec81-f416-47b3-8d2f-b31cea898b86"), "Ada Wolff", "Eos illum est natus ullam ut saepe beatae aspernatur.", 441222.055004274940000m, 69, "Wiza - Jacobson" },
                    { new Guid("fe0d0c51-b7f4-4c3e-82b4-058c9f75339f"), "Ada Wolff", "Error illum sunt voluptas at facilis reiciendis.", 293702.212661006090000m, 22, "Kerluke and Sons" },
                    { new Guid("ff51cd0a-b3da-4584-97b9-aeca330f3eec"), "Ada Wolff", "Porro voluptatem nulla nam aliquid eaque doloribus.", 47448.0453999179290000m, 39, "Hamill, Wisozk and DuBuque" },
                    { new Guid("ff67fe61-2459-4485-ae2f-c4442292333f"), "Ada Wolff", "Quia sapiente incidunt pariatur voluptatem.", 367884.984912897470000m, 45, "Lockman Group" }
                });

            migrationBuilder.CreateIndex(
                name: "ix_order_items_order_id",
                schema: "books",
                table: "order_items",
                column: "order_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "books",
                schema: "books");

            migrationBuilder.DropTable(
                name: "order_items",
                schema: "books");

            migrationBuilder.DropTable(
                name: "outbox_message_consumers",
                schema: "books");

            migrationBuilder.DropTable(
                name: "outbox_messages",
                schema: "books");

            migrationBuilder.DropTable(
                name: "orders",
                schema: "books");
        }
    }
}
