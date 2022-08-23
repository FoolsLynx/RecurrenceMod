using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using RecurrenceMod.Content.Items.Themes.Skylite;

namespace RecurrenceMod.Content.Items.Themes.Skylite.Furniture
{
    internal class SkyliteCandelabra : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.consumable = true;
            Item.maxStack = 99;
            Item.createTile = ModContent.TileType<Tiles.Furniture.RecurrenceCandelabras>();
            Item.placeStyle = 0;
            Item.value = 1500;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<SkyliteBlock>(5)
                .AddIngredient(ItemID.Torch, 3)
                .AddTile<Tiles.Skylite.SkyliteConstructor>()
                .Register();
        }
    }
}
