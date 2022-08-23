using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace RecurrenceMod.Content.Items.Bars
{
    internal class WaterElementBar : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 25;
        }

        public override void SetDefaults()
        {
            Item.width = 12;
            Item.height = 12;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.consumable = true;
            Item.maxStack = 99;
            Item.createTile = ModContent.TileType<Tiles.RecurrenceBars>();
            Item.placeStyle = 2;

        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<Ores.WaterElementOre>(4)
                .AddTile(TileID.Furnaces)
                .Register();
        }
    }
}
