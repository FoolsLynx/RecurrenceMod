using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria.ModLoader;

namespace RecurrenceMod.Content.Biomes.Water
{
    internal class SkyPalaceWaterStyle : ModWaterStyle
    {
        public override int ChooseWaterfallStyle()
        {
            return ModContent.Find<ModWaterfallStyle>("RecurrenceMod/SkyPalaceWaterfallStyle").Slot;
        }

        public override int GetDropletGore()
        {
            return GoreID.AmbientAirborneCloud1;
        }

        public override int GetSplashDust()
        {
            return DustID.Water;
        }

        public override void LightColorMultiplier(ref float r, ref float g, ref float b)
        {
            r = 1f;
            g = 1f;
            b = 1f;
        }
    }
}
