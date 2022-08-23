using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.Localization;

namespace RecurrenceMod.Content.Items.Armours.Earthstone
{
    [AutoloadEquip(EquipType.Legs)]
    internal class EarthstoneGreaves : ModItem
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

            Item.defense = 5;
        }

        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Summon) += 0.09f;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<Bars.EarthElementBar>(20)
                .AddTile(TileID.Hellforge)
                .Register();
        }
    }
}
