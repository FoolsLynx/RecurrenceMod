using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.Localization;

namespace RecurrenceMod.Content.Items.Armours.Earthstone
{
    [AutoloadEquip(EquipType.Body)]
    internal class EarthstoneMail : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;

            Item.value = 1000;
            Item.rare = ItemRarityID.Blue;

            Item.defense = 7;
        }

        public override void UpdateEquip(Player player)
        {
            player.maxMinions += 2;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<Bars.EarthElementBar>(25)
                .AddTile(TileID.Hellforge)
                .Register();
        }
    }
}
