using Microsoft.EntityFrameworkCore.Migrations;

namespace Retailmize.Infra.Data.Migrations
{
    public partial class PopulateProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Products(Name,Description,Price,Stock,Image,CategoryId)" +
            "VALUES('Organic Quinoa'," +
            "'A 16 oz bag of organic quinoa, a protein-rich, gluten-free grain perfect for salads, soups, and side dishes.'," +
            "7.25," +
            "140," +
            "'organic_quinoa.png'," +
            "1)");

            migrationBuilder.Sql("INSERT INTO Products(Name,Description,Price,Stock,Image,CategoryId)" +
            "VALUES('All-Purpose Cleaner Spray'," +
            "'A versatile cleaner for all surfaces, formulated with natural ingredients to cut through grease and grime.'," +
            "6.75," +
            "100," +
            "'all_purpose_cleaner.png'," +
            "2)");

            migrationBuilder.Sql("INSERT INTO Products(Name,Description,Price,Stock,Image,CategoryId)" +
            "VALUES('Microfiber Cleaning Cloths (Pack of 5)'," +
            "'Highly absorbent microfiber cloths, perfect for dusting and polishing surfaces without scratching.'," +
            "9.99," +
            "75," +
            "'microfiber_cloths.png'," +
            "2)");

            migrationBuilder.Sql("INSERT INTO Products(Name,Description,Price,Stock,Image,CategoryId)" +
            "VALUES('Lemon-Scented Disinfectant Wipes'," +
            "'Antibacterial wipes with a refreshing lemon scent, effective in killing 99.9% of germs.'," +
            "4.49," +
            "200," +
            "'disinfectant_wipes.png'," +
            "2)");

            migrationBuilder.Sql("INSERT INTO Products(Name,Description,Price,Stock,Image,CategoryId)" +
            "VALUES('Aloe Vera Moisturizing Gel'," +
            "'A soothing and hydrating gel made from 100% pure aloe vera, perfect for all skin types. Ideal for sunburns and dry skin.'," +
            "8.99," +
            "120," +
            "'aloe_vera_gel.png'," +
            "3)");

            migrationBuilder.Sql("INSERT INTO Products(Name,Description,Price,Stock,Image,CategoryId)" +
            "VALUES('Charcoal Whitening Toothpaste'," +
            "'A fluoride-free toothpaste infused with activated charcoal for natural teeth whitening and fresh breath.'," +
            "5.49," +
            "85," +
            "'charcoal_toothpaste.png'," +
            "3)");

            migrationBuilder.Sql("INSERT INTO Products(Name,Description,Price,Stock,Image,CategoryId)" +
            "VALUES('Lavender Essential Oil'," +
            "'A pure lavender essential oil, ideal for aromatherapy, relaxation, and soothing skin.'," +
            "12.50," +
            "200," +
            "'lavender_oil.png'," +
            "3)");

            migrationBuilder.Sql("INSERT INTO Products(Name,Description,Price,Stock,Image,CategoryId)" +
            "VALUES('Vitamin C Serum'," +
            "'An antioxidant-rich serum with 20% Vitamin C to brighten skin tone and reduce signs of aging.'," +
            "15.99," +
            "60," +
            "'vitamin_c_serum.png'," +
            "3)");

            migrationBuilder.Sql("INSERT INTO Products(Name,Description,Price,Stock,Image,CategoryId)" +
            "VALUES('Organic Cotton Pads'," +
            "'Soft, organic cotton pads for gentle facial cleansing and makeup removal. Biodegradable and eco-friendly.'," +
            "4.99," +
            "150," +
            "'cotton_pads.png'," +
            "3)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Products");
        }
    }
}
