using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace RecurrenceMod.Content.Dusts
{
    internal class FlambergeDust : ModDust
    {
        public override string Texture => null;

        public override void OnSpawn(Dust dust)
        {
            int desiredTexture = 35;
            int frameX = desiredTexture * 10 % 1000;
            int frameY = desiredTexture * 10 / 1000 * 30 + Main.rand.Next(3) * 10;

            dust.frame = new Rectangle(frameX, frameY, 8, 8);
        }

        public override bool Update(Dust dust)
        {
            dust.rotation += 0.1f * (dust.dustIndex % 2 == 0 ? -1 : 1);
            dust.scale -= 0.05f;
            if(dust.scale < 0.05f)
            {
                dust.active = false;
            }

            return false;
        }
    }
}
