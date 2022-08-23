using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.Localization;

namespace RecurrenceMod.Content.Items.Armours.Waterstone
{
    [AutoloadEquip(EquipType.Head)]
    internal class WaterstoneHood : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

            ArmorIDs.Head.Sets.DrawHead[Item.headSlot] = true;
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
            player.statManaMax2 += 20;
            player.GetDamage(DamageClass.Magic) += 0.07f;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<WaterstoneShirt>() && legs.type == ModContent.ItemType<WaterstonePants>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = Language.GetTextValue("Mods.RecurrenceMod.ItemSetBonus.Waterstone");
            player.manaCost -= 0.2f;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<Bars.WaterElementBar>(8)
                .AddIngredient(ItemID.Silk, 10)
                .AddTile(TileID.Hellforge)
                .Register();
        }
    }
}
