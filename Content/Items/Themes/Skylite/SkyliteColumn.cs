using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace RecurrenceMod.Content.Items.Themes.Skylite
{
    internal class SkyliteColumn : ModItem
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
            Item.createTile = ModContent.TileType<Tiles.Skylite.SkyliteColumn>();
        }

        public override void AddRecipes()
        {
            CreateRecipe(2).AddIngredient(ModContent.ItemType<SkyliteBlock>()).AddTile(TileID.Sawmill).Register();
        }
    }
}
