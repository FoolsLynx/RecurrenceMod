using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace RecurrenceMod.Content.Items.Armours.Waterstone
{
    [AutoloadEquip(EquipType.Legs)]
    internal class WaterstonePants : ModItem
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

            Item.defense = 6;
        }

        public override void UpdateEquip(Player player)
        {
            player.statManaMax2 += 20;
            player.GetCritChance(DamageClass.Magic) += 0.07f;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<Bars.WaterElementBar>(10)
                .AddIngredient(ItemID.Silk, 10)
                .AddTile(TileID.Hellforge)
                .Register();
        }
    }
}
