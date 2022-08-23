using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.IO;
using Terraria.WorldBuilding;

namespace RecurrenceMod.Common.Systems.GenPasses
{
    internal class CloudPalaceBasePass : GenPass
    {
        public CloudPalaceBasePass() : base("Cloud Palace", 500f) { }

        protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
        {
            List<ushort> tilesToCheckList = new()
            {
                TileID.Cloud,
                TileID.RainCloud,
                TileID.SnowCloud
            };


            progress.Message = "Generating Clouds";
            int areaScan = Main.maxTilesX;
            while (--areaScan > 0)
            {
                int x = WorldGen.genRand.Next((int)(Main.maxTilesX * 0.1), (int)(Main.maxTilesX * 0.9));
                while (x > Main.maxTilesX / 2 - 150 && x < Main.maxTilesX / 2 + 150)
                {
                    x = WorldGen.genRand.Next((int)(Main.maxTilesX * 0.1), (int)(Main.maxTilesX * 0.9));
                }
                // Get Surface
                bool canSpawn = false;
                int surfaceY = 0;
                for (int checkY = 200; (double)checkY < Main.worldSurface; checkY++)
                {
                    if (Main.tile[x, checkY].HasTile)
                    {
                        surfaceY = checkY;
                        canSpawn = true;
                        break;
                    }
                }
                // Check for Other Islands
                if (canSpawn)
                {
                    int yVal = WorldGen.genRand.Next(90, surfaceY - 100);
                    yVal = Math.Min(yVal, (int)WorldGen.worldSurfaceLow - 50);

                    canSpawn = !RecurrenceUtils.CheckArea(x, yVal, 200, 60, tilesToCheckList);

                    if(canSpawn)
                    {
                        Recurrence.Instance.Logger.Info(string.Format("Cloud Should be at: {0}, {1}", x, yVal));
                        areaScan = -1;
                        progress.Value = 0.1f;
                        CloudIsland(x, yVal, progress);
                    }

                    
                }
            }
        }

