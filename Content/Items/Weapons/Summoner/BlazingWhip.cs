using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using RecurrenceMod.Content.Dusts;

namespace RecurrenceMod.Content.Items.Weapons.Summoner
{
    internal class BlazingWhip : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
        }

        public override void SetDefaults()
        {
            Item.DefaultToWhip(ModContent.ProjectileType<Projectiles.Weapons.Summoner.BlazingWhip>(), 30, 2, 7);
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.NextBool(3))
            {
                Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, ModContent.DustType<FlambergeDust>());
            }
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            if (Main.rand.NextBool(10))
            {
                int time = 300;
                if (Main.expertMode) time = 180;
                if (Main.masterMode) time = 60;

                target.AddBuff(BuffID.OnFire, time);
            }
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<Bars.FireElementBar>(15)
                .AddIngredient(ItemID.MeteoriteBar, 10)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}
