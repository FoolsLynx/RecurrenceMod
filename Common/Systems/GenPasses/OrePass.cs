using RecurrenceMod.Content.Tiles.Ores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.IO;
using Terraria.ModLoader;
using Terraria.WorldBuilding;

namespace RecurrenceMod.Common.Systems.GenPasses
{
    internal class OrePass : GenPass
    {
        public const int numberOres = 4;

        public OrePass() : base("Recurrence Ores", 250f)
        {
        }

        protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
        {
            float rate = 1f / numberOres;

            progress.Message = "Spawning Ores";

            // Earth Element
            int maxToSpawn = WorldGen.genRand.Next(400, 700);
            int numSpawned = 0;
            int attempts = 0;

            while(numSpawned < maxToSpawn)
            {
                int x = WorldGen.genRand.Next(100, Main.maxTilesX - 100);
                int y = WorldGen.genRand.Next((int)WorldGen.worldSurface, Main.maxTilesY - 300);

                if(RecurrenceUtils.CheckTile(x, y, new List<int>() { TileID.Dirt, TileID.Mud, TileID.Sand, TileID.Stone, TileID.Sandstone, TileID.HardenedSand}))
                {
                    WorldGen.TileRunner(x, y, WorldGen.genRand.Next(2, 5), WorldGen.genRand.Next(2, 6), ModContent.TileType<EarthElementOre>());
                    numSpawned++;
                }

                attempts++;
                if(attempts > 100000)
                {
                    Recurrence.Instance.Logger.Warn(string.Format("Number of Earth Ore spawned before to many attempts: {0}", numSpawned));
                    numSpawned = maxToSpawn;
                }
            }
            progress.Value += rate;

            // Fire Element
            maxToSpawn = WorldGen.genRand.Next(400, 700);
            numSpawned = 0;
            attempts = 0;
            while (numSpawned < maxToSpawn)
            {
                int x = WorldGen.genRand.Next(100, Main.maxTilesX - 100);
                int y = WorldGen.genRand.Next((int)WorldGen.worldSurface, Main.maxTilesY - 150);

                if (RecurrenceUtils.CheckTile(x, y, new List<int>() { TileID.Dirt, TileID.Mud, TileID.Stone, TileID.Ash, TileID.Granite }) && RecurrenceUtils.CheckAreaForLiquid(x, y, 50, 50, LiquidID.Lava, 6375))
                {
                    WorldGen.TileRunner(x, y, WorldGen.genRand.Next(2, 5), WorldGen.genRand.Next(2, 6), ModContent.TileType<FireElementOre>());
                    numSpawned++;
                }

                attempts++;
                if (attempts > 100000)
                {
                    Recurrence.Instance.Logger.Warn(string.Format("Number of Fire Ore spawned before to many attempts: {0}", numSpawned));
                    numSpawned = maxToSpawn;
                }
            }
            progress.Value += rate;

            // Water Element
            maxToSpawn = WorldGen.genRand.Next(400, 700);
            numSpawned = 0;
            attempts = 0;
            while (numSpawned < maxToSpawn)
            {
                int x = WorldGen.genRand.Next(50, Main.maxTilesX - 50);
                int y = WorldGen.genRand.Next((int)WorldGen.worldSurface, Main.maxTilesY - 400);

                if (RecurrenceUtils.CheckTile(x, y, new List<int>() { TileID.Dirt, TileID.Mud, TileID.Stone, TileID.Sand, TileID.SnowBlock, TileID.IceBlock, TileID.Slush }) && RecurrenceUtils.CheckAreaForLiquid(x, y, 50, 50, LiquidID.Water, 6375))
                {
                    WorldGen.TileRunner(x, y, WorldGen.genRand.Next(2, 5), WorldGen.genRand.Next(2, 6), ModContent.TileType<WaterElementOre>());
                    numSpawned++;
                }

                attempts++;
                if (attempts > 100000)
                {
                    Recurrence.Instance.Logger.Warn(string.Format("Number of Water Ore spawned before to many attempts: {0}", numSpawned));
                    numSpawned = maxToSpawn;
                }
            }
            progress.Value += rate;

            // Wind Element
            maxToSpawn = WorldGen.genRand.Next(400, 700);
            numSpawned = 0;
            attempts = 0;
            while (numSpawned < maxToSpawn)
            {
                int x = WorldGen.genRand.Next(50, Main.maxTilesX - 50);
                int y = WorldGen.genRand.Next((int)WorldGen.worldSurfaceHigh, Main.maxTilesY - 400);

                if (RecurrenceUtils.CheckTile(x, y, new List<int>() { TileID.Dirt, TileID.Mud, TileID.Stone, TileID.Sand, TileID.Sandstone, TileID.HardenedSand }) && RecurrenceUtils.CheckAreaForAir(x, y, 30, 30, 150))
                {
                    WorldGen.TileRunner(x, y, WorldGen.genRand.Next(2, 5), WorldGen.genRand.Next(2, 6), ModContent.TileType<WindElementOre>());
                    numSpawned++;
                }

                attempts++;
                if (attempts > 100000)
                {
                    Recurrence.Instance.Logger.Warn(string.Format("Number of Wind Ore spawned before to many attempts: {0}", numSpawned));
                    numSpawned = maxToSpawn;
                }
            }
            progress.Value += rate;
        }
    }
}
