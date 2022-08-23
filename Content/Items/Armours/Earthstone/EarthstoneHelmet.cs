using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.Localization;

namespace RecurrenceMod.Content.Items.Armours.Earthstone
{
    [AutoloadEquip(EquipType.Head)]
    internal class EarthstoneHelmet : ModItem
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
            player.GetDamage(DamageClass.Summon) += 0.09f;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<EarthstoneMail>() && legs.type == ModContent.ItemType<EarthstoneGreaves>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = Language.GetTextValue("Mods.RecurrenceMod.ItemSetBonus.Earthstone");

            player.GetDamage(DamageClass.Summon) += 0.17f;
            player.whipRangeMultiplier += 0.45f;
            player.GetAttackSpeed(DamageClass.Summon) += 0.40f;
            
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<Bars.EarthElementBar>(15)
                .AddTile(TileID.Hellforge)
                .Register();
        }
    }
}
