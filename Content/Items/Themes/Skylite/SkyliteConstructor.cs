using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace RecurrenceMod.Content.Items.Themes.Skylite
{
    internal class SkyliteConstructor : ModItem
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
            Item.maxStack = 99;
            Item.createTile = ModContent.TileType<Tiles.Skylite.SkyliteConstructor>();
            Item.placeStyle = 0;
            Item.value = 100000;
        }
    }
}
