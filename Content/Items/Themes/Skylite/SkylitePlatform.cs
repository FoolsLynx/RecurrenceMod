using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using RecurrenceMod.Content.Tiles;

namespace RecurrenceMod.Content.Items.Themes.Skylite
{
    internal class SkylitePlatform : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 200;
        }

        public override void SetDefaults()
        {
            Item.width = 8;
            Item.height = 10;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.consumable = true;
            Item.maxStack = 999;
            Item.createTile = ModContent.TileType<RecurrencePlatforms>();
            Item.placeStyle = 0;
        }

        public override void AddRecipes()
        {
            CreateRecipe(2).AddIngredient(ModContent.ItemType<SkyliteBlock>()).Register();
        }
    }
}
