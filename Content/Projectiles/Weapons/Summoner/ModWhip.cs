using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace RecurrenceMod.Content.Projectiles.Weapons.Summoner
{
    internal abstract class ModWhip : ModProjectile
    {
		public virtual void SafeSetStaticDefaults() { }

        public sealed override void SetStaticDefaults()
        {
			ProjectileID.Sets.IsAWhip[Type] = true;
			SafeSetStaticDefaults();
        }

		public virtual void SafeSetDefaults() { }

        public sealed override void SetDefaults()
        {
			Projectile.DefaultToWhip();
			SafeSetDefaults();
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			Main.player[Projectile.owner].MinionAttackTargetNPC = target.whoAmI;
		}

		public virtual void DrawLine(List<Vector2> list)
		{
			Texture2D texture = TextureAssets.FishingLine.Value;
			Rectangle frame = texture.Frame();
			Vector2 origin = new Vector2(frame.Width / 2, 2);

			Vector2 pos = list[0];
			for (int i = 0; i < list.Count - 1; i++)
			{
				Vector2 element = list[i];
				Vector2 diff = list[i + 1] - element;

				float rotation = diff.ToRotation() - MathHelper.PiOver2;
				Color color = Lighting.GetColor(element.ToTileCoordinates(), Color.White);
				Vector2 scale = new Vector2(1, (diff.Length() + 2) / frame.Height);

				Main.EntitySpriteDraw(texture, pos - Main.screenPosition, frame, color, rotation, origin, scale, SpriteEffects.None, 0);

				pos += diff;
			}
		}

		public virtual void CustomPreDraw(List<Vector2> list)
        {
			Main.DrawWhip_WhipBland(Projectile, list);
        }

		public override bool PreDraw(ref Color lightColor)
		{
			List<Vector2> list = new List<Vector2>();
			Projectile.FillWhipControlPoints(Projectile, list);


			CustomPreDraw(list);

			return false;
		}
	}
}
