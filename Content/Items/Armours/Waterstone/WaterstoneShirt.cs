using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace RecurrenceMod.Content.Items.Armours.Waterstone
{
    [AutoloadEquip(EquipType.Body)]
    internal class WaterstoneShirt : ModItem
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
            player.statManaMax2 += 40;
            player.GetCritChance(DamageClass.Magic) += 0.07f;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<Bars.WaterElementBar>(14)
                .AddIngredient(ItemID.Silk, 10)
                .AddTile(TileID.Hellforge)
                .Register();
        }
    }
}
