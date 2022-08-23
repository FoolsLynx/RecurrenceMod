using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace RecurrenceMod.Content.Items.Themes.Skylite
{
    internal class SkyliteBlock : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
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
            Item.maxStack = 999;
            Item.createTile = ModContent.TileType<Tiles.Skylite.SkyliteBlock>();

        }

        public override void AddRecipes()
        {
            CreateRecipe(25).AddIngredient(ItemID.StoneBlock, 25).AddIngredient(ItemID.Cloud).AddTile(TileID.WorkBenches).Register();
            CreateRecipe(4).AddIngredient(ModContent.ItemType<SkyliteWall>()).AddTile(TileID.WorkBenches).Register();
            CreateRecipe().AddIngredient(ModContent.ItemType<SkylitePlatform>()).Register();
        }
    }
}