        private static void CloudIsland(int x, int y, GenerationProgress progress)
        {
            WorldGenSystem.cloudPalaceX = x;
            WorldGenSystem.cloudPalaceY = y;

            // Create the Cloud Base
            double num1 = WorldGen.genRand.Next(100, 150);
            double num2 = num1;
            float num3 = WorldGen.genRand.Next(20, 30);

            Tile tile;

            int tX1 = x;
            int tX2 = x;
            int tY1 = y;
            int tY2 = y;

            Vector2 vector = new(x, y);
            Vector2 vector2 = new(x, y)
            {
                X = (float)WorldGen.genRand.Next(-20, 21) * 0.2f
            };
            while (vector2.X > -2f && vector2.X < 2f)
            {
                vector2.X = (float)WorldGen.genRand.Next(-20, 21) * 0.2f;
            }
            vector2.Y = (float)WorldGen.genRand.Next(-20, 21) * 0.02f;
            while(tX1 > 0.0 && num3 > 0f)
            {
                num1 -= (double)WorldGen.genRand.Next(4);
                num3 -= 1f;
                int x1 = (int)((double)vector.X - num1 * 0.5);
                int x2 = (int)((double)vector.X + num1 * 0.5);
                int y1 = (int)((double)vector.Y - num1 * 0.5);
                int y2 = (int)((double)vector.Y + num1 * 0.5);
                if (x1 < 0) x1 = 0;
                if (x2 > Main.maxTilesX) x2 = Main.maxTilesX;
                if (y1 < 0) y1 = 0;
                if (y2 > Main.maxTilesY) y2 = Main.maxTilesY;

                

                num2 = num1 * (double)WorldGen.genRand.Next(80, 120) * 0.01;

                float extra = vector.Y + 1f;
                for(int i = x1; i < x2; i++)
                {
                    if(WorldGen.genRand.NextBool(2))
                    {
                        extra += (float)WorldGen.genRand.Next(-1, 2);
                    }
                    if (extra < vector.Y) extra = vector.Y;
                    if (extra > vector.Y + 2f) extra = vector.Y + 2f;
                    for(int j = y1; j < y2; j++)
                    {
                        if(!((float)j > extra))
                        {
                            continue;
                        }
                        float absX = Math.Abs((float)i - vector.X);
                        float absY = Math.Abs((float)j - vector.Y) * 3f;
                        if(Math.Sqrt(absX * absX + absY * absY) < num2 * 0.4)
                        {
                            if (i < tX1) tX1 = i;
                            if (i > tX2) tX2 = i;
                            if (j < tY1) tY1 = j;
                            if (j > tY2) tY2 = j;
                            tile = Main.tile[i, j];
                            tile.ClearEverything();
                            WorldGen.PlaceTile(i, j, TileID.Cloud, forced: true);
                        }
                    }
                }
                vector += vector2;
                vector2.X += (float)WorldGen.genRand.Next(-20, 21) * 0.05f;
                if (vector2.X > 1f) vector2.X = 1f;
                if (vector2.X < -1f) vector2.X = -1f;
                if ((double)vector2.Y > 0.2) vector2.Y = -0.2f;
                if ((double)vector2.Y < -0.2) vector2.Y = -0.2f;
            }
            progress.Value = 0.2f;
            // Make the Cloud more Cloud Like
            int num8 = tX1;
            int num9 = 0;
            for (num8 += WorldGen.genRand.Next(5); num8 < tX2; num8 += WorldGen.genRand.Next(num9, (int)((double)num9 * 1.5)))
            {
                int num10 = tY2;
                
                while (!Main.tile[num8, num10].HasTile)
                {
                    num10--;

                }
                num10 += WorldGen.genRand.Next(-3, 4);
                num9 = WorldGen.genRand.Next(4, 8);
                int num11 = TileID.Cloud;
                if(WorldGen.genRand.NextBool(4))
                {
                    num11 = TileID.RainCloud;
                }
                for(int i = num8 - num9; i <= num8 + num9; i++)
                {
                    for(int j = num10 - num9; j <= num10 + num9; j++)
                    {
                        if(j > tY1)
                        {
                            float absX = Math.Abs(i - num8);
                            float absY = Math.Abs(j - num10) * 2;
                            if(Math.Sqrt(absX * absX + absY * absY) < (double)(num9 + WorldGen.genRand.Next(2)))
                            {
                                tile = Main.tile[i, j];
                                tile.ClearEverything();
                                WorldGen.PlaceTile(i, j, num11, forced: true);
                            }
                        }
                    }
                }
            }
            progress.Value = 0.3f;
            // Cut out a Bowl of Mud in the Cloud
            num1 = WorldGen.genRand.Next(80, 95);
            num2 = num1;
            num3 = WorldGen.genRand.Next(10, 15);
            vector.X = x;
            vector.Y = tY1;
            vector2.X = (float)WorldGen.genRand.Next(-20, 21) * 0.2f;
            while (vector2.X > -2f && vector2.X < 2f)
            {
                vector2.X = (float)WorldGen.genRand.Next(-20, 21) * 0.2f;
            }
            vector2.Y = (float)WorldGen.genRand.Next(-20, 21) * 0.02f;
            while (tX1 > 0.0 && num3 > 0f)
            {
                num1 -= (double)WorldGen.genRand.Next(4);
                num3 -= 1f;
                int x1 = (int)((double)vector.X - num1 * 0.5);
                int x2 = (int)((double)vector.X + num1 * 0.5);
                int y1 = tY1 - 1;
                int y2 = (int)((double)vector.Y + num1 * 0.5);
                if (x1 < 0) x1 = 0;
                if (x2 > Main.maxTilesX) x2 = Main.maxTilesX;
                if (y1 < 0) y1 = 0;
                if (y2 > Main.maxTilesY) y2 = Main.maxTilesY;



                num2 = num1 * (double)WorldGen.genRand.Next(80, 120) * 0.01;

                float extra = vector.Y + 1f;
                for (int i = x1; i < x2; i++)
                {
                    if (WorldGen.genRand.NextBool(2))
                    {
                        extra += (float)WorldGen.genRand.Next(-1, 2);
                    }
                    if (extra < vector.Y) extra = vector.Y;
                    if (extra > vector.Y + 2f) extra = vector.Y + 2f;
                    for (int j = y1; j < y2; j++)
                    {
                        float absX = Math.Abs((float)i - vector.X);
                        float absY = Math.Abs((float)j - vector.Y) * 3f;
                        if (Math.Sqrt(absX * absX + absY * absY) < num2 * 0.4)
                        {
                            tile = Main.tile[i, j];
                            tile.Clear(TileDataType.Tile);
                            WorldGen.PlaceTile(i, j, TileID.Dirt, forced: true);
                        }
                    }
                }
                vector += vector2;
                vector2.X += (float)WorldGen.genRand.Next(-20, 21) * 0.05f;
                if (vector2.X > 1f) vector2.X = 1f;
                if (vector2.X < -1f) vector2.X = -1f;
                if ((double)vector2.Y > 0.2) vector2.Y = -0.2f;
                if ((double)vector2.Y < -0.2) vector2.Y = -0.2f;
            }
            progress.Value = 0.4f;
            // Ensure the Bowl is made of Normal Clouds
            //int num12 = tX1;
            //num12 += WorldGen.genRand.Next(5);
            //while(num12 < tX2)
            //{
            //    int num13 = tY2;
            //    while (
            //        (
            //            //!Main.tile[num12, num13].HasTile || 
            //            Main.tile[num12, num13].TileType != TileID.Dirt
            //        ) && 
            //        num12 < tX2
            //    )
            //    {
            //        num13--;
            //        if(num13 < tY1)
            //        {
            //            num13 = tY2;
            //            num12 += WorldGen.genRand.Next(1, 4);
            //        }
            //    }
            //    if(num12 >= tX2)
            //    {   
            //        continue;
            //    }
            //    num13 += WorldGen.genRand.Next(0, 4);
            //    int num14 = WorldGen.genRand.Next(2, 5);
            //    for(int i = num12 - num14; i <= num12 + num14; i++)
            //    {
            //        for(int j = num13 - num14; j <= num13 + num14; j++)
            //        {
            //            if (j > tY1)
            //            {
            //                float absX = Math.Abs(i - num12);
            //                float absY = Math.Abs(j - num13) * 2;
            //                if(Math.Sqrt(absX * absX + absY * absY) < (double)num14)
            //                {
            //                    tile = Main.tile[i, j];
            //                    tile.Clear(TileDataType.Tile);
            //                    WorldGen.PlaceTile(i, j, TileID.Cloud, forced: true);
            //                }
            //            }
            //        }
            //    }
            //    num12 += WorldGen.genRand.Next(num14, (int)((double)num14 * 1.5));
            //}
            // Add Cloud Walls
            for (int i = tX1 - 20; i <= tX2 + 20; i++)
            {
                for(int j = tY1 - 20; j <= tY2 + 20; j++)
                {
                    bool flag = true;
                    for(int k = i - 1; k <= i + 1; k++)
                    {
                        for(int l = j - 1; l <= j + 1; l++)
                        {
                            if (!Main.tile[k, l].HasTile)
                            {
                                flag = false;
                            }
                        }
                    }
                    if(flag)
                    {
                        WorldGen.PlaceWall(i, j, WallID.Cloud);
                    }
                }
            }
            progress.Value = 0.5f;
            // Add Some Liquid
            for (int i = tX1; i <= tX2; i++)
            {
                int j;
                for(j = tY1; !Main.tile[i, j + 1].HasTile; j++)
                {
                }
                if(j >= tY2 || Main.tile[i, j + 1].TileType != TileID.Cloud)
                {
                    continue;
                }
                if(WorldGen.genRand.NextBool(10))
                {
                    int num15 = WorldGen.genRand.Next(1, 3);
                    for(int k = i - num15; k <= i + num15; k++)
                    {
                        if (Main.tile[k, j].TileType == TileID.Cloud && WorldGen.WillWaterPlacedHereStayPut(k, j))
                        {
                            tile = Main.tile[k, j];
                            tile.ClearEverything();
                            WorldGen.PlaceLiquid(k, j, LiquidID.Water, byte.MaxValue);
                        }
                        if (Main.tile[k, j + 1].TileType == TileID.Cloud && WorldGen.WillWaterPlacedHereStayPut(k, j + 1))
                        {
                            tile = Main.tile[k, j + 1];
                            tile.ClearEverything();
                            WorldGen.PlaceLiquid(k, j + 1, LiquidID.Water, byte.MaxValue);
                        }
                        if (k > i - num15 && k < i + 2 && Main.tile[k, j + 2].TileType == TileID.Cloud && WorldGen.WillWaterPlacedHereStayPut(k, j + 2))
                        {
                            tile = Main.tile[k, j + 2];
                            tile.ClearEverything();
                            WorldGen.PlaceLiquid(k, j + 2, LiquidID.Water, byte.MaxValue);
                        }
                    }
                }
                if(WorldGen.genRand.NextBool(5) && WorldGen.WillWaterPlacedHereStayPut(i, j))
                {
                    WorldGen.PlaceLiquid(i, j, byte.MaxValue, 1);
                }
            }
            progress.Value = 0.6f;
        }
    }
}
