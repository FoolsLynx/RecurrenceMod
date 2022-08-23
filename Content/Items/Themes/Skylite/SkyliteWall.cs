using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace RecurrenceMod.Content.Items.Themes.Skylite
{
    internal class SkyliteWall : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 400;
        }

        public override void SetDefaults()
        {
            Item.width = 12;
            Item.height = 12;
            Item.useAnimation = 15;
            Item.useTime = 7;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.consumable = true;
            Item.maxStack = 999;
            Item.createWall = ModContent.WallType<Walls.SkyliteWall>();
        }

        public override void AddRecipes()
        {
            CreateRecipe(4).AddIngredient(ModContent.ItemType<SkyliteBlock>(), 4).AddTile(TileID.WorkBenches).Register();
        }
    }
}
