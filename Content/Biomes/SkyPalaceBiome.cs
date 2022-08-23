using Terraria;
using Terraria.ModLoader;
using Terraria.Graphics.Capture;
using Microsoft.Xna.Framework;
using RecurrenceMod.Common.Systems;
using System;
using Terraria.ID;

namespace RecurrenceMod.Content.Biomes
{
    internal class SkyPalaceBiome : ModBiome
    {
        public override ModWaterStyle WaterStyle => ModContent.Find<ModWaterStyle>("RecurrenceMod/SkyPalaceWaterStyle");
        //public override ModSurfaceBackgroundStyle SurfaceBackgroundStyle => ModContent.Find<ModSurfaceBackgroundStyle>("RecurrenceMod/SkyPalaceBackgroundStyle");


        public override int Music => MusicID.Ocean;

        public override string BestiaryIcon => base.BestiaryIcon;
        public override string BackgroundPath => base.BackgroundPath;
        public override Color? BackgroundColor => base.BackgroundColor;
        public override string MapBackground => base.MapBackground;

        public override bool IsBiomeActive(Player player)
        {
            bool tileCount = ModContent.GetInstance<RecurrenceBiomes>().skyPalaceBlockCount >= 100;
            bool location = player.ZoneSkyHeight || player.ZoneOverworldHeight;
            return tileCount && location;
        }
    }
}
